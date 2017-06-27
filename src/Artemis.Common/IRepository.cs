using Artemis.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artemis.Common
{
    public interface IRepository<T>
    {
        T Get(int id);

        IEnumerable<T> Get(QueryContext context = null);

        void Update(T carAdvert);

        void Create(T carAdvert);

        void Delete(T carAdvert);
    }
}
