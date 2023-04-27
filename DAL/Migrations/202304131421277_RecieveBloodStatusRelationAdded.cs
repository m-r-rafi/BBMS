namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RecieveBloodStatusRelationAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RecieveBloods", "StatusId", c => c.Int(nullable: false));
            CreateIndex("dbo.RecieveBloods", "StatusId");
            AddForeignKey("dbo.RecieveBloods", "StatusId", "dbo.StatusSettings", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RecieveBloods", "StatusId", "dbo.StatusSettings");
            DropIndex("dbo.RecieveBloods", new[] { "StatusId" });
            DropColumn("dbo.RecieveBloods", "StatusId");
        }
    }
}
