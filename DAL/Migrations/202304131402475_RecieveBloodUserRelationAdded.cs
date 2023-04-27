namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RecieveBloodUserRelationAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RecieveBloods", "UserID", c => c.Int(nullable: false));
            CreateIndex("dbo.RecieveBloods", "UserID");
            AddForeignKey("dbo.RecieveBloods", "UserID", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RecieveBloods", "UserID", "dbo.Users");
            DropIndex("dbo.RecieveBloods", new[] { "UserID" });
            DropColumn("dbo.RecieveBloods", "UserID");
        }
    }
}
