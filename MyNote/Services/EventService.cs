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
            var eventEntity = new Event
            {
                Title = eventFormDto.Title,
                Text = eventFormDto.Text,
                Date = eventFormDto.Date
            };
            _eventsRepository.Insert(eventEntity);
        }
    }
}