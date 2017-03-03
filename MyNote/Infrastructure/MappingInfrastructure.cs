using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyNote.Dtos;
using MyNote.Entities;
using MyNote.Models;

namespace MyNote.Infrastructure
{
    public class MappingInfrastructure : IMappingInfrastructure
    {
        private IMapper _mapper;

        public MappingInfrastructure(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Event MapEventFormDtoToEvent(EventFormDto eventFormDto)
        {
            var @event = _mapper.Map<EventFormDto, Event>(eventFormDto);
            return @event;
        }

        public EventFormDto MapEventToEventFormDto(Event @event)
        {
            var eventFormDto = _mapper.Map<Event, EventFormDto>(@event);
            return eventFormDto;
        }

        public EventFormViewModel MapEventToEventFormViewModel(Event @event)
        {
            var eventFormViewModel = new EventFormViewModel()
            {
                EventFormDto = MapEventToEventFormDto(@event)
            };
            return eventFormViewModel;
        }

        public ShowEventViewModel MapEventToShowEventFormViewModel(Event @event)
        {
            var showEventViewModel = _mapper.Map<Event, ShowEventViewModel>(@event);
            return showEventViewModel;
        }
    }
}