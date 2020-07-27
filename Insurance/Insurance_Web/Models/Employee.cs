using System;
using System.Collections.Generic;

namespace Insurance_Web.Models
{
    public partial class Employee
    {
        public Employee()
        {
            ClaimInsurance = new HashSet<ClaimInsurance>();
            Order = new HashSet<Order>();
        }

        public int IdEmployee { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Image { get; set; }
        public bool Status { get; set; }
        public int IdRole { get; set; }

        public virtual Role IdRoleNavigation { get; set; }
        public virtual ICollection<ClaimInsurance> ClaimInsurance { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }
}
