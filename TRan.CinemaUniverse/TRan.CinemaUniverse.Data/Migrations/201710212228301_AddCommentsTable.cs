namespace TRan.CinemaUniverse.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCommentsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        AuthorId = c.String(maxLength: 128),
                        Title = c.String(nullable: false, maxLength: 50),
                        Content = c.String(nullable: false, maxLength: 800),
                        ProjectionId = c.Guid(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AuthorId)
                .ForeignKey("dbo.Projections", t => t.ProjectionId, cascadeDelete: true)
                .Index(t => t.AuthorId)
                .Index(t => t.ProjectionId)
                .Index(t => t.IsDeleted);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "ProjectionId", "dbo.Projections");
            DropForeignKey("dbo.Comments", "AuthorId", "dbo.AspNetUsers");
            DropIndex("dbo.Comments", new[] { "IsDeleted" });
            DropIndex("dbo.Comments", new[] { "ProjectionId" });
            DropIndex("dbo.Comments", new[] { "AuthorId" });
            DropTable("dbo.Comments");
        }
    }
}
