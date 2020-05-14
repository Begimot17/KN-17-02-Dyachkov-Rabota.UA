namespace Kursach_Web_Dyachkov.Dal.CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Announcements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Price = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Surname = c.String(),
                        Name = c.String(),
                        Age = c.Int(nullable: false),
                        Email = c.String(),
                        NumberPhone = c.String(),
                        Password = c.String(),
                        Summary = c.String(),
                        ProfessionId = c.Int(nullable: false),
                        RegionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Professions", t => t.ProfessionId, cascadeDelete: true)
                .ForeignKey("dbo.Regions", t => t.RegionId, cascadeDelete: true)
                .Index(t => t.ProfessionId)
                .Index(t => t.RegionId);
            
            CreateTable(
                "dbo.Professions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Regions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Announcements", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "RegionId", "dbo.Regions");
            DropForeignKey("dbo.Users", "ProfessionId", "dbo.Professions");
            DropForeignKey("dbo.Announcements", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Users", new[] { "RegionId" });
            DropIndex("dbo.Users", new[] { "ProfessionId" });
            DropIndex("dbo.Announcements", new[] { "UserId" });
            DropIndex("dbo.Announcements", new[] { "CategoryId" });
            DropTable("dbo.Regions");
            DropTable("dbo.Professions");
            DropTable("dbo.Users");
            DropTable("dbo.Categories");
            DropTable("dbo.Announcements");
        }
    }
}
