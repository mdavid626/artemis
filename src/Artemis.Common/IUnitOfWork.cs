using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artemis.Common
{
    public interface IUnitOfWork
    {
        T ProvideContext<T>() where T : class;

        void Commit();
    }
}
