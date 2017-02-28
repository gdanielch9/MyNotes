using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyNote.Entities;
using MyNote.Models;
using System.Data.Entity;

namespace MyNote.Repositories
{
    public class EventsRepository : IEventsRepository
    {
        private readonly ApplicationDbContext _context;

        public EventsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            var eventToRemove = _context.Events.Find(id);
            eventToRemove.IsDeleted = true;
            _context.SaveChanges();
        }

        public void Edit(Event @event)
        {
            _context.Entry(@event).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public Event GetEventById(int id)
        {
            var @event = _context.Events.Where(x=> x.IsDeleted != true).Single(x => x.Id == id);
            return @event;
        }

        public List<Event> GetEventList()
        {
            var eventList =_context.Events.Where(x=>x.IsDeleted != true).ToList();
            return eventList;
        }

        public void Insert(Event eventEntity)
        {
            _context.Events.Add(eventEntity);
            _context.SaveChanges();
        }
    }
}