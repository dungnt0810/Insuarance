using System;
using System.Collections.Generic;

namespace Insurance_Web.Models
{
    public partial class Account
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool isEmployee { get; set; }
    }
}
