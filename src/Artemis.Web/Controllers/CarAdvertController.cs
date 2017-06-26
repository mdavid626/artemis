using Artemis.Common;
using Artemis.Web.Models;
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
    public class CarAdvertController : ControllerBase<CarAdvert, CarAdvertViewModel>
    {
        public CarAdvertController(IRepository<CarAdvert> repository, IMapper mapper)
            : base(repository, mapper)
        {
            
        }
    }
}
