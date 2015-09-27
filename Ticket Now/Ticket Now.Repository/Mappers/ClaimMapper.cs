using Microsoft.AspNet.Identity.EntityFramework;
using Ticket_Now.Repository.Models;

namespace Ticket_Now.Repository.Mappers
{
    public class ClaimMapper : IClaimMapper
    {
        public Claim ToModel(IdentityUserClaim dto)
        {
            return new Claim
            {
                Id = dto.Id,
                Type = dto.ClaimType,
                Value = dto.ClaimValue
            };
        }

        public IdentityUserClaim ToDto(Claim model)
        {
            return new IdentityUserClaim
            {
                Id = model.Id,
                ClaimType = model.Type,
                ClaimValue = model.Value
            };
        }
    }
}
