using System;
using System.Collections.Generic;

namespace Insurance_Web.Models
{
    public partial class Account
    {
        public int IdAccount { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Image { get; set; }
        public bool? Status { get; set; }
        public int IdRole { get; set; }
    }
}
