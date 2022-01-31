﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL
{
    public interface IDatabaseInterface
    {
        void Connect();
        void Disconnect();
        void Select(string sQuery);
        void Scalar(string sQuery);
        int NonQuery(string sQuery);
    }
}
