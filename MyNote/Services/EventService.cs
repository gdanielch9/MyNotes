using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyNote.Dtos;
using MyNote.Models;
using MyNote.Repositories;
using MyNote.Entities;
using MyNote.Infrastructure;

namespace MyNote.Services
{
    public class EventService : IEventService
    {
        private IEventsRepository _eventsRepository;
        private IMappingInfrastructure _mappingInfrastructure;

        public EventService(IEventsRepository eventsRepository, IMappingInfrastructure mappingInfrastructure) 
        {
            _eventsRepository = eventsRepository;
            _mappingInfrastructure = mappingInfrastructure;
        }

        public void deleteEvent(int id)
        {
            _eventsRepository.Delete(id);
        }

        public void EditEvent(EventFormDto eventFormDto)
        {
            var @event = _mappingInfrastructure.MapEventFormDtoToEvent(eventFormDto);
            _eventsRepository.Edit(@event);
        }

        public EventFormViewModel GetEventById(int id)
        {
            var @event = _eventsRepository.GetEventById(id);
            var eventFormViewModel = _mappingInfrastructure.MapEventToEventFormViewModel(@event);
            return eventFormViewModel;
        }

        public EventFormViewModel GetEventFormViewModel()
        {
            return new EventFormViewModel();
        }

        public List<ShowEventViewModel> GetShowEventViewModelList()
        {
            var eventList = _eventsRepository.GetEventList();
            var showEventViewModelList = eventList.Select(x =>
            {
                ShowEventViewModel showEventViewModel = _mappingInfrastructure.MapEventToShowEventFormViewModel(x);
                return showEventViewModel;
            }).ToList();

            return showEventViewModelList;
        }

        public void InsertEvent(EventFormDto eventFormDto)
        {
            var @event = _mappingInfrastructure.MapEventFormDtoToEvent(eventFormDto);
            _eventsRepository.Insert(@event);
        }
    }
}