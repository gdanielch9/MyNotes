using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyNote.Dtos;
using MyNote.Models;
using MyNote.Repositories;
using MyNote.Entities;

namespace MyNote.Services
{
    public class EventService : IEventService
    {
        private IEventsRepository _eventsRepository;

        public EventService(IEventsRepository eventsRepository) 
        {
            _eventsRepository = eventsRepository;
        }

        public void deleteEvent(int id)
        {
            _eventsRepository.Delete(id);
        }

        public void EditEvent(EventFormDto eventFormDto)
        {
            var @event = new Event()
            {
                Id = eventFormDto.Id,
                Title = eventFormDto.Title,
                Text = eventFormDto.Text,
                Date = eventFormDto.Date
                // Photos = eventFormDto 
            };
            _eventsRepository.Edit(@event);
        }

        public EventFormViewModel GetEventById(int id)
        {
            var @event = _eventsRepository.GetEventById(id);
            var eventFormViewModel = new EventFormViewModel()
            {
                EventFormDto = new EventFormDto()
                {
                    Id = @event.Id,
                    Title = @event.Title,
                    Text = @event.Text,
                    Date = @event.Date,
                    PhotoPaths = @event.Photos.Select(x => x.Path).ToList()
                }
            };

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
                ShowEventViewModel showEventViewModel = new ShowEventViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Text = x.Text,
                    Date = x.Date,
                    Photos = x.Photos,
                };
                return showEventViewModel;
            }).ToList();

            return showEventViewModelList;
        }

        public void InsertEvent(EventFormDto eventFormDto)
        {
            var @event = new Event
            {
                Title = eventFormDto.Title,
                Text = eventFormDto.Text,
                Date = eventFormDto.Date
            };
            _eventsRepository.Insert(@event);
        }
    }
}