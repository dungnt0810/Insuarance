using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Insurance_Web.Models
{
    public class ClaimInsuranceMetaData
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime Created { get; set; }

        [Required]
        [RegularExpression(@"^-?[0-9][0-9,\.]+$")]
        public decimal Price { get; set; }

        public bool Status { get; set; }
        public int IdPolicy { get; set; }
        public int IdCustomer { get; set; }
        public int IdEmployee { get; set; }

    }

    [ModelMetadataType(typeof(ClaimInsuranceMetaData))]
    public partial class ClaimInsurance { }
}
