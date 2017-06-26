using Artemis.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic;
using System.Reflection;

namespace Artemis.Data
{
    public class CarAdvertRepository : ICarAdvertRepository, IDisposable
    {
        private CarAdvertDbContext dbContext;

        public CarAdvertRepository(ICarAdvertDbContextProvider dbContextProvider)
        {
            this.dbContext = dbContextProvider.Provide();
        }

        public CarAdvert Get(int id)
        {
            return dbContext.CarAdverts.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<CarAdvert> Get(string orderBy = null, string direction = null)
        {
            var ordering = GetOrdering(orderBy, direction);
            return dbContext.CarAdverts.OrderBy(ordering);
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

        private string GetOrdering(string orderBy, string direction)
        {
            var ascending = true;
            if (direction?.ToLower() == "desc")
                ascending = false;

            var directionText = ascending
                ? " asc"
                : " desc";

            var allowedProps = typeof(CarAdvert)
                .GetProperties()
                .Where(p => p.GetCustomAttribute<SortableAttribute>() != null)
                .Select(p => p.Name.ToLower());

            var prop = allowedProps.Intersect(new string[] { orderBy.ToLower() });
            if (prop.Any())
            {
                return orderBy + directionText;
            }

            return nameof(CarAdvert.Id);
        }
    }
}
