using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Ticket_Now.Repository.Dtos;
using Ticket_Now.Repository.Models;

namespace Ticket_Now.Repository.Mappers
{
    public class UserMapper : IUserMapper
    {
        private readonly IClaimMapper _claimMapper;

        public UserMapper(IClaimMapper claimMapper)
        {
            _claimMapper = claimMapper;
        }

        public ApplicationUserDto ToDto(UserModel model)
        {
            var pwHash = new PasswordHasher();

            var user = new ApplicationUserDto
            {
                UserName = model.UserName,
                PasswordHash = pwHash.HashPassword(model.Password),
                ZipCode = model.ZipCode,
                Hometown = model.HomeTown,
                RoleId = model.Role.Id
            };

            model.Claims.ForEach(c => user.Claims.Add(_claimMapper.ToDto(c)));

            return user;
        }

        public UserModel ToModel(ApplicationUserDto dto)
        {
            var identityUserRole = dto.Roles.FirstOrDefault() ?? new IdentityUserRole();
            return new UserModel
            {
                UserName = dto.UserName,
                ZipCode = dto.ZipCode,
                HomeTown = dto.Hometown,
                Role = new Role {Id = identityUserRole.RoleId},
                Claims = dto.Claims.Select(c => _claimMapper.ToModel(c)).ToList()
            };
        }
    }
}