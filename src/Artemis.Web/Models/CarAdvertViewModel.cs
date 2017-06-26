using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Artemis.Web.Models
{
    public class CarAdvertViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Fuel { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public bool New { get; set; }

        public int? Mileage { get; set; }

        public DateTime? FirstRegistration { get; set; }
    }
}