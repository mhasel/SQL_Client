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
        private OdbcWrapper oOdbc;
        private MySqlWrapper oMySql;
        private IDatabaseInterface oDatabase;
        private DbType eDbType;
        public FormMain()
        {
            InitializeComponent();

            textBoxDsn.Text = "personendb";
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
                    return "server=" + textBoxServer.Text + "database=" + textBoxDb.Text +
                           "uid=" + textBoxUser.Text + "password=" + textBoxPassword.Text;
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
                    if (oOdbc == null)
                    {
                        try
                        {
                            oOdbc = new OdbcWrapper(sConnectionString);
                        }
                        catch (SqlException oEx)
                        {
                            textBoxStatus.AppendText(
                                "+++ ERROR +++" + Environment.NewLine
                                + oEx.Message + Environment.NewLine
                                );
                        }
                    }
                    else
                    {
                        oOdbc.ConnectionString = sConnectionString;
                    }

                    oDatabase = oOdbc;
                    break;
                case DbType.MYSQL:

                    if (oMySql == null)
                    {
                        try
                        {
                            oMySql = new MySqlWrapper(sConnectionString);
                        }
                        catch (SqlException oEx)
                        {
                            textBoxStatus.AppendText(
                                "+++ ERROR +++" + Environment.NewLine
                                + oEx.Message + Environment.NewLine
                                );
                        }
                    }

                    oDatabase = oMySql;
                    break;
                default:
                    // TODO: this should never happen. add logging anyway
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
                textBoxStatus.AppendText($"Unable to open browser due to the following error: {oEx.Message}");
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
        }
    }
}
