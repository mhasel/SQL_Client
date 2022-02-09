using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace SQL
{
    // Custom wrapper class to extend/customize MySqlConnection-class functionality
    public class MySqlWrapper : IDatabase
    {
        // --------------------Fields--------------------
        private readonly MySqlConnection oMySqlConnection;

        // --------------------Constructors--------------------

        /// <summary>
        /// Constructs a MySqlConnection instance internally and initializes it with
        /// the given connection string.
        /// </summary>
        /// <param name="sConnectionString">MySql server connection string</param>
        /// <exception cref="SqlException">Exception wrapper to throw to UI-level</exception>
        public MySqlWrapper(string sConnectionString)
        {
            if (sConnectionString == null)
            {
                throw new SqlException("Invalid connection string. Value cannot be NULL.");
            }

            oMySqlConnection = new MySqlConnection(sConnectionString);
        }

        /// <summary>
        /// Constructs a MySqlConnection instance internally, builds a connection string from passed
        /// parameters and and initializes it.
        /// </summary>
        /// <param name="sUid">User ID</param>
        /// <param name="sPwd">Password</param>
        /// <param name="sServer">Server adress</param>
        /// <param name="sDatabase">Database name</param>
        /// <exception cref="SqlException">Exception wrapper to throw to UI-level</exception>
        public MySqlWrapper(string sUid, string sPwd, string sServer, string sDatabase)
        {
            if ((sUid == null) || (sPwd == null) || (sServer == null) || (sDatabase == null))
            {
                throw new SqlException("Invalid connection string. Values cannot be NULL.");
            }

            string sConnectionString =
                $"server={sServer};database={sDatabase};uid={sUid};password={sPwd}";
            oMySqlConnection = new MySqlConnection(sConnectionString);
        }

        // --------------------Methods--------------------

        /// <summary>
        /// Connect to database.
        /// </summary>
        /// <exception cref="SqlException">Exception wrapper to throw to UI-level</exception>
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

        /// <summary>
        /// Terminate connection to database.
        /// </summary>
        public void Disconnect()
        {
            oMySqlConnection?.Close();
        }

        /// <summary>
        /// Execute a select query on the connected database.
        /// </summary>
        /// <param name="sQuery">The query/statement to be executed</param>
        /// <returns>All rows and columns that match the query.</returns>
        /// <exception cref="SqlException">Exception wrapper to throw to UI-level</exception>      
        public List<string[]> Select(string sQuery)
        {
            try
            {
                // using-blocks automatically free resources declared within them after going out of scope.
                using (var oQuery = new MySqlCommand(sQuery, oMySqlConnection))
                using (var oReader = oQuery.ExecuteReader())
                {
                    // No results
                    if (!oReader.HasRows)
                        return null;

                    // Get column names and add them to results list as first item.
                    // Each string array represents a row, with each item in the array being a column.
                    var oData = new List<string[]>
                    {                  
                        // Iterate over every column, get the column name and transform the collection to a string array
                        Enumerable.Range(0, oReader.FieldCount).Select(oReader.GetName).ToArray(),
                        Enumerable.Range(0, oReader.FieldCount).Select(sItem => "----").ToArray()
                    };

                    // Add results for each row to list. 
                    while (oReader.Read())
                    {
                        // Iterate over every column
                        var sColumns = Enumerable.Range(0, oReader.FieldCount)
                            .Select(iCol =>
                            // Get value from each column, check for DBNull and return either the value or NULL as a string
                            Helpers.NullCheck<string>(oReader.GetValue(iCol))?.ToString() ?? "NULL"
                        ).ToArray();
                        // Add to list of rows
                        oData.Add(sColumns);
                    }
                    return oData;
                }
            }
            catch (Exception oEx)
            {
                throw new SqlException($"Could not execute query: {oEx.Message}");
            }
        }

        /// <summary>
        /// Execute a scalar query on the connected database
        /// </summary>
        /// <param name="sQuery">The scalar query to be executed</param>
        /// <returns>
        /// The first column of the first row that matches the query. Additional columns or rows are ignored.
        /// Returns null if there are no results.
        /// </returns>
        /// <exception cref="SqlException">Exception wrapper to throw to UI-level</exception>
        public string Scalar(string sQuery)
        {
            try
            {
                using (var oQuery = new MySqlCommand(sQuery, oMySqlConnection))
                {
                    return oQuery?.ExecuteScalar()?.ToString();
                }
            }
            catch (Exception oEx)
            {
                throw new SqlException($"Could not execute query: {oEx.Message}");
            }
        }

        /// <summary>
        /// Execute a non-query on the database.
        /// </summary>
        /// <param name="sQuery">The non-query to be executed</param>
        /// <returns>
        /// The number of rows affected by the command.
        /// </returns>
        /// <exception cref="SqlException">Exception wrapper to throw to UI-level</exception>
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
    }
}
