using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL
{
    // Interface that implements common database functions
    public interface IDatabase
    {
        /// <summary>
        /// Connect to database.
        /// </summary>
        /// <exception cref="SqlException"></exception>
        void Connect();

        /// <summary>
        /// Terminate connection to database.
        /// </summary>
        void Disconnect();

        /// <summary>
        /// Execute a select query on the connected database.
        /// </summary>
        /// <param name="sQuery">The query/statement to be executed</param>
        /// <returns>All rows and columns that match the query.</returns>
        /// <exception cref="SqlException"></exception>
        List<string[]> Select(string sQuery);

        /// <summary>
        /// Execute a scalar query on the connected database
        /// </summary>
        /// <param name="sQuery">The scalar query to be executed</param>
        /// <returns>
        /// The first column of the first row that matches the query. Additional columns or rows are ignored.
        /// Returns null if there are no results.
        /// </returns>
        /// <exception cref="SqlException"></exception>
        string Scalar(string sQuery);
        /// <summary>
        /// Execute a non-query on the database.
        /// </summary>
        /// <param name="sQuery">The non-query to be executed</param>
        /// <returns>
        /// The number of rows affected by the command.
        /// </returns>
        /// <exception cref="SqlException"></exception>
        int NonQuery(string sQuery);
    }
}
