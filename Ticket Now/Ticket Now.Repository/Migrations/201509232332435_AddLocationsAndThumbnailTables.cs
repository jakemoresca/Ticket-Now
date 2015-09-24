namespace Ticket_Now.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLocationsAndThumbnailTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 200),
                        Description = c.String(),
                        ThumbnailId = c.Guid(),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Thumbnails", t => t.ThumbnailId)
                .Index(t => t.ThumbnailId);
            
            CreateTable(
                "dbo.Thumbnails",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 200),
                        Description = c.String(),
                        ExtensionName = c.String(nullable: false, maxLength: 10),
                        Content = c.Binary(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetRoles", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Locations", "ThumbnailId", "dbo.Thumbnails");
            DropIndex("dbo.Locations", new[] { "ThumbnailId" });
            DropColumn("dbo.AspNetRoles", "Discriminator");
            DropTable("dbo.Thumbnails");
            DropTable("dbo.Locations");
        }
    }
}
