using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Insurance_Web.Models
{
    public class OrderDetailMetaData
    {
        public int Id { get; set; }
        public int IdO { get; set; }

        [Required]
        [RegularExpression(@"^-?[0-9][0-9,\.]+$")]
        public decimal Price { get; set; }

        [Required]
        public DateTime Created { get; set; }

        [Required]
        public string Payment { get; set; }
    }

    [ModelMetadataType(typeof(OrderDetailMetaData))]
    public partial class OrderDetail{}
}
