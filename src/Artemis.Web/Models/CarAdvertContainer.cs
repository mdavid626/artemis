using Artemis.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Artemis.Web.Models
{
    public class CarAdvertContainer
    {
        public IEnumerable<CarAdvertViewModel> CarAdverts { get; set; }
    }
}