using System;
using System.Data.Odbc;

namespace SQL
{
    public class OdbcWrapper : IDatabaseInterface
    {
        OdbcConnection oOdbcConnection { get; set; }
        OdbcCommand oOdbcCommand { get; set; }
        OdbcDataReader oOdbcDataReader { get; set; }
        public OdbcWrapper(string sConnectionString)
        {
            oOdbcConnection = new OdbcConnection(sConnectionString);
        }

        public OdbcWrapper(string sUid, string sPwd, string sServer, string sPort)
        {
            // Server=myServerAddress;Port=1234;Database=myDataBase;Uid=myUsername;Pwd=myPassword;
            OdbcConnectionStringBuilder oBuilder = new OdbcConnectionStringBuilder();
            oBuilder.Add("Uid",     sUid);
            oBuilder.Add("Pwd",     sPwd);
            oBuilder.Add("Server",  sServer);
            oBuilder.Add("Port",    sPort);

            oOdbcConnection = new OdbcConnection(oBuilder.ConnectionString);
        }

        public void Connect()
        {
            try
            {
                oOdbcConnection.Open();
            }
            catch (Exception oEx)
            {
                //oOdbcConnection.Close();
                throw new SqlException($"Unable to establish connection:{Environment.NewLine}{oEx.Message}");
            }
        }

        public void Disconnect()
        {
            oOdbcConnection.Close();
        }

        public void Select(string sQuery)
        {
            throw new NotImplementedException();
        }
        public void Scalar(string sQuery)
        {
            throw new NotImplementedException();
        }
        public void NonQuery(string sQuery)
        {
            throw new NotImplementedException();
        }
        public void UpdateConnectionString(string sConnectionString)
        {
            if (sConnectionString == null)
            {
                // send msg to status textbox
                return;
            }

            oOdbcConnection.ConnectionString = sConnectionString;
        }
    }
}
