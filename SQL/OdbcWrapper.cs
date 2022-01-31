using System;
using System.Data.Odbc;

namespace SQL
{
    public class OdbcWrapper : IDatabaseInterface
    {
        private OdbcConnection oOdbcConnection;
        private OdbcCommand oQuery;
        private OdbcDataReader oOdbcDataReader;
        private string sConnectionString;
        public string ConnectionString
        {
            get
            {
                return sConnectionString;
            }
            set
            {
                sConnectionString = value;
            }
        }
        public OdbcWrapper(string sConnectionString)
        {
            if (sConnectionString == null)
            {
                throw new SqlException("Invalid connection string. Value cannot be NULL.");
            }
            this.sConnectionString = sConnectionString;
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
            sConnectionString = oBuilder.ConnectionString;

            oOdbcConnection = new OdbcConnection(sConnectionString);
        }

        public void Connect()
        {
            try
            {
                if (oOdbcConnection.ConnectionString != sConnectionString)
                {
                    oOdbcConnection.ConnectionString = sConnectionString;
                }

                oOdbcConnection.Open();
            }
            catch (Exception oEx)
            {
                throw new SqlException($"Unable to establish connection:{Environment.NewLine}{oEx.Message}");
            }
        }

        public void Disconnect()
        {
            oOdbcConnection?.Close();
        }

        public void Select(string sQuery)
        {
            throw new NotImplementedException();
        }
        public void Scalar(string sQuery)
        {
            throw new NotImplementedException();
        }
        public int NonQuery(string sQuery)
        {
            oQuery = new OdbcCommand(sQuery);
            try
            {
                return Convert.ToInt32(oQuery.ExecuteNonQuery());
            }
            catch (Exception oEx)
            {
                throw new SqlException($"Could not execute query: {oEx.Message}");
            }
        }
    }
}
