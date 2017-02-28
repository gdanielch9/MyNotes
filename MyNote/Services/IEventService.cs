using MyNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyNote.Dtos;

namespace MyNote.Services
{
    public interface IEventService
    {
        EventFormViewModel GetEventFormViewModel();
        void InsertEvent(EventFormDto eventFormDto);
        List<ShowEventViewModel> GetShowEventViewModelList();
        void deleteEvent(int id);
        EventFormViewModel GetEventById(int id);
        void EditEvent(EventFormDto eventFormDto);
    }
}
