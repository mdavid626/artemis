using Artemis.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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

        public IQueryable<T> Get()
        {
            return EntityDbSet;
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
    }
}
