using Artemis.Common;
using Artemis.Web.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace Artemis.Web.Controllers
{
    public abstract class ControllerBase<TModel, TViewModel> : ApiController
        where TViewModel : class, IHasKey
    {
        private IRepository<TModel> repository;
        private IUnitOfWork unitOfWork;
        private IMapper mapper;

        public ControllerBase(IRepository<TModel> repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public IHttpActionResult Get(string orderBy = null, string direction = null)
        {
            if (ModelState.IsValid)
            {
                var entities = repository.Get(orderBy, direction);
                var container = new CollectionResult<TViewModel>()
                {
                    Entities = entities.Select(c => mapper.Map<TViewModel>(c))
                };
                return Ok(container);
            }
            return BadRequest();
        }

        public IHttpActionResult Get(int id)
        {
            if (ModelState.IsValid)
            {
                var entity = repository.Get(id);
                if (entity == null)
                    return NotFound();
                return Ok(mapper.Map<TViewModel>(entity));
            }
            return BadRequest();
        }

        public IHttpActionResult Put(TViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var entity = repository.Get(vm.Id);
                if (entity == null)
                    return NotFound();
                mapper.Map(vm, entity);
                repository.Update(entity);
                unitOfWork.Commit();
                return Ok(mapper.Map<TViewModel>(entity));
            }
            return BadRequest();
        }

        public IHttpActionResult Post(TViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var entity = mapper.Map<TModel>(vm);
                repository.Create(entity);
                unitOfWork.Commit();
                return Ok(mapper.Map<TViewModel>(entity));
            }
            return BadRequest();
        }

        public IHttpActionResult Delete(TViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var entity = repository.Get(vm.Id);
                if (entity == null)
                    return NotFound();
                repository.Delete(entity);
                unitOfWork.Commit();
                return Ok();
            }
            return BadRequest();
        }
    }
}