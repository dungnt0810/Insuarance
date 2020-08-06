using System;
using System.Collections.Generic;

namespace Insurance_Web.Models
{
    public partial class ClaimInsurance
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }
        public decimal Price { get; set; }
        public bool Status { get; set; }
        public int IdPolicy { get; set; }
        public int IdCustomer { get; set; }
        public int IdEmployee { get; set; }

        public virtual Customer IdCustomerNavigation { get; set; }
        public virtual Employee IdEmployeeNavigation { get; set; }
        public virtual Policy IdPolicyNavigation { get; set; }
    }
}
