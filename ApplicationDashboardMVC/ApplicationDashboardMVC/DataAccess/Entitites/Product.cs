using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApplicationDashboardMVC.DataAccess.Entitites
{
    public class Product : IEntity
    {
        public Product()
        {
            OrderDetails = new List<OrderDetails>();
        }
        public int ID { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public string ProductImage { get; set; }
        public string ProductType { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
        
    }
}