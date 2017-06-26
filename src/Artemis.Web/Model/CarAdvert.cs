using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Artemis.Web.Model
{
    public class CarAdvert
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Fuel { get; set; }

        public decimal Price { get; set; }

        public bool New { get; set; }

        public int? Mileage { get; set; }

        public DateTime? FirstRegistration { get; set; }
    }
}