﻿using Artemis.Common;
using Artemis.Web.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Artemis.Web
{
    public static class AutoMapperConfig
    {
        public static IMapper Create()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CarAdvert, CarAdvertDto>()
                   .ForMember(d => d.New, opt => opt.MapFrom(src => src.IsNew))
                   .ForMember(d => d.Fuel, opt => opt.MapFrom(src => src.Fuel.ToString().ToLower()))
                   .ForMember(d => d.FirstRegistration, opt => opt.MapFrom(src => src.FirstRegistration.HasValue ? src.FirstRegistration.Value.Date : (DateTime?)null));
                cfg.CreateMap<CarAdvertDto, CarAdvert>()
                   .ForMember(d => d.IsNew, opt => opt.MapFrom(src => src.New))
                   .ForMember(d => d.Fuel, opt => opt.MapFrom(src => Enum.Parse(typeof(FuelType), src.Fuel, true)))
                   .ForMember(d => d.FirstRegistration, opt => opt.MapFrom(src => src.FirstRegistration.HasValue ? src.FirstRegistration.Value.Date : (DateTime?)null));
            });
            return config.CreateMapper();
        }
    }
}