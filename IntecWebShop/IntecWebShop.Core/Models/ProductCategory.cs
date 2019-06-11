using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntecWebShop.Core.Models
{
    public class ProductCategory : BaseEntity
    {
        [DisplayName("Category Name")]
        public string Category { get; set; }
    }
}
