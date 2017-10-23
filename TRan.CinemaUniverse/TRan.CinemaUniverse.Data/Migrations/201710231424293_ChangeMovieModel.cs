namespace TRan.CinemaUniverse.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeMovieModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MovieActors", "Movie_Id", "dbo.Movies");
            DropForeignKey("dbo.MovieActors", "Actor_Id", "dbo.Actors");
            DropIndex("dbo.MovieActors", new[] { "Movie_Id" });
            DropIndex("dbo.MovieActors", new[] { "Actor_Id" });
            AddColumn("dbo.Movies", "StarActorId", c => c.Guid());
            AddColumn("dbo.Movies", "StarActressId", c => c.Guid());
            AddColumn("dbo.Movies", "Actor_Id", c => c.Guid());
            CreateIndex("dbo.Movies", "StarActorId");
            CreateIndex("dbo.Movies", "StarActressId");
            CreateIndex("dbo.Movies", "Actor_Id");
            AddForeignKey("dbo.Movies", "StarActorId", "dbo.Actors", "Id");
            AddForeignKey("dbo.Movies", "StarActressId", "dbo.Actors", "Id");
            AddForeignKey("dbo.Movies", "Actor_Id", "dbo.Actors", "Id");
            DropTable("dbo.MovieActors");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MovieActors",
                c => new
                    {
                        Movie_Id = c.Guid(nullable: false),
                        Actor_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Movie_Id, t.Actor_Id });
            
            DropForeignKey("dbo.Movies", "Actor_Id", "dbo.Actors");
            DropForeignKey("dbo.Movies", "StarActressId", "dbo.Actors");
            DropForeignKey("dbo.Movies", "StarActorId", "dbo.Actors");
            DropIndex("dbo.Movies", new[] { "Actor_Id" });
            DropIndex("dbo.Movies", new[] { "StarActressId" });
            DropIndex("dbo.Movies", new[] { "StarActorId" });
            DropColumn("dbo.Movies", "Actor_Id");
            DropColumn("dbo.Movies", "StarActressId");
            DropColumn("dbo.Movies", "StarActorId");
            CreateIndex("dbo.MovieActors", "Actor_Id");
            CreateIndex("dbo.MovieActors", "Movie_Id");
            AddForeignKey("dbo.MovieActors", "Actor_Id", "dbo.Actors", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MovieActors", "Movie_Id", "dbo.Movies", "Id", cascadeDelete: true);
        }
    }
}
