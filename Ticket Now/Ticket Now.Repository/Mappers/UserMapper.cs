using Microsoft.AspNet.Identity;
using System;
using Ticket_Now.Repository.Dtos;
using Ticket_Now.Repository.Models;

namespace Ticket_Now.Repository.Mappers
{
    public class UserMapper : IUserMapper
    {
        public ApplicationUserDto ToDto(UserModel model)
        {
            var pwHash = new PasswordHasher();

            return new ApplicationUserDto
            {
                UserName = model.UserName,
                PasswordHash = pwHash.HashPassword(model.Password),
                ZipCode = model.ZipCode,
                Hometown = model.HomeTown
            };
        }

        public UserModel ToModel(ApplicationUserDto dto)
        {
            return new UserModel
            {
                UserName = dto.UserName,
                ZipCode = dto.ZipCode,
                HomeTown = dto.Hometown
            };
        }
    }
}