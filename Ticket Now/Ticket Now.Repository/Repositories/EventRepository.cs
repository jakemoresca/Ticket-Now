using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Ticket_Now.Repository.Daos;
using Ticket_Now.Repository.Dtos;

namespace Ticket_Now.Repository.Repositories
{
    public class EventRepository : IRepository<EventDto>
    {
        private readonly ApplicationDbContext _ctx;

        public EventRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public EventDto Add(EventDto entity)
        {
            var newEvent = _ctx.Events.Add(entity);
            _ctx.SaveChanges();
            return newEvent;
        }

        public bool Delete(string id)
        {
            var eventToDelete = FindById(id);
            _ctx.Events.Remove(eventToDelete);
            _ctx.SaveChanges();
            return true;
        }

        public EventDto FindById(string id)
        {
            return _ctx.Events.FirstOrDefault(e => e.Id == new Guid(id));
        }

        public EventDto FindByName(string name)
        {
            return _ctx.Events.FirstOrDefault(e => e.Name == name);
        }

        public List<EventDto> GetAll()
        {
            return _ctx.Events.ToList();
        }

        public EventDto Update(EventDto updatedEntity)
        {
            _ctx.Entry(updatedEntity).State = EntityState.Modified;
            _ctx.SaveChanges();
            return updatedEntity;
        }
    }
}
