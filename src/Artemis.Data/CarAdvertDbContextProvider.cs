using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artemis.Data
{
    public class CarAdvertDbContextProvider : IDbContextProvider
    {
        public DbContext Provide()
        {
            return new CarAdvertDbContext();
        }
    }
}
