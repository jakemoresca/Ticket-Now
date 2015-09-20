using Microsoft.AspNet.Identity.EntityFramework;
using Ticket_Now.Repository.Models;

namespace Ticket_Now.Repository.Mappers
{
    public interface IClaimMapper
    {
        Claim ToModel(IdentityUserClaim dto);
        IdentityUserClaim ToDto(Claim model);
    }
}
