using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyNote.Entities;
using MyNote.Models;

namespace MyNote.Repositories
{
    public class EventsRepository : IEventsRepository
    {
        private readonly ApplicationDbContext _context;

        public EventsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Event> GetEventList()
        {
            var eventList =_context.Events.ToList();
            return eventList;
        }

        public void Insert(Event eventEntity)
        {
            _context.Events.Add(eventEntity);
            _context.SaveChanges();
        }
    }
}