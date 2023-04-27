namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DonateBloodStatusRelationAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DonateBloods", "StatusId", c => c.Int(nullable: false));
            CreateIndex("dbo.DonateBloods", "StatusId");
            AddForeignKey("dbo.DonateBloods", "StatusId", "dbo.StatusSettings", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DonateBloods", "StatusId", "dbo.StatusSettings");
            DropIndex("dbo.DonateBloods", new[] { "StatusId" });
            DropColumn("dbo.DonateBloods", "StatusId");
        }
    }
}
