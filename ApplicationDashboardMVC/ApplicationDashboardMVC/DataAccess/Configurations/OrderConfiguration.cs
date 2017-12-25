using ApplicationDashboardMVC.DataAccess.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApplicationDashboardMVC.DataAccess.Configurations
{
    public class OrderConfiguration : EntityConfiguration<Order>
    {
        public OrderConfiguration()
        {
            Property(o => o.OrderDate).IsRequired();
        }
    }
}