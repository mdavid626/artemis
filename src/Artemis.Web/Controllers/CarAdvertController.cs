using Artemis.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Artemis.Web.Controllers
{
    [EnableCors(origins: "*", headers: "*",  methods: "*")]
    public class CarAdvertController : ApiController
    {
        public CarAdvertController()
        {
            
        }

        public IHttpActionResult Get()
        {
            return Ok();
        }

        public IHttpActionResult Get(int id)
        {
            return Ok();
        }

        public IHttpActionResult Post(CarAdvertViewModel carAdvert)
        {
            return Ok();
        }

        public IHttpActionResult Put(CarAdvertViewModel carAdvert)
        {
            return Ok();
        }

        public IHttpActionResult Delete(CarAdvertViewModel carAdvert)
        {
            return Ok();
        }
    }
}
