using System;

namespace SQL
{
    internal class SqlException : Exception
    {
        public SqlException() { }
        public SqlException(string sMessage) : base(sMessage) { }
    }
}
