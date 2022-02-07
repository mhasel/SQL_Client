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
        /// default value of type T if it has DBNull value, otherwise the object, cast to type T.
        /// </summary>
        /// <typeparam name="T">The type to default to</typeparam>
        /// <param name="oObject">The object to check</param>
        /// <returns></returns>
        static internal T NullCheck<T>(object oObject)
        {
            return oObject == DBNull.Value ? default : (T)oObject;
        }
    }
}
