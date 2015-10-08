namespace Ticket_Now.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEventsAndSchedulesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        Duration = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EventSchedules",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                        EventId = c.Guid(nullable: false),
                        LocationId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.EventId, cascadeDelete: true)
                .ForeignKey("dbo.Locations", t => t.LocationId, cascadeDelete: true)
                .Index(t => t.EventId)
                .Index(t => t.LocationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EventSchedules", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.EventSchedules", "EventId", "dbo.Events");
            DropIndex("dbo.EventSchedules", new[] { "LocationId" });
            DropIndex("dbo.EventSchedules", new[] { "EventId" });
            DropTable("dbo.EventSchedules");
            DropTable("dbo.Events");
        }
    }
}
