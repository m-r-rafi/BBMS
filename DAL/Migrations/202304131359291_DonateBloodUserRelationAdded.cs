namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DonateBloodUserRelationAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DonateBloods", "UserID", c => c.Int(nullable: false));
            CreateIndex("dbo.DonateBloods", "UserID");
            AddForeignKey("dbo.DonateBloods", "UserID", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DonateBloods", "UserID", "dbo.Users");
            DropIndex("dbo.DonateBloods", new[] { "UserID" });
            DropColumn("dbo.DonateBloods", "UserID");
        }
    }
}
