using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL
{
    public interface IDatabaseInterface
    {
        void Connect();
        void Disconnect();
        List<string[]> Select(string sQuery);
        int Scalar(string sQuery);
        int NonQuery(string sQuery);
    }
}
