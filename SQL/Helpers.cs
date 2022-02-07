using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL
{
    static internal class Helpers
    {
        /// <summary>
        /// Generic function to handle null-column values. Returns the objects
        /// default value if it has DBNull value, otherwise the object.
        /// </summary>
        /// <typeparam name="T">The type to default to</typeparam>
        /// <param name="oObject">The object to check</param>
        /// <returns></returns>
        static internal T NullCheck<T>(object oObject)
        {
            return (oObject == DBNull.Value ? default(T) : (T)oObject);
        }
    }
}
