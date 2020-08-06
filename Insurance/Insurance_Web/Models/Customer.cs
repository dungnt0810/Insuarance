using System;
using System.Collections.Generic;

namespace Insurance_Web.Models
{
    public partial class Customer
    {
        public Customer()
        {
            ClaimInsurance = new HashSet<ClaimInsurance>();
            Order = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public bool Gender { get; set; }
        public DateTime Birthday { get; set; }
        public int IdCard { get; set; }
        public bool IsRemoved { get; set; }

        public virtual ICollection<ClaimInsurance> ClaimInsurance { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }
}
