using Artemis.Common;
using Artemis.Web.Models;
using Artemis.Web.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Artemis.Web.Controllers
{
    [EnableCors(origins: "*", headers: "*",  methods: "*")]
    public class CarAdvertController : ControllerBase<CarAdvert, CarAdvertDto>
    {
        public CarAdvertController(IViewModel<CarAdvert> vm, IMapper mapper)
            : base(vm, mapper)
        {
            
        }
    }
}
