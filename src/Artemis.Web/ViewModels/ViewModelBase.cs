using Artemis.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
            return repository.Get(queryContext);
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
    }
}