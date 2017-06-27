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
    public abstract class ControllerBase<TModel, TModelDto> : ApiController
        where TModelDto : class, IHasKey
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
                var queryContext = CreateQueryContext(orderBy, direction);
                var entities = repository.Get(queryContext);
                var container = new CollectionResultDto<TModelDto>()
                {
                    Entities = entities.Select(c => mapper.Map<TModelDto>(c))
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
                return Ok(mapper.Map<TModelDto>(entity));
            }
            return BadRequest();
        }

        public IHttpActionResult Put(TModelDto vm)
        {
            if (ModelState.IsValid)
            {
                var entity = repository.Get(vm.Id);
                if (entity == null)
                    return NotFound();
                mapper.Map(vm, entity);
                repository.Update(entity);
                unitOfWork.Commit();
                return Ok(mapper.Map<TModelDto>(entity));
            }
            return BadRequest();
        }

        public IHttpActionResult Post(TModelDto vm)
        {
            if (ModelState.IsValid)
            {
                var entity = mapper.Map<TModel>(vm);
                repository.Create(entity);
                unitOfWork.Commit();
                return Ok(mapper.Map<TModelDto>(entity));
            }
            return BadRequest();
        }

        public IHttpActionResult Delete(TModelDto vm)
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

        public QueryContext CreateQueryContext(string orderBy, string direction)
        {
            var context = new QueryContext();
            context.SortBy = orderBy; // TODO: map to the internal name
            context.SortDescending = direction?.ToLower() == "desc";
            return context;
        }
    }
}