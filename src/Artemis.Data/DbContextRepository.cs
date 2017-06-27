using Artemis.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic;

namespace Artemis.Data
{
    public abstract class DbContextRepository<T> : IRepository<T> where T : class, IHasKey
    {
        private IUnitOfWork unitOfWork;

        public abstract DbSet<T> EntityDbSet { get; }

        public DbContextRepository(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public T Get(int id)
        {
            return EntityDbSet.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<T> Get(string orderBy = null, string direction = null)
        {
            var ordering = GetOrdering(orderBy, direction);
            return EntityDbSet.OrderBy(ordering);
        }

        public void Update(T entity)
        {
            
        }

        public void Create(T entity)
        {
            EntityDbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            EntityDbSet.Remove(entity);
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

            var prop = allowedProps.Intersect(new string[] { orderBy?.ToLower() });
            if (prop.Any())
            {
                return orderBy + directionText;
            }

            return nameof(IHasKey.Id) + directionText;
        }
    }
}
