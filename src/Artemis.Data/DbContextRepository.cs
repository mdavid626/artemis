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

        public IEnumerable<T> Get(QueryContext context = null)
        {
            var ensuredContext = EnsureQueryContext(context);
            var ordering = GetOrdering(ensuredContext);
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

        private QueryContext EnsureQueryContext(QueryContext context)
        {
            if (context == null)
            {
                return new QueryContext();
            }
            return context;
        }

        private string GetOrdering(QueryContext context)
        {
            var directionText = context.SortDescending
                ? " desc"
                : " asc";

            var allowedProps = typeof(T)
                .GetProperties()
                .Where(p => p.GetCustomAttribute<SortableAttribute>() != null)
                .Select(p => p.Name.ToLower());

            var prop = allowedProps.Intersect(new string[] { context.SortBy?.ToLower() });
            if (prop.Any())
            {
                return context.SortBy + directionText;
            }

            return nameof(IHasKey.Id) + directionText;
        }
    }
}
