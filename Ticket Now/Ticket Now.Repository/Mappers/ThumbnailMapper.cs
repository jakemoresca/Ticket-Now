using Ticket_Now.Repository.Dtos;
using Ticket_Now.Repository.Models;

namespace Ticket_Now.Repository.Mappers
{
    public class ThumbnailMapper : IThumbnailMapper
    {
        public ThumbnailDto ToDto(Thumbnail model)
        {
            return new ThumbnailDto
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                ExtensionName = model.ExtensionName,
                Content = model.Content
            };
        }

        public Thumbnail ToModel(ThumbnailDto dto)
        {
            return new Thumbnail
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
                ExtensionName = dto.ExtensionName,
                Content = dto.Content
            };
        }
    }
}
