using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace SQL
{
    public class MySqlWrapper : IDatabaseInterface
    {
        private MySqlConnection oMySqlConnection;
        public MySqlWrapper(string sConnectionString)
        {
            if (sConnectionString == null)
            {
                throw new SqlException("Invalid connection string. Value cannot be NULL.");
            }

            oMySqlConnection = new MySqlConnection(sConnectionString);
        }

        public MySqlWrapper(string sUid, string sPwd, string sServer, string sDatabase)
        {
            string sConnectionString =
                $"server={sServer};database={sDatabase};uid={sUid};password={sPwd}";
            oMySqlConnection = new MySqlConnection(sConnectionString);
        }

        public void Connect()
        {
            try
            {
                oMySqlConnection.Open();
            }
            catch (Exception oEx)
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
            try
            {
                using (var oQuery = new MySqlCommand(sQuery, oMySqlConnection))
                {
                    return Convert.ToInt32(oQuery.ExecuteNonQuery());
                }
            }
            catch (Exception oEx)
            {
                throw new SqlException($"Could not execute query: {oEx.Message}");
            }
        }

        public int Scalar(string sQuery)
        {
            try
            {
                using (var oQuery = new MySqlCommand(sQuery, oMySqlConnection))
                {
                    return Convert.ToInt32(oQuery.ExecuteScalar());
                }
            }
            catch (Exception oEx)
            {
                throw new SqlException($"Could not execute query: {oEx.Message}");
            }
        }

        public List<string[]> Select(string sQuery)
        {
            try
            {
                using (var oQuery = new MySqlCommand(sQuery, oMySqlConnection))
                using (var oReader = oQuery.ExecuteReader())
                {
                    if (!oReader.HasRows)
                        return null;

                    var oData = new List<string[]>();
                    oData.Add(Enumerable.Range(0, oReader.FieldCount).Select(oReader.GetName).ToArray());
                    while (oReader.Read())
                    {
                        var oColumns = Enumerable.Range(0, oReader.FieldCount).Select(oReader.GetString).ToArray();
                        oData.Add(oColumns);
                    }
                    return oData;
                }
            }
            catch (Exception oEx)
            {
                throw new SqlException($"Could not execute query: {oEx.Message}");
            }
        }
    }
}
