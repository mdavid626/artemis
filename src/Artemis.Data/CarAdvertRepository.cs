using Artemis.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Data.Entity;

namespace Artemis.Data
{
    public class CarAdvertRepository : DbContextRepository<CarAdvert>
    {
        private IUnitOfWork unitOfWork;

        private DbSet<CarAdvert> entityDbSet;

        public override DbSet<CarAdvert> EntityDbSet
        {
            get
            {
                if (entityDbSet == null)
                    entityDbSet = unitOfWork.ProvideContext<CarAdvertDbContext>().CarAdverts;
                return entityDbSet;
            }
        }

        public CarAdvertRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
    }
}
