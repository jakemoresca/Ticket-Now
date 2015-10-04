using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using Ticket_Now.Repository.Dtos;

namespace Ticket_Now.Repository.Daos
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUserDto>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<LocationDto> Locations { get; set; }
        public DbSet<ThumbnailDto> ThumbnailDto { get; set; }
        public DbSet<EventDto> Events { get; set; }
        public DbSet<ScheduleDto> EventSchedules { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}