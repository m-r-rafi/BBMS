namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BloodBankAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BloodBanks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BloodName = c.String(nullable: false, maxLength: 50),
                        Qty = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BloodBanks");
        }
    }
}
