using AutoMapper;
using MyNote.Dtos;
using MyNote.Entities;
using MyNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyNote.App_Start
{
    public class AutoMapperConfiguration
    {
        public static IMapper ConfigureMapper()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Event, EventFormDto>();
                cfg.CreateMap<EventFormDto, Event>();
                cfg.CreateMap<Event, ShowEventViewModel>();
            });
            var mapper = configuration.CreateMapper();
            return mapper;
        }
    }
}