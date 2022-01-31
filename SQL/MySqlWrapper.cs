using MySql.Data.MySqlClient;
using System;
using System.Linq;

namespace SQL
{
    public class MySqlWrapper : IDatabaseInterface
    {
        private MySqlConnection oMySqlConnection;
        private MySqlCommand oQuery;
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

        public MySqlWrapper(string sConnectionString)
        {
            if (sConnectionString == null)
            {
                throw new SqlException("Invalid connection string. Value cannot be NULL.");
            }
            this.sConnectionString = sConnectionString;
            oMySqlConnection = new MySqlConnection(sConnectionString);
        }

        public MySqlWrapper(string sUid, string sPwd, string sServer, string sDatabase)
        {
            sConnectionString = $"server={sServer};database={sDatabase};uid={sUid};password={sPwd}";
            oMySqlConnection = new MySqlConnection(sConnectionString);
        }

        public void Connect()
        {
            try
            {
                if (oMySqlConnection.ConnectionString != sConnectionString)
                {
                    oMySqlConnection.ConnectionString = sConnectionString;
                }
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

        public int NonQuery(string sQuery)
        {
            oQuery = new MySqlCommand(sQuery);

            // TODO: check documentation if method can throw exceptions
            try
            {
                return Convert.ToInt32(oQuery.ExecuteNonQuery());
            }
            catch (Exception oEx)
            {
                throw new SqlException($"Could not execute query: {oEx.Message}");
            }
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
