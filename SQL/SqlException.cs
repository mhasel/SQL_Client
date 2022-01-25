using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL
{
    internal class SqlException : Exception
    {
        public SqlException() { }
        public SqlException(string sMessage) : base(sMessage) { }
    }
}
