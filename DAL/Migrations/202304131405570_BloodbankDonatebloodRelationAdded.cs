namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BloodbankDonatebloodRelationAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DonateBloods", "BloodId", c => c.Int(nullable: false));
            CreateIndex("dbo.DonateBloods", "BloodId");
            AddForeignKey("dbo.DonateBloods", "BloodId", "dbo.BloodBanks", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DonateBloods", "BloodId", "dbo.BloodBanks");
            DropIndex("dbo.DonateBloods", new[] { "BloodId" });
            DropColumn("dbo.DonateBloods", "BloodId");
        }
    }
}
