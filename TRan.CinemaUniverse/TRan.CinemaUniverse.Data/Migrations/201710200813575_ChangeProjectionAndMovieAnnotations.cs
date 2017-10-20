namespace TRan.CinemaUniverse.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeProjectionAndMovieAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Projections", "LecturerId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Projections", "LecturerId", c => c.Guid());
        }
    }
}
