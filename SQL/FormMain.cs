using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SQL
{
    public partial class FormMain : Form
    {
        // --------------------Enums & Constants--------------------
        private enum DbType
        {
            ODBC,
            MYSQL
        }

        private const string sError = "++++ ERROR ++++";

        // --------------------Fields--------------------

        private IDatabase oDatabase;
        private DbType eDbType;

        // --------------------Constructor--------------------
        public FormMain()
        {
            InitializeComponent();

            textBoxDsn.Text = "personendb";
            textBoxServer.Text = "127.0.0.1";
            textBoxUser.Text = "root";
            textBoxDb.Text = "personendb";
            textBoxPassword.Text = "";

            radioButtonOdbc_CheckedChanged(null, null);
            textBoxResult.Font = new Font(FontFamily.GenericMonospace, textBoxResult.Font.Size);
        }

        // --------------------Methods--------------------
        /// <summary>
        /// Toggle textboxes for selected database.
        /// </summary>
        /// <param name="bOdbcChecked">Flag, whether or not Odbc connection radiobutton is checked</param>
        private void ToggleDbInfoControls(bool bOdbcChecked)
        {
            textBoxDsn.Enabled = bOdbcChecked;
            textBoxServer.Enabled = !bOdbcChecked;
            textBoxDb.Enabled = !bOdbcChecked;
            textBoxUser.Enabled = !bOdbcChecked;
            textBoxPassword.Enabled = !bOdbcChecked;

            eDbType = (bOdbcChecked) ? DbType.ODBC : DbType.MYSQL;
        }

        /// <summary>
        /// Append message text to status textbox. Put cursor on new line.
        /// </summary>
        /// <param name="sMsg">The message to put</param>
        private void UpdateStatus(string sMsg)
        {
            if (sMsg != null)
            {
                textBoxStatus.AppendText(sMsg + Environment.NewLine);
            }
        }

        /// <summary>
        /// Append results to result textbox. Put cursor on new line.
        /// </summary>
        /// <param name="sMsg">The message to put</param>
        private void UpdateResults(string sMsg)
        {
            if (sMsg != null)
            {
                textBoxResult.AppendText(sMsg + Environment.NewLine);
            }
        }

        /// <summary>
        /// Build connection string, depending on which radio button is checked.
        /// </summary>
        /// <returns>The assembled connection string or null (edge case).</returns>
        private string BuildConnectionString()
        {
            switch (eDbType)
            {
                case DbType.ODBC:
                    return $"dsn={textBoxDsn.Text}";
                case DbType.MYSQL:
                    return "server=" + textBoxServer.Text + ";database=" + textBoxDb.Text +
                           ";uid=" + textBoxUser.Text + ";password=" + textBoxPassword.Text + ";";
                default:
                    return null;
            }
        }

        /// <summary>
        /// Builds a connection string and initializes an instance of the chosen database.
        /// </summary>
        private void InitDatabase()
        {
            string sConnectionString = BuildConnectionString();

            switch(eDbType)
            {
                case DbType.ODBC:
                    try
                    {
                        oDatabase = new OdbcWrapper(sConnectionString);
                    }
                    catch (SqlException oEx)
                    {
                        UpdateStatus(sError);
                        UpdateStatus(oEx.Message);
                    }
                    break;
                case DbType.MYSQL:
                    try
                    {
                        oDatabase = new MySqlWrapper(sConnectionString);
                    }
                    catch (SqlException oEx)
                    {
                        UpdateStatus(sError);
                        UpdateStatus(oEx.Message);
                    }
                    break;
                default:
                    // Edge-case error. This shouldn't ever happen.
                    UpdateStatus(sError);
                    UpdateStatus("Unexpected: No database type selected.");
                    return;
            }
        }
        
        /// <summary>
        /// Update database-dependant controls.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButtonOdbc_CheckedChanged(object sender, System.EventArgs e)
        {
            ToggleDbInfoControls(radioButtonOdbc.Checked);
        }

        /// <summary>
        /// Open w3schools sql website in the default browser.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonHelp_Click(object sender, System.EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://www.w3schools.com/sql/");
            }
            catch (Exception oEx)
            {
                UpdateStatus("Unable to open browser due to the following error:"
                    + oEx.Message);
            }
        }

        /// <summary>
        /// Attempt to connect to selected database and toggle query/connection buttons.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonConnect_Click(object sender, EventArgs e)
        {
            InitDatabase();

            try
            {
                oDatabase.Connect();
                UpdateStatus("++++ SUCCESS ++++");
                UpdateStatus("Connection established.");
                buttonConnect.Enabled = false;
                buttonDisconnect.Enabled = true;
                buttonSelect.Enabled = true;
                buttonScalar.Enabled = true;
                buttonNonQuery.Enabled = true;
            }
            catch (SqlException oEx)
            {
                UpdateStatus(sError);
                UpdateStatus(oEx.Message);
            }
        }

        /// <summary>
        /// Disconnect from database and toggle query/connection buttons.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDisconnect_Click(object sender, EventArgs e)
        {
            oDatabase.Disconnect();
            UpdateStatus("Connection closed.");
            buttonConnect.Enabled = true;
            buttonDisconnect.Enabled = false;
            buttonSelect.Enabled = false;
            buttonScalar.Enabled = false;
            buttonNonQuery.Enabled = false;
        }

        /// <summary>
        /// Execute select query and show results in result-textbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSelect_Click(object sender, EventArgs e)
        {
            try
            {
                // Skip one line
                UpdateResults(string.Empty);
                // Get result. Will return null if there are no results to the query or if 
                // oDatabase points to NULL -> edge case
                List<string[]> oResults = oDatabase?.Select(textBoxQuery.Text);
                if (oResults == null)
                {
                    UpdateResults("Query has returned no results.");
                    return;
                }

                // Iterate over each column and find the maximum string length across all rows
                var iMaxLength = new List<int>();
                // Iterate over each column once. The amount of columns is the same for all rows
                for (int iCol = 0; iCol < oResults[0].Length; iCol++)
                {
                    iMaxLength.Add
                    (
                        // Only select one item per row, at the current iterations's column index
                        oResults
                            // Transform collection from string array to lengths of each string
                            .Select(sRow => sRow[iCol].Length)
                            // Find the longest string of this collection and add it's length to the iMaxLength list.
                            // The index in the list will match the index of the column the value was in.
                            .OrderByDescending(iLength => iLength)
                            .First()    
                    );
                };

                // Nested foreach loops to print results as table
                foreach (string[] sRow in oResults)
                {
                    string sColumns = string.Empty;
                    for (int iCol = 0; iCol < sRow.Length; iCol++)
                    {
                        // Pad string to column-specific max string length
                        sColumns += $"| {sRow[iCol].PadRight(iMaxLength[iCol])} |";
                    }
                    UpdateResults(sColumns);
                }
            }
            catch (Exception oEx)
            {
                UpdateResults(sError);
                UpdateResults(
                     "Unable to execute query. Check the \"Status\" box "
                    + "in the \"Connection\" tab for more information."
                    );
                UpdateStatus(sError);
                UpdateStatus(oEx.Message);
            }
        }

        /// <summary>
        /// Execute scalar query and show results in result-textbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonScalar_Click(object sender, EventArgs e)
        {
            string sResult;
            try
            {
                // sResult is null if there are no results (or oDatabase points to NULL -> edge case)
                sResult = oDatabase?.Scalar(textBoxQuery.Text);

                if (sResult == null)
                {
                    // todo: check for db nullptr edgecase by doing a nonquery

                    UpdateResults("Query has returned no results.");
                    return;
                }

                UpdateResults(sResult);
            }
            catch (Exception oEx)
            {
                UpdateResults(sError);
                UpdateResults(
                    "Unable to execute query. Check the \"Status\" box "
                    + "in the \"Connection\" tab for more information."
                    );
                UpdateStatus(sError);
                UpdateStatus(oEx.Message);
            }
        }

        /// <summary>
        /// Execute non-query and show results in result-textbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonNonQuery_Click(object sender, EventArgs e)
        {
            // nullable int
            int? iResult;
            try
            {
                // iResult is null if oDatabase is not referencing an object
                iResult = oDatabase?.NonQuery(textBoxQuery.Text);
                switch (iResult)
                {
                    // catch edge case. the only way this happens is due to a programming error
                    case null:
                        throw new SqlException("Database interface is pointing to NULL.");
                    case -1:
                        UpdateResults("NonQuery executed successfully.");
                        break;
                    default:
                        UpdateResults(
                            "NonQuery executed successfully on "
                            + iResult.ToString() + " rows."
                            );
                        break;
                }
            }
            catch (Exception oEx)
            {
                UpdateResults(sError);
                UpdateResults(
                    "Unable to execute query. Check the \"Status\" box "
                    + "in the \"Connection\" tab for more information."
                    );
                UpdateStatus(sError);
                UpdateStatus(oEx.Message);
            }
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            textBoxQuery.Text = (checkBox.Checked)
                ?   "SELECT Vorname, Zuname, tort.name AS Wohnort" + Environment.NewLine
                    + "FROM tperson" + Environment.NewLine
                    + "LEFT JOIN tort ON tperson.wohnort = tort.id"
                :   string.Empty;
        }
    }
}
