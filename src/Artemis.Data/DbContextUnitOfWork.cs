using Artemis.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artemis.Data
{
    public abstract class DbContextUnitOfWork : IUnitOfWork, IDisposable
    {
        private DbContext dbContext;

        protected abstract DbContext Create();

        public void Commit()
        {
            EnsureInstance();
            dbContext.SaveChanges();
        }

        public T ProvideContext<T>() where T : class
        {
            EnsureInstance();
            return dbContext as T;
        }

        public void Dispose()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }

        private void EnsureInstance()
        {
            if (dbContext == null)
                dbContext = Create();
        }
    }
}
