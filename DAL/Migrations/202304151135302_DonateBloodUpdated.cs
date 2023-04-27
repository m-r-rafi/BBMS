namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DonateBloodUpdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DonateBloods", "DonatedOn", c => c.DateTime(nullable: false));
            DropColumn("dbo.DonateBloods", "RecievedOn");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DonateBloods", "RecievedOn", c => c.DateTime(nullable: false));
            DropColumn("dbo.DonateBloods", "DonatedOn");
        }
    }
}
