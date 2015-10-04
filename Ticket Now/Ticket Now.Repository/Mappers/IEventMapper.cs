using Ticket_Now.Repository.Dtos;
using Ticket_Now.Repository.Models;

namespace Ticket_Now.Repository.Mappers
{
    public interface IEventMapper
    {
        Event ToModel(EventDto dto);
        EventDto ToDto(Event model);
    }
}