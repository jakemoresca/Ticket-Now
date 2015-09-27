using Ticket_Now.Repository.Dtos;
using Ticket_Now.Repository.Models;

namespace Ticket_Now.Repository.Mappers
{
    public class LocationMapper : ILocationMapper
    {
        public LocationDto ToDto(Location model)
        {
            return new LocationDto
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Deleted = model.Deleted
            };
        }

        public Location ToModel(LocationDto dto)
        {
            return new Location
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
                Deleted = dto.Deleted
            };
        }
    }
}
