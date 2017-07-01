using Artemis.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Dynamic;
using System.Reflection;

namespace Artemis.Web.ViewModels
{
    public class ViewModelBase<T> : IViewModel<T>
    {
        private IRepository<T> repository;
        private IUnitOfWork unitOfWork;

        public ViewModelBase(IRepository<T> repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<T> Get(QueryContext queryContext)
        {
            var ensuredContext = EnsureQueryContext(queryContext);
            var ordering = GetOrdering(ensuredContext);
            return repository.Get().OrderBy(ordering);
        }

        public T Get(int id)
        {
            return repository.Get(id);
        }

        public void Update(T entity)
        {
            repository.Update(entity);
            unitOfWork.Commit();
        }

        public void Create(T entity)
        {
            repository.Create(entity);
            unitOfWork.Commit();
        }

        public void Delete(T entity)
        {
            repository.Delete(entity);
            unitOfWork.Commit();
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
                .Where(p => Attribute.IsDefined(p, typeof(SortableAttribute)))
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