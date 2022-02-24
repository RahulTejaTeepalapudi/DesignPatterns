using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern
{
    public class StrategyItem
    {
        public string DiscountType { get; set; }
        public IDiscountStrategy Strategy { get; set; }
        public bool IsApplicable { get; set; }
    }
}
