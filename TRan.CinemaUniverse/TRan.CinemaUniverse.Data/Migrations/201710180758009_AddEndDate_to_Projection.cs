namespace TRan.CinemaUniverse.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddEndDate_to_Projection : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Projections", "MovieId", "dbo.Movies");
            DropIndex("dbo.Projections", new[] { "MovieId" });
            AddColumn("dbo.WeekOffers", "EndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Projections", "MovieId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Projections", "MovieId");
            AddForeignKey("dbo.Projections", "MovieId", "dbo.Movies", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projections", "MovieId", "dbo.Movies");
            DropIndex("dbo.Projections", new[] { "MovieId" });
            AlterColumn("dbo.Projections", "MovieId", c => c.Guid());
            DropColumn("dbo.WeekOffers", "EndDate");
            CreateIndex("dbo.Projections", "MovieId");
            AddForeignKey("dbo.Projections", "MovieId", "dbo.Movies", "Id");
        }
    }
}
