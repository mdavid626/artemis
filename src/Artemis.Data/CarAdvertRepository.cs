using Artemis.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artemis.Data
{
    public class CarAdvertRepository : ICarAdvertRepository, IDisposable
    {
        private CarAdvertDbContext dbContext;

        public CarAdvertRepository(ICarAdvertDbContextProvider dbContextProvider)
        {
            this.dbContext = dbContextProvider.Provide(); ;
        }

        public CarAdvert Get(int id)
        {
            return dbContext.CarAdverts.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<CarAdvert> Get()
        {
            return dbContext.CarAdverts;
        }

        public void Update(CarAdvert carAdvert)
        {
            dbContext.SaveChanges();
        }

        public void Create(CarAdvert carAdvert)
        {
            dbContext.CarAdverts.Add(carAdvert);
            dbContext.SaveChanges();
        }

        public void Delete(CarAdvert carAdvert)
        {
            dbContext.CarAdverts.Remove(carAdvert);
            dbContext.SaveChanges();
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}
