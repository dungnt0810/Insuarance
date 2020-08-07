using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Insurance_Web.Models
{
    public class CustomerMetaData
    {

        public int Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [PasswordPropertyText]
        public string Password { get; set; }

        [Required]
        public string Fullname { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [Required]
        public string Address { get; set; }
        
        public bool Gender { get; set; }

        [Required]
        public DateTime Birthday { get; set; }

        [Required]
        public int IdCard { get; set; }

        public bool IsRemoved { get; set; }
    }

    [ModelMetadataType(typeof(CustomerMetaData))]
    public partial class Customer{ }
}
