namespace TRan.CinemaUniverse.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CreateProjection : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "WeekOffer_Id", "dbo.WeekOffers");
            DropIndex("dbo.Movies", new[] { "WeekOffer_Id" });
            CreateTable(
                "dbo.Projections",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Day = c.DateTime(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        MovieId = c.String(),
                        LecturerId = c.String(maxLength: 128),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                        Movie_Id = c.Guid(),
                        WeekOffer_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.LecturerId)
                .ForeignKey("dbo.Movies", t => t.Movie_Id)
                .ForeignKey("dbo.WeekOffers", t => t.WeekOffer_Id)
                .Index(t => t.LecturerId)
                .Index(t => t.IsDeleted)
                .Index(t => t.Movie_Id)
                .Index(t => t.WeekOffer_Id);
            
            AddColumn("dbo.Movies", "Award", c => c.String(maxLength: 100));
            AddColumn("dbo.Movies", "FilmingStory", c => c.String(maxLength: 1000));
            AddColumn("dbo.Movies", "GenreId", c => c.String());
            CreateIndex("dbo.Genres", "Name", unique: true);
            DropColumn("dbo.Movies", "WeekOffer_Id");
            DropColumn("dbo.WeekOffers", "EndDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WeekOffers", "EndDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "WeekOffer_Id", c => c.Guid());
            DropForeignKey("dbo.Projections", "WeekOffer_Id", "dbo.WeekOffers");
            DropForeignKey("dbo.Projections", "Movie_Id", "dbo.Movies");
            DropForeignKey("dbo.Projections", "LecturerId", "dbo.AspNetUsers");
            DropIndex("dbo.Projections", new[] { "WeekOffer_Id" });
            DropIndex("dbo.Projections", new[] { "Movie_Id" });
            DropIndex("dbo.Projections", new[] { "IsDeleted" });
            DropIndex("dbo.Projections", new[] { "LecturerId" });
            DropIndex("dbo.Genres", new[] { "Name" });
            DropColumn("dbo.Movies", "GenreId");
            DropColumn("dbo.Movies", "FilmingStory");
            DropColumn("dbo.Movies", "Award");
            DropTable("dbo.Projections");
            CreateIndex("dbo.Movies", "WeekOffer_Id");
            AddForeignKey("dbo.Movies", "WeekOffer_Id", "dbo.WeekOffers", "Id");
        }
    }
}
