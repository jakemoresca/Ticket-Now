using System.Data.Entity.Migrations;
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

            context.Users.AddOrUpdate(new ApplicationUserDto
            {
                Id = "575a5d27-c1af-4ace-b643-e3f90e71f56c",
                Hometown = "Cainta",
                Email = "jmoresca@gmail.com",
                EmailConfirmed = false,
                PasswordHash ="AEwUF5CTBh1yKsTqZzbD22CwffWl7mXqksr4kDIISbZczUPmtUgfWMq5L4Ds/6L0HQ==",
                SecurityStamp = "6fd7dd4a-a0ca-47dc-8863-05c5d9fa5139",
                UserName = "jmoresca@gmail.com",
                ZipCode = 1900
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
