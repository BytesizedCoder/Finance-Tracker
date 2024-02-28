using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRACKERPROJECT
{
    // static class named 'finances' with a generic list that holds 'FinanceTracker' which will allow to share data across different Forms.
    public static class FinanceData
    {
        public static List<FinanceTracker> finances = new List<FinanceTracker>();
    }
}
