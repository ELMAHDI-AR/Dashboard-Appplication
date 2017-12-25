using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApplicationDashboardMVC.DataAccess.Entitites
{
    public class Order: IEntity
    {
        public Order()
        {
            OrderDetail = new List<OrderDetails>();
        }
        public int ID { get; set; }
        public DateTime OrderDate { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<OrderDetails> OrderDetail { get; set; }
    }
}