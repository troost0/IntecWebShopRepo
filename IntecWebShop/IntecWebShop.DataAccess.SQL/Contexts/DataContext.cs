﻿using IntecWebShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntecWebShop.DataAccess.SQL.Contexts
{
    public class DataContext : DbContext
    {
        public DbSet<Product> Products{ get; set; }
        public DbSet<ProductCategory> ProductCategories{ get; set; }


        public DataContext() : base("DefaultConnection")
        {

        }
    }
}
