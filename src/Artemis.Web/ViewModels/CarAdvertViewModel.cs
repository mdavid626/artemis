using Artemis.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Artemis.Web.ViewModels
{
    public class CarAdvertViewModel : ViewModelBase<CarAdvert>
    {
        public CarAdvertViewModel(IRepository<CarAdvert> repository, IUnitOfWork unitOfWork) 
            : base(repository, unitOfWork)
        {
        }
    }
}