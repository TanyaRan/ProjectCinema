namespace TRan.CinemaUniverse.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeCommentsRelationship : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "ProjectionId", "dbo.Projections");
            DropIndex("dbo.Comments", new[] { "ProjectionId" });
            AlterColumn("dbo.Comments", "ProjectionId", c => c.Guid());
            CreateIndex("dbo.Comments", "ProjectionId");
            AddForeignKey("dbo.Comments", "ProjectionId", "dbo.Projections", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "ProjectionId", "dbo.Projections");
            DropIndex("dbo.Comments", new[] { "ProjectionId" });
            AlterColumn("dbo.Comments", "ProjectionId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Comments", "ProjectionId");
            AddForeignKey("dbo.Comments", "ProjectionId", "dbo.Projections", "Id", cascadeDelete: true);
        }
    }
}
