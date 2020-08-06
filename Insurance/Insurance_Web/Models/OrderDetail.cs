using System;
using System.Collections.Generic;

namespace Insurance_Web.Models
{
    public partial class OrderDetail
    {
        public int Id { get; set; }
        public int IdO { get; set; }
        public decimal Price { get; set; }
        public DateTime Created { get; set; }
        public string Payment { get; set; }

        public virtual Order IdONavigation { get; set; }
    }
}
