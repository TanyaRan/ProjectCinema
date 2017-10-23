namespace TRan.CinemaUniverse.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProjectionModelFix : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Projections", new[] { "Lecturer_Id" });
            DropColumn("dbo.Projections", "LecturerId");
            RenameColumn(table: "dbo.Projections", name: "Lecturer_Id", newName: "LecturerId");
            AlterColumn("dbo.Projections", "LecturerId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Projections", "LecturerId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Projections", new[] { "LecturerId" });
            AlterColumn("dbo.Projections", "LecturerId", c => c.Guid(nullable: false));
            RenameColumn(table: "dbo.Projections", name: "LecturerId", newName: "Lecturer_Id");
            AddColumn("dbo.Projections", "LecturerId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Projections", "Lecturer_Id");
        }
    }
}
