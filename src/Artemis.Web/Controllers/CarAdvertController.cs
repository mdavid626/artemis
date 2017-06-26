﻿using Artemis.Common;
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
                    Adverts = carAdverts
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
                return Ok(carAdvert);
            }
            return BadRequest();
        }

        public IHttpActionResult Post(CarAdvertViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var carAdvert = vm.Map();
                repository.Update(carAdvert);
                return Ok(carAdvert);
            }
            return BadRequest();
        }

        public IHttpActionResult Put(CarAdvertViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var carAdvert = vm.Map();
                repository.Create(carAdvert);
                return Ok(carAdvert);
            }
            return BadRequest();
        }

        public IHttpActionResult Delete(CarAdvertViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var carAdvert = vm.Map();
                repository.Delete(carAdvert);
                return Ok();
            }
            return BadRequest();
        }
    }
}
