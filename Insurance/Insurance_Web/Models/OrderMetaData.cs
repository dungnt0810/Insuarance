using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Insurance_Web.Models
{
    public class OrderMetaData
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"^-?[0-9][0-9,\.]+$")]
        public decimal Price { get; set; }

        [Required]
        public DateTime TimeStart { get; set; }

        [Required]
        public DateTime TimeEnd { get; set; }

        [Required]
        public string Fullname { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Description { get; set; }
        public int IdCustomer { get; set; }
        public int IdPolicy { get; set; }
        public int? IdEmployee { get; set; }
        public bool TypePayment { get; set; }
    }

    [ModelMetadataType(typeof(OrderMetaData))]
    public partial class Order{ }
}
