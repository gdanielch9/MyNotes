using MyNote.Dtos;
using MyNote.Entities;
using MyNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyNote.Infrastructure
{
    public interface IMappingInfrastructure
    {
        EventFormDto MapEventToEventFormDto(Event @event);
        Event MapEventFormDtoToEvent(EventFormDto eventFormDto);
        EventFormViewModel MapEventToEventFormViewModel(Event @event);
        ShowEventViewModel MapEventToShowEventFormViewModel(Event @event);
    }
}