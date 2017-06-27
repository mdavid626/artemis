using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artemis.Data
{
    public class CarAdvertUnitOfWork : DbContextUnitOfWork
    {
        protected override DbContext Create()
        {
            return new CarAdvertDbContext();
        }
    }
}
