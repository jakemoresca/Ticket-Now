using System;
using Ticket_Now.Repository.Dtos;
using Ticket_Now.Repository.Models;

namespace Ticket_Now.Repository.Mappers
{
    public class EventMapper : IEventMapper
    {
        public Event ToModel(EventDto dto)
        {
            return new Event
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
                Duration = TimeSpan.FromSeconds(dto.Duration)
            };
        }

        public EventDto ToDto(Event model)
        {
            return new EventDto
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Duration = Convert.ToInt32(model.Duration.TotalSeconds)
            };
        }
    }
}
