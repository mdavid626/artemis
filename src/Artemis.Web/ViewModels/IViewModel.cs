using Artemis.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Artemis.Web.ViewModels
{
    public interface IViewModel<T>
    {
        IEnumerable<T> Get(QueryContext queryContext);

        T Get(int id);

        void Update(T entity);

        void Create(T entity);

        void Delete(T entity);
    }
}