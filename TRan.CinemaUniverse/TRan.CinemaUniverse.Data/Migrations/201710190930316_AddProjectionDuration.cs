namespace TRan.CinemaUniverse.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProjectionDuration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projections", "Duration", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projections", "Duration");
        }
    }
}
