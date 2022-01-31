using System;
using System.Data.Odbc;

namespace SQL
{
    public class OdbcWrapper : IDatabaseInterface
    {
        private OdbcConnection oOdbcConnection;
        private OdbcCommand oQuery;
        private OdbcDataReader oOdbcDataReader;

        public OdbcWrapper(string sConnectionString)
        {
            if (sConnectionString == null)
            {
                throw new SqlException("Invalid connection string. Value cannot be NULL.");
            }

            oOdbcConnection = new OdbcConnection(sConnectionString);
        }

        public OdbcWrapper(string sUid, string sPwd, string sServer, string sPort)
        {
            string sConnectionString;
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
