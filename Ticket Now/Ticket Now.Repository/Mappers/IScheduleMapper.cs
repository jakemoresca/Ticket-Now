using Ticket_Now.Repository.Dtos;
using Ticket_Now.Repository.Models;

namespace Ticket_Now.Repository.Mappers
{
    public interface IScheduleMapper
    {
        Schedule ToModel(ScheduleDto dto);
        ScheduleDto ToDto(Schedule model);
    }
}