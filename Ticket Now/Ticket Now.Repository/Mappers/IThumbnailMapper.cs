using Ticket_Now.Repository.Dtos;
using Ticket_Now.Repository.Models;

namespace Ticket_Now.Repository.Mappers
{
    public interface IThumbnailMapper
    {
        Thumbnail ToModel(ThumbnailDto dto);
        ThumbnailDto ToDto(Thumbnail model);
    }
}
