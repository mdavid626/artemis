using Artemis.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artemis.Data
{
    public class CarAdvertRepository : ICarAdvertRepository
    {
        private ICarAdvertDbContextProvider dbContextProvider;

        public CarAdvertRepository(ICarAdvertDbContextProvider dbContextProvider)
        {
            this.dbContextProvider = dbContextProvider;
        }

        public CarAdvert Get(int id)
        {
            return null;
        }

        public IEnumerable<CarAdvert> Get()
        {
            return new CarAdvert[0];
        }

        public void Update(CarAdvert carAdvert)
        {

        }

        public void Create(CarAdvert carAdvert)
        {

        }

        public void Delete(CarAdvert carAdvert)
        {

        }
    }
}
