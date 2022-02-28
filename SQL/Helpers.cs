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
            return oObject == DBNull.Value ? default (T) : (T)oObject;
        }

        /// <summary>
        /// string-specific function to handle null-column values. above generic function requires to check the column type beforehand
        /// and will throw an exception if the wrong type is passed (invalid cast exception)
        /// </summary>
        /// <param name="oObject"></param>
        /// <returns></returns>
        static internal string NullCheck(object oObject)
        {
            return oObject == DBNull.Value ? null : oObject.ToString();
        }
    }
}
