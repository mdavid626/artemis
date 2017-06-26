using Artemis.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artemis.Data
{
    internal class CarAdvertDbContext : DbContext
    {
        public DbSet<CarAdvert> CarAdverts { get; set; }
    }
}
