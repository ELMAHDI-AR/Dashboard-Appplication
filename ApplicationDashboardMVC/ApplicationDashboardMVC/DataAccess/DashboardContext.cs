using ApplicationDashboardMVC.DataAccess.Configurations;
using ApplicationDashboardMVC.DataAccess.Entitites;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ApplicationDashboardMVC.DataAccess
{
    public class DashboardContext : DbContext
    {

        public DashboardContext():base("DashboardOrder")
        {

        }

        #region Entities
        public IDbSet<Customer> CustomerSet { get; set; }
        public IDbSet<Order> OrderSet { get; set; }
        public IDbSet<Product> ProductSet { get; set; }
        public IDbSet<OrderDetails> OrderDetailSet { get; set; }

        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new CustomerConfiguration());
            modelBuilder.Configurations.Add(new OrderConfiguration());
            modelBuilder.Configurations.Add(new ProductConfiguration());
            modelBuilder.Configurations.Add(new OrderDetailsConfiguration());
        }

    }
}