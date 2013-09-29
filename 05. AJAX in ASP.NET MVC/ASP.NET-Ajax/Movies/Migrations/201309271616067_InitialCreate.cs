namespace Movies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Age = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Year = c.DateTime(nullable: false),
                        Director = c.String(),
                        StudioAddress = c.String(),
                        Studio = c.String(),
                        LeadingFemaleRole_Id = c.Int(),
                        LeadingMaleRole_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Actors", t => t.LeadingFemaleRole_Id)
                .ForeignKey("dbo.Actors", t => t.LeadingMaleRole_Id)
                .Index(t => t.LeadingFemaleRole_Id)
                .Index(t => t.LeadingMaleRole_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "LeadingMaleRole_Id", "dbo.Actors");
            DropForeignKey("dbo.Movies", "LeadingFemaleRole_Id", "dbo.Actors");
            DropIndex("dbo.Movies", new[] { "LeadingMaleRole_Id" });
            DropIndex("dbo.Movies", new[] { "LeadingFemaleRole_Id" });
            DropTable("dbo.Movies");
            DropTable("dbo.Actors");
        }
    }
}
