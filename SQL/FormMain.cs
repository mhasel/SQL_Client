using System;
using System.Windows.Forms;

namespace SQL
{
    public partial class FormMain : Form
    {
        private enum DbType
        {
            ODBC,
            MYSQL
        }
        private IDatabaseInterface oDatabase;
        private DbType eDbType;
        public FormMain()
        {
            InitializeComponent();

            textBoxDsn.Text = "personendb";
            textBoxServer.Text = "127.0.0.1";
            textBoxUser.Text = "root";
            textBoxDb.Text = "personendb";
            textBoxPassword.Text = "";

            radioButtonOdbc_CheckedChanged(null, null);
        }

        private void UpdateConnectionControls(bool bOdbcChecked)
        {
            textBoxDsn.Enabled = bOdbcChecked;
            textBoxServer.Enabled = !bOdbcChecked;
            textBoxDb.Enabled = !bOdbcChecked;
            textBoxUser.Enabled = !bOdbcChecked;
            textBoxPassword.Enabled = !bOdbcChecked;

            eDbType = (bOdbcChecked) ? DbType.ODBC : DbType.MYSQL;
        }

        private void UpdateStatus(string sMsg)
        {
            if (sMsg != null)
            {
                textBoxStatus.AppendText(sMsg + Environment.NewLine);
            }
        }
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

        private void UpdateConnectionString()
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
                        textBoxStatus.AppendText(
                            "+++ ERROR +++" + Environment.NewLine
                            + oEx.Message + Environment.NewLine
                            );
                    }
                    break;
                case DbType.MYSQL:
                    try
                    {
                        oDatabase = new MySqlWrapper(sConnectionString);
                    }
                    catch (SqlException oEx)
                    {
                        textBoxStatus.AppendText(
                            "+++ ERROR +++" + Environment.NewLine
                            + oEx.Message + Environment.NewLine
                            );
                    }
                    break;
                default:
                    // TODO: this should never happen. add logging
                    return;
            }
        }

        private void radioButtonOdbc_CheckedChanged(object sender, System.EventArgs e)
        {
            UpdateConnectionControls(radioButtonOdbc.Checked);
        }

        private void buttonHelp_Click(object sender, System.EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://www.w3schools.com/sql/");
            }
            catch (Exception oEx)
            {
                textBoxStatus.AppendText(
                    "Unable to open browser due to the following error:"
                    + oEx.Message + Environment.NewLine
                    );
            }
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            UpdateConnectionString();

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
                UpdateStatus("++++ ERROR ++++");
                UpdateStatus(oEx.Message);
            }
        }


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

        private void buttonSelect_Click(object sender, EventArgs e)
        {

        }

        private void buttonScalar_Click(object sender, EventArgs e)
        {

        }

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
                        textBoxResult.AppendText("NonQuery executed successfully.");
                        break;
                    default:
                        textBoxResult.AppendText(
                            "NonQuery executed successfully on "
                            + iResult.ToString() + " rows."
                            );
                        break;
                }
            }
            catch(SqlException oEx)
            {
                textBoxStatus.AppendText(
                    "+++ ERROR+++" + Environment.NewLine
                    + oEx.Message + Environment.NewLine
                    );
            }
        }
    }
}
