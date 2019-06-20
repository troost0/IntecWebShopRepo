using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntecWebShop.Core.ViewModels
{
    public class BasketSummaryViewModel
    {
        public int BasketCount { get; set; }
        public decimal basketTotal { get; set; }

        public BasketSummaryViewModel(int count, decimal total)
        {
            basketTotal = total;
            BasketCount = count;
        }
    }
}
