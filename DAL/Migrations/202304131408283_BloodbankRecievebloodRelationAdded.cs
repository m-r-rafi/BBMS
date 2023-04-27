namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BloodbankRecievebloodRelationAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RecieveBloods", "BloodId", c => c.Int(nullable: false));
            CreateIndex("dbo.RecieveBloods", "BloodId");
            AddForeignKey("dbo.RecieveBloods", "BloodId", "dbo.BloodBanks", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RecieveBloods", "BloodId", "dbo.BloodBanks");
            DropIndex("dbo.RecieveBloods", new[] { "BloodId" });
            DropColumn("dbo.RecieveBloods", "BloodId");
        }
    }
}
