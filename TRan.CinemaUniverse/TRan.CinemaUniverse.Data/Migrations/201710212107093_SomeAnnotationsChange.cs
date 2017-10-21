namespace TRan.CinemaUniverse.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SomeAnnotationsChange : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Projections", name: "WeekOffer_Id", newName: "WeekOfferId");
            RenameIndex(table: "dbo.Projections", name: "IX_WeekOffer_Id", newName: "IX_WeekOfferId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Projections", name: "IX_WeekOfferId", newName: "IX_WeekOffer_Id");
            RenameColumn(table: "dbo.Projections", name: "WeekOfferId", newName: "WeekOffer_Id");
        }
    }
}
