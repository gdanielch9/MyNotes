using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyNote.Entities;

namespace MyNote.Repositories
{
    public interface IEventsRepository
    {
        void Insert(Event eventEntity);
        List<Event> GetCurrentUserEventList(string userId);
        void Delete(int id);
        Event GetEventById(int id);
        void Edit(Event @event);
    }
}
