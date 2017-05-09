using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using bangazon_inc.Models;

namespace bangazon_inc.DAL
{
    public class AppContext: DbContext
    {
        public AppContext() : base("BangazonInc")
        {
            
        }

       public DbSet<Customer> Customers { get; set; }
       public DbSet<Order> Orders { get; set; }
       public DbSet<OrderDetail> OrderDetails { get; set; }
       public DbSet<Payment> Payments { get; set; }
       public DbSet<Product> Products { get; set; }
    }
}