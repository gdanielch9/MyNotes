using MyNote.Dtos;
using MyNote.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyNote.Controllers
{
    public class EventsController : Controller
    {
        private readonly IEventService _eventService;

        public EventsController(IEventService eventService)
        {
            _eventService = eventService;
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

            _eventService.InsertEvent(eventFormDto);
            return RedirectToAction("ShowEvents", "Events");
        }

        public ActionResult ShowEvents()
        {
            var eventViewModelList = _eventService.GetShowEventViewModelList();
            return View(eventViewModelList);
        }
    }
}