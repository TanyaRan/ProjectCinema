namespace TRan.CinemaUniverse.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CreateWeekOffer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WeekOffers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Theme = c.String(nullable: false, maxLength: 150),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsDeleted);
            
            AddColumn("dbo.Movies", "WeekOffer_Id", c => c.Guid());
            CreateIndex("dbo.Movies", "WeekOffer_Id");
            AddForeignKey("dbo.Movies", "WeekOffer_Id", "dbo.WeekOffers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "WeekOffer_Id", "dbo.WeekOffers");
            DropIndex("dbo.WeekOffers", new[] { "IsDeleted" });
            DropIndex("dbo.Movies", new[] { "WeekOffer_Id" });
            DropColumn("dbo.Movies", "WeekOffer_Id");
            DropTable("dbo.WeekOffers");
        }
    }
}
