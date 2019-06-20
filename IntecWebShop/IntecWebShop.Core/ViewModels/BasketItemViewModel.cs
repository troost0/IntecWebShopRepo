using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntecWebShop.Core.ViewModels
{
    public class BasketItemViewModel
    {
        public string Id { get; set; }
        public int Quanitity { get; set; }
        public string ProductName { get; set; }
        public Decimal Price { get; set; }
        public string Image { get; set; }

    }
}
