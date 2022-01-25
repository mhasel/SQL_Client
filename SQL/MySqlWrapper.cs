using MySql.Data.MySqlClient;
using System;

namespace SQL
{
    public class MySqlWrapper : IDatabaseInterface
    {
        private MySqlConnection oMySqlConnection;
        public MySqlWrapper(string sConnectionString)
        {
            oMySqlConnection = new MySqlConnection(sConnectionString);
        }

        public MySqlWrapper(string sUid, string sPwd, string sServer, string sDatabase)
        {
            string sConnectionString = $"server={sServer};database={sDatabase};uid={sUid};password={sPwd}";
            oMySqlConnection = new MySqlConnection(sConnectionString)
        }
        public void Connect()
        {
            throw new NotImplementedException();
        }

        public void Disconnect()
        {
            throw new NotImplementedException();
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

        public void UpdateConnectionString(string sConnectionString)
        {
            throw new NotImplementedException();
        }
    }
}
