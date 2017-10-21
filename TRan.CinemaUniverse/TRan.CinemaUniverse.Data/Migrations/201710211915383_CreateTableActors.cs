namespace TRan.CinemaUniverse.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableActors : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "WeekOffer_Id", "dbo.WeekOffers");
            DropForeignKey("dbo.Movies", "GenreId", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "GenreId" });
            DropIndex("dbo.Movies", new[] { "WeekOffer_Id" });
            CreateTable(
                "dbo.Actors",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 150),
                        ImageUrl = c.String(nullable: false, maxLength: 300),
                        Filmography = c.String(maxLength: 3000),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsDeleted);
            
            CreateTable(
                "dbo.MovieActors",
                c => new
                    {
                        Movie_Id = c.Guid(nullable: false),
                        Actor_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Movie_Id, t.Actor_Id })
                .ForeignKey("dbo.Movies", t => t.Movie_Id, cascadeDelete: true)
                .ForeignKey("dbo.Actors", t => t.Actor_Id, cascadeDelete: true)
                .Index(t => t.Movie_Id)
                .Index(t => t.Actor_Id);
            
            AlterColumn("dbo.Movies", "GenreId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Movies", "GenreId");
            AddForeignKey("dbo.Movies", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
            DropColumn("dbo.Movies", "StarActor");
            DropColumn("dbo.Movies", "StarActress");
            DropColumn("dbo.Movies", "WeekOffer_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "WeekOffer_Id", c => c.Guid());
            AddColumn("dbo.Movies", "StarActress", c => c.String(maxLength: 100));
            AddColumn("dbo.Movies", "StarActor", c => c.String(maxLength: 100));
            DropForeignKey("dbo.Movies", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.MovieActors", "Actor_Id", "dbo.Actors");
            DropForeignKey("dbo.MovieActors", "Movie_Id", "dbo.Movies");
            DropIndex("dbo.MovieActors", new[] { "Actor_Id" });
            DropIndex("dbo.MovieActors", new[] { "Movie_Id" });
            DropIndex("dbo.Movies", new[] { "GenreId" });
            DropIndex("dbo.Actors", new[] { "IsDeleted" });
            AlterColumn("dbo.Movies", "GenreId", c => c.Guid());
            DropTable("dbo.MovieActors");
            DropTable("dbo.Actors");
            CreateIndex("dbo.Movies", "WeekOffer_Id");
            CreateIndex("dbo.Movies", "GenreId");
            AddForeignKey("dbo.Movies", "GenreId", "dbo.Genres", "Id");
            AddForeignKey("dbo.Movies", "WeekOffer_Id", "dbo.WeekOffers", "Id");
        }
    }
}
