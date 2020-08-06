using System;
using System.Collections.Generic;

namespace Insurance_Web.Models
{
    public partial class Proviso
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int IdPolicy { get; set; }

        public virtual Policy IdPolicyNavigation { get; set; }
    }
}
