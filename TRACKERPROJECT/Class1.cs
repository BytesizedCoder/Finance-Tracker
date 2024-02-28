using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRACKERPROJECT
{
    public enum TransCategory
    {
        Housing,
        Food,
        Transportation,
        Entertainment,
        Health,
        Debt,
        Income
    }
    public class FinanceTracker
    {
        public string Description { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public TransCategory category { get; set; }

    }
}
