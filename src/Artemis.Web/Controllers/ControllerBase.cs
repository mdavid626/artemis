﻿using Artemis.Common;
using Artemis.Web.Models;
using Artemis.Web.ViewModels;
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
        private IViewModel<TModel> vm;
        private IMapper mapper;

        public ControllerBase(IViewModel<TModel> vm, IMapper mapper)
        {
            this.vm = vm;
            this.mapper = mapper;
        }

        public IHttpActionResult Get(string orderBy = null, string direction = null)
        {
            if (ModelState.IsValid)
            {
                var queryContext = CreateQueryContext(orderBy, direction);
                var entities = vm.Get(queryContext);
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
                var entity = vm.Get(id);
                if (entity == null)
                    return NotFound();
                return Ok(mapper.Map<TModelDto>(entity));
            }
            return BadRequest();
        }

        public IHttpActionResult Put(TModelDto dto)
        {
            if (ModelState.IsValid)
            {
                var entity = vm.Get(dto.Id);
                if (entity == null)
                    return NotFound();
                mapper.Map(dto, entity);
                vm.Update(entity);
                return Ok(mapper.Map<TModelDto>(entity));
            }
            return BadRequest();
        }

        public IHttpActionResult Post(TModelDto dto)
        {
            if (ModelState.IsValid)
            {
                var entity = mapper.Map<TModel>(dto);
                vm.Create(entity);
                return Ok(mapper.Map<TModelDto>(entity));
            }
            return BadRequest();
        }

        public IHttpActionResult Delete(TModelDto dto)
        {
            if (ModelState.IsValid)
            {
                var entity = vm.Get(dto.Id);
                if (entity == null)
                    return NotFound();
                vm.Delete(entity);
                return Ok();
            }
            return BadRequest();
        }

        private QueryContext CreateQueryContext(string orderBy, string direction)
        {
            var context = new QueryContext();
            context.SortBy = orderBy; // TODO: map to the internal name
            context.SortDescending = direction?.ToLower() == "desc";
            return context;
        }
    }
}