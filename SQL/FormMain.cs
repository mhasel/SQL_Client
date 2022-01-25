using System;
using System.Windows.Forms;

namespace SQL
{
    public partial class FormMain : Form
    {
        private OdbcWrapper oOdbc;
        private IDatabaseInterface oDatabase;
        private string sConnectionString = "dsn=personendb";
        public FormMain()
        {
            InitializeComponent();

            textBoxDsn.Text = sConnectionString.Substring(sConnectionString.IndexOf('=') + 1);
            oOdbc = new OdbcWrapper(sConnectionString);
            radioButtonOdbc_CheckedChanged(null, null);
        }

        private void UpdateConnectionControls(bool bOdbcChecked)
        {
            textBoxDsn.Enabled = bOdbcChecked;

            textBoxServer.Enabled = !bOdbcChecked;
            textBoxDb.Enabled = !bOdbcChecked;
            textBoxUser.Enabled = !bOdbcChecked;
            textBoxPassword.Enabled = !bOdbcChecked;

            oDatabase = (bOdbcChecked) ? oOdbc : null;
        }

        private void UpdateStatus(string sMsg)
        {
            if (sMsg != null)
            {
                textBoxStatus.AppendText(sMsg + Environment.NewLine);
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
            if (oDatabase == null)
            {
                return;
            }

            bool bStringChanged = !(sConnectionString.Equals($"dsn={textBoxDsn.Text}"));
            if (bStringChanged)
            {
                sConnectionString = $"dsn={textBoxDsn.Text}";
                oDatabase.UpdateConnectionString(sConnectionString);
            }

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
