using System;
using System.Collections.Generic;

namespace Insurance_Web.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderDetail = new HashSet<OrderDetail>();
        }

        public int IdOrder { get; set; }
        public decimal Price { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public int IdCustomer { get; set; }
        public int IdPolicy { get; set; }
        public int IdEmployee { get; set; }
        public bool TypePayment { get; set; }

        public virtual Customer IdCustomerNavigation { get; set; }
        public virtual Employee IdEmployeeNavigation { get; set; }
        public virtual Policy IdPolicyNavigation { get; set; }
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
    }
}
