using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artemis.Common
{
    public class CarAdvert : IHasKey
    {
        [Sortable]
        public int Id { get; set; }

        [Sortable]
        public string Title { get; set; }

        public FuelType Fuel { get; set; }

        [Sortable]
        public decimal Price { get; set; }

        public bool IsNew { get; set; }

        public int? Mileage { get; set; }

        public DateTime? FirstRegistration { get; set; }
    }
}
