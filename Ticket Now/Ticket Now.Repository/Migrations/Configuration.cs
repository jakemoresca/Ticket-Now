using System;
using Microsoft.AspNet.Identity;
using System.Data.Entity.Migrations;
using Microsoft.AspNet.Identity.EntityFramework;
using Ticket_Now.Repository.Daos;
using Ticket_Now.Repository.Dtos;

namespace Ticket_Now.Repository.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            var passwordHasher = new PasswordHasher();

            context.Users.AddOrUpdate(new ApplicationUserDto
            {
                Id = "575a5d27-c1af-4ace-b643-e3f90e71f56c",
                Hometown = "Cainta",
                Email = "jmoresca@gmail.com",
                EmailConfirmed = false,
                PasswordHash = passwordHasher.HashPassword("1234"),
                SecurityStamp = "6fd7dd4a-a0ca-47dc-8863-05c5d9fa5139",
                UserName = "jmoresca@gmail.com",
                ZipCode = 1900
            });

            context.Users.AddOrUpdate(new ApplicationUserDto
            {
                Id = "E3C317FE-CB45-4B07-ABAF-78AC649A695E",
                Hometown = "Cainta",
                Email = "dummy@dummy.com",
                EmailConfirmed = false,
                PasswordHash = passwordHasher.HashPassword("1234"),
                SecurityStamp = "59EA4DD2-B4A0-4384-A971-CFA40FA0D181",
                UserName = "dummy@dummy.com",
                ZipCode = 1900
            });

            context.Roles.AddOrUpdate(new IdentityRole
            {
                Id = "2dcc73b8-5fd4-4142-8cea-a00d6377c8af",
                Name = "Administrator"
            });

            context.Roles.AddOrUpdate(new IdentityRole
            {
                Id = "4AF8F3E1-CB0F-43C4-80D1-830B497262B5",
                Name = "User"
            });

            context.Roles.AddOrUpdate(new IdentityRole
            {
                Id = "205391BA-40AC-4CA6-968B-D45981D8EF88",
                Name = "Event Manager"
            });

            context.Roles.AddOrUpdate(new IdentityRole
            {
                Id = "9B5D2739-38CC-4970-BD4F-480A8D8BFC4C",
                Name = "Facilities Manager"
            });

            context.Roles.AddOrUpdate(new IdentityRole
            {
                Id = "4C497DD4-A6A7-4F9B-B8D7-DE53FBE657A0",
                Name = "Reservation Officer"
            });

            context.Locations.AddOrUpdate(new LocationDto
            {
                Id = new Guid("1D206926-7F40-4314-AD5A-B1EE571BE3B5"),
                Deleted = false,
                Description = "Test Description",
                Name = "Test Location"
            });

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
