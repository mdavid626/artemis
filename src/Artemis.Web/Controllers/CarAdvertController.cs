using Artemis.Common;
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
        private ICarAdvertRepository repository;

        public CarAdvertController(ICarAdvertRepository repository)
        {
            this.repository = repository;
        }

        public IHttpActionResult Get()
        {
            if (ModelState.IsValid)
            {
                var carAdverts = repository.Get();
                var container = new
                {
                    Adverts = carAdverts.Select(c => c.MapToVm())
                };
                return Ok(container);
            }
            return BadRequest();
        }

        public IHttpActionResult Get(int id)
        {
            if (ModelState.IsValid)
            {
                var carAdvert = repository.Get(id);
                if (carAdvert == null)
                    return NotFound();
                return Ok(carAdvert.MapToVm());
            }
            return BadRequest();
        }

        public IHttpActionResult Put(CarAdvertViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var carAdvert = repository.Get(vm.Id);
                if (carAdvert == null)
                    return NotFound();
                if (vm.MapTo(carAdvert))
                {
                    repository.Update(carAdvert);   
                    return Ok(carAdvert.MapToVm());
                }
            }
            return BadRequest();
        }

        public IHttpActionResult Post(CarAdvertViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var carAdvert = new CarAdvert();
                if (vm.MapTo(carAdvert))
                {
                    repository.Create(carAdvert);
                    return Ok(carAdvert.MapToVm());
                }
            }
            return BadRequest();
        }

        public IHttpActionResult Delete(CarAdvertViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var carAdvert = repository.Get(vm.Id);
                if (carAdvert == null)
                    return NotFound();
                repository.Delete(carAdvert);
                return Ok();
            }
            return BadRequest();
        }
    }
}
