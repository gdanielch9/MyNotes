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

        public EventsController()       // TODO: IoC - Unity
        {
            _eventService = new EventService();
        }

        public ActionResult CreateEvent()
        {
            var viewModel = _eventService.GetEventFormViewModel();
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEvent([Bind(Prefix = "EventFormDto")] EventFormDto eventFormDto)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = _eventService.GetEventFormViewModel();
                viewModel.EventFormDto = eventFormDto;

            }

            _eventService.InsertEvent(eventFormDto);
            return RedirectToAction("Index","Home");
        }

        //public ActionResult Edit(int id)
        //{
        //    var viewModel = _eventService.GetEventEditViewModel(id);
        //    return View(viewModel);
        //}
    }
}