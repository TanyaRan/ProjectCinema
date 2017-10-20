namespace TRan.CinemaUniverse.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddToWeekOfferCollectionMovies : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Movies", new[] { "Title" });
            AddColumn("dbo.Movies", "WeekOffer_Id", c => c.Guid());
            AlterColumn("dbo.Movies", "Description", c => c.String(nullable: false, maxLength: 2500));
            AlterColumn("dbo.Movies", "ImageUrl", c => c.String(nullable: false, maxLength: 300));
            AlterColumn("dbo.Movies", "Award", c => c.String(maxLength: 250));
            AlterColumn("dbo.Movies", "FilmingStory", c => c.String(maxLength: 3000));
            CreateIndex("dbo.Movies", "WeekOffer_Id");
            AddForeignKey("dbo.Movies", "WeekOffer_Id", "dbo.WeekOffers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "WeekOffer_Id", "dbo.WeekOffers");
            DropIndex("dbo.Movies", new[] { "WeekOffer_Id" });
            AlterColumn("dbo.Movies", "FilmingStory", c => c.String(maxLength: 1000));
            AlterColumn("dbo.Movies", "Award", c => c.String(maxLength: 100));
            AlterColumn("dbo.Movies", "ImageUrl", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Movies", "Description", c => c.String(nullable: false, maxLength: 1000));
            DropColumn("dbo.Movies", "WeekOffer_Id");
            CreateIndex("dbo.Movies", "Title", unique: true);
        }
    }
}
