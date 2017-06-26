using Artemis.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Artemis.Web.Models
{
    public class CollectionResult<T> where T : class
    {
        public IEnumerable<T> Entities { get; set; }
    }
}