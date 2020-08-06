using System;
using System.Collections.Generic;

namespace Insurance_Web.Models
{
    public partial class Policy
    {
        public Policy()
        {
            ClaimInsurance = new HashSet<ClaimInsurance>();
            Order = new HashSet<Order>();
            Proviso = new HashSet<Proviso>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int UsedTime { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }
        public string Detail { get; set; }

        public virtual ICollection<ClaimInsurance> ClaimInsurance { get; set; }
        public virtual ICollection<Order> Order { get; set; }
        public virtual ICollection<Proviso> Proviso { get; set; }
    }
}
