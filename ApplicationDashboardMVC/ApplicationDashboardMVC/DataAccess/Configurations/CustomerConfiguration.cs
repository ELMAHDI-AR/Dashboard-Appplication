using ApplicationDashboardMVC.DataAccess.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApplicationDashboardMVC.DataAccess.Configurations
{
    public class CustomerConfiguration : EntityConfiguration<Customer>
    {
        public CustomerConfiguration()
        {
            Property(c => c.CustomerName).IsRequired().HasMaxLength(100);
            Property(c => c.CustomerEmail).IsRequired().HasMaxLength(60);
            Property(c => c.CustomerPhone).IsRequired().HasMaxLength(100);
            Property(c => c.CustomerCountry).IsRequired().HasMaxLength(100);
            Property(c => c.CustomerImage).IsOptional();
        }
    }
}