namespace TRan.CinemaUniverse.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class ChangeProjection_ChangeMovie : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Projections", "LecturerId", "dbo.AspNetUsers");
            DropIndex("dbo.Movies", new[] { "Genre_Id" });
            DropIndex("dbo.Projections", new[] { "LecturerId" });
            DropIndex("dbo.Projections", new[] { "Movie_Id" });
            DropColumn("dbo.Movies", "GenreId");
            DropColumn("dbo.Projections", "MovieId");
            RenameColumn(table: "dbo.Movies", name: "Genre_Id", newName: "GenreId");
            RenameColumn(table: "dbo.Projections", name: "Movie_Id", newName: "MovieId");
            AddColumn("dbo.Projections", "Lecturer_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Movies", "GenreId", c => c.Guid());
            AlterColumn("dbo.Projections", "MovieId", c => c.Guid());
            AlterColumn("dbo.Projections", "LecturerId", c => c.Guid());
            CreateIndex("dbo.Movies", "Title", unique: true);
            CreateIndex("dbo.Movies", "GenreId");
            CreateIndex("dbo.Projections", "MovieId");
            CreateIndex("dbo.Projections", "Lecturer_Id");
            AddForeignKey("dbo.Projections", "Lecturer_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projections", "Lecturer_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Projections", new[] { "Lecturer_Id" });
            DropIndex("dbo.Projections", new[] { "MovieId" });
            DropIndex("dbo.Movies", new[] { "GenreId" });
            DropIndex("dbo.Movies", new[] { "Title" });
            AlterColumn("dbo.Projections", "LecturerId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Projections", "MovieId", c => c.String());
            AlterColumn("dbo.Movies", "GenreId", c => c.String());
            DropColumn("dbo.Projections", "Lecturer_Id");
            RenameColumn(table: "dbo.Projections", name: "MovieId", newName: "Movie_Id");
            RenameColumn(table: "dbo.Movies", name: "GenreId", newName: "Genre_Id");
            AddColumn("dbo.Projections", "MovieId", c => c.String());
            AddColumn("dbo.Movies", "GenreId", c => c.String());
            CreateIndex("dbo.Projections", "Movie_Id");
            CreateIndex("dbo.Projections", "LecturerId");
            CreateIndex("dbo.Movies", "Genre_Id");
            AddForeignKey("dbo.Projections", "LecturerId", "dbo.AspNetUsers", "Id");
        }
    }
}
