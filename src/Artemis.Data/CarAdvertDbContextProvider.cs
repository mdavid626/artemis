using Artemis.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atermis.Data
{
    public class CarAdvertDbContextProvider : ICarAdvertDbContextProvider, IDisposable
    {
        private CarAdvertDbContext dbContext;

        public CarAdvertDbContextProvider()
        {
            dbContext = new CarAdvertDbContext();
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }

        public CarAdvertDbContext Provide()
        {
            return dbContext;
        }
    }
}
