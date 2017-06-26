using Artemis.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artemis.Common
{
    public interface ICarAdvertRepository
    {
        CarAdvert Get(int id);

        IEnumerable<CarAdvert> Get();

        void Update(CarAdvert carAdvert);

        void Create(CarAdvert carAdvert);

        void Delete(CarAdvert carAdvert);
    }
}
