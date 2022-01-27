using MySql.Data.MySqlClient;
using System;
using System.Linq;

namespace SQL
{
    public class MySqlWrapper : IDatabaseInterface
    {
        private MySqlConnection oMySqlConnection;
        public string ConnectionString 
        { 
            get
            {
                 return oMySqlConnection?.ConnectionString;
            }
            set
            {
                if ((oMySqlConnection != null) && (value != null))
                {
                    oMySqlConnection.ConnectionString = value;
                }
            }
        }

        public MySqlWrapper(string sConnectionString)
        {
            if (sConnectionString == null)
            {
                throw new SqlException("Invalid connection string. Value cannot be NULL.");
            }
            ConnectionString = sConnectionString;
            oMySqlConnection = new MySqlConnection(ConnectionString);
        }

        public MySqlWrapper(string sUid, string sPwd, string sServer, string sDatabase)
        {
            string sConnectionString = $"server={sServer};database={sDatabase};uid={sUid};password={sPwd}";
            oMySqlConnection = new MySqlConnection(sConnectionString);
        }

        public void Connect()
        {
            try
            {
                oMySqlConnection.Open();
            }
            catch(Exception oEx)
            {
                throw new SqlException($"Unable to establish connection:{Environment.NewLine}{oEx.Message}");
            }
        }

        public void Disconnect()
        {
            oMySqlConnection?.Close();
        }

        public void NonQuery(string sQuery)
        {
            throw new NotImplementedException();
        }

        public void Scalar(string sQuery)
        {
            throw new NotImplementedException();
        }

        public void Select(string sQuery)
        {
            throw new NotImplementedException();
        }
    }
}
