using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Ticket_Now.Repository.Daos;
using Ticket_Now.Repository.Dtos;

namespace Ticket_Now.Repository.Repositories
{
    public class ScheduleRepository : IRepository<ScheduleDto>
    {
        private readonly ApplicationDbContext _ctx;

        public ScheduleRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public ScheduleDto Add(ScheduleDto entity)
        {
            var newSchedule = _ctx.EventSchedules.Add(entity);
            _ctx.SaveChanges();
            return newSchedule;
        }

        public bool Delete(string id)
        {
            var scheduleToDelete = FindById(id);
            _ctx.EventSchedules.Remove(scheduleToDelete);
            _ctx.SaveChanges();
            return true;
        }

        public ScheduleDto FindById(string id)
        {
            return _ctx.EventSchedules.FirstOrDefault(es => es.Id == new Guid(id));
        }

        public ScheduleDto FindByName(string name)
        {
            return _ctx.EventSchedules.FirstOrDefault(es => es.Name == name);
        }

        public List<ScheduleDto> GetAll()
        {
            return _ctx.EventSchedules.ToList();
        }

        public ScheduleDto Update(ScheduleDto updatedEntity)
        {
            _ctx.Entry(updatedEntity).State = EntityState.Modified;
            _ctx.SaveChanges();
            return updatedEntity;
        }
    }
}
