using Ticket_Now.Repository.Dtos;
using Ticket_Now.Repository.Models;

namespace Ticket_Now.Repository.Mappers
{
    public class ScheduleMapper : IScheduleMapper
    {
        public Schedule ToModel(ScheduleDto dto)
        {
            return new Schedule
            {
                Id = dto.Id,
                Name = dto.Name,
                Start = dto.Start,
                End = dto.End,
                Event = new Event {Id = dto.EventId},
                Location = new Location {Id = dto.LocationId}
            };
        }

        public ScheduleDto ToDto(Schedule model)
        {
            return new ScheduleDto
            {
                Id = model.Id,
                Name = model.Name,
                Start = model.Start,
                End = model.End,
                EventId = model.Event.Id,
                LocationId = model.Location.Id
            };
        }
    }
}
