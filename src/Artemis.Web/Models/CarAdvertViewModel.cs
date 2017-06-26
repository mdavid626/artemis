using Artemis.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Artemis.Web.Models
{
    public class CarAdvertViewModel : IValidatableObject
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

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? Mileage { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? FirstRegistration { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (New && (Mileage != null || FirstRegistration != null))
            {
                yield return new ValidationResult("Only used cars have Mileage and FirstRegistration", new[] { nameof(New), nameof(Mileage), nameof(FirstRegistration) });
            }

            if (!New && (Mileage == null || FirstRegistration == null))
            {
                yield return new ValidationResult("For used cars Mileage and FirstRegistration is required", new[] { nameof(New), nameof(Mileage), nameof(FirstRegistration) });
            }

            FuelType fuelType;
            if (!Enum.TryParse(Fuel, true, out fuelType))
            {
                yield return new ValidationResult("Fuel is not valid", new[] { nameof(Fuel) });
            }
        }
    }
}