using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyNote.Dtos;
using MyNote.Models;
using MyNote.Repositories;
using MyNote.Entities;
using MyNote.Infrastructure;
using Microsoft.AspNet.Identity;
using System.IO;
using System.Configuration;

namespace MyNote.Services
{
    public class EventService : IEventService
    {
        private IEventsRepository _eventsRepository;
        private IMappingInfrastructure _mappingInfrastructure;
        private IAuthInfrastructure _authInfrastructure;

        public EventService(IEventsRepository eventsRepository, IMappingInfrastructure mappingInfrastructure, IAuthInfrastructure authInfrastructure) 
        {
            _eventsRepository = eventsRepository;
            _mappingInfrastructure = mappingInfrastructure;
            _authInfrastructure = authInfrastructure;
        }

        public void DeleteEvent(int id)
        {
            _eventsRepository.Delete(id);
        }

        public void EditEvent(EventFormDto eventFormDto)
        {
            var @event = _mappingInfrastructure.MapEventFormDtoToEvent(eventFormDto);
            @event.UserId = _authInfrastructure.GetCurrentUserId();
            _eventsRepository.Edit(@event);
            MovePhotosFromTempToDest(eventFormDto.PhotoNames);
        }

        public EventFormViewModel GetEventById(int id)
        {
            var @event = _eventsRepository.GetEventById(id);

            if (@event.UserId != _authInfrastructure.GetCurrentUserId())
            {
                return null;
            }

            var eventFormViewModel = _mappingInfrastructure.MapEventToEventFormViewModel(@event);
            return eventFormViewModel;
        }

        public EventFormViewModel GetEventFormViewModel()
        {
            return new EventFormViewModel();
        }

        public List<ShowEventViewModel> GetShowEventViewModelList()
        {
            var userId = _authInfrastructure.GetCurrentUserId();
            var eventList = _eventsRepository.GetCurrentUserEventList(userId);
            var showEventViewModelList = eventList.Select(x =>
            {
                ShowEventViewModel showEventViewModel = _mappingInfrastructure.MapEventToShowEventFormViewModel(x);
                return showEventViewModel;
            }).ToList();

            return showEventViewModelList;
        }

        public int InsertEventAndReturnEventId(EventFormDto eventFormDto)
        {
            var @event = _mappingInfrastructure.MapEventFormDtoToEvent(eventFormDto);
            @event.UserId = _authInfrastructure.GetCurrentUserId();

            int eventId = _eventsRepository.InsertAndReturnId(@event);
            MovePhotosFromTempToDest(eventFormDto.PhotoNames);

            return eventId;
        }

        public void MovePhotosFromTempToDest(List<string> PhotoNames)
        {
            foreach (var photoName in PhotoNames)
            {
                if (File.Exists(ConfigurationManager.AppSettings["tempImageDirectoryPath"] + "//" + photoName))
                {
                    File.Move(ConfigurationManager.AppSettings["tempImageDirectoryPath"] + "//" + photoName, ConfigurationManager.AppSettings["imageDirectoryPath"] + "//" + photoName);
                }
            }
        }
    }
}