using MyNote.Dtos;
using MyNote.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyNote.Controllers
{
    [Authorize]
    public class EventsController : Controller
    {
        private readonly IEventService _eventService;
        private readonly IPhotosService _photoService;

        public EventsController(IEventService eventService, IPhotosService photoService)
        {
            _eventService = eventService;
            _photoService = photoService;
        }

        public ActionResult CreateEvent()
        {
            var eventFormViewModel = _eventService.GetEventFormViewModel();
            return View(eventFormViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEvent([Bind(Prefix = "EventFormDto")] EventFormDto eventFormDto)
        {
            if (!ModelState.IsValid)
            {
                var eventFormVewModel = _eventService.GetEventFormViewModel();
                eventFormVewModel.EventFormDto = eventFormDto;
            }

            int eventId = _eventService.InsertEventAndReturnEventId(eventFormDto);
            _photoService.InsertPhotos(eventId, eventFormDto.PhotoNames);

            return RedirectToAction("ShowEvents");
        }

        public ActionResult DeleteEvent(int id)
        {
            _eventService.DeleteEvent(id);
            return RedirectToAction("ShowEvents");
        }

        public ActionResult EditEvent(int id)
        {
            var eventFormViewModel = _eventService.GetEventById(id);

            if (eventFormViewModel == null)
            {
                return new HttpNotFoundResult();
            }

            return View(eventFormViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditEvent(EventFormDto eventFormDto)
        {
            if (!ModelState.IsValid)
            {
                var eventFormViewModel = _eventService.GetEventFormViewModel();
                eventFormViewModel.EventFormDto = eventFormDto;

                return View(eventFormViewModel);
            }

            _eventService.EditEvent(eventFormDto);
            return RedirectToAction("ShowEvents");
        }

        public ActionResult ShowEvents()
        {
            var eventViewModelList = _eventService.GetShowEventViewModelList();
            return View(eventViewModelList);
        }
    }
}