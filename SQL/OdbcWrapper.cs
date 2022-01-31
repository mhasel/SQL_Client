using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;

namespace SQL
{
    public class OdbcWrapper : IDatabaseInterface
    {
        private OdbcConnection oOdbcConnection;
        
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

        public List<string[]> Select(string sQuery)
        {
            try
            {
                using (var oQuery = new OdbcCommand(sQuery, oOdbcConnection))
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
        public int Scalar(string sQuery)
        {
            try
            {
                using (var oQuery = new OdbcCommand(sQuery, oOdbcConnection))
                {
                    return Convert.ToInt32(oQuery.ExecuteScalar());
                }
            }
            catch (Exception oEx)
            {
                throw new SqlException($"Could not execute query: {oEx.Message}");
            }
        }
        public int NonQuery(string sQuery)
        {
            try
            {
                using (var oQuery = new OdbcCommand(sQuery, oOdbcConnection))
                {
                    return Convert.ToInt32(oQuery.ExecuteNonQuery());
                }
            }
            catch (Exception oEx)
            {
                throw new SqlException($"Could not execute query: {oEx.Message}");
            }
        }
    }
}
