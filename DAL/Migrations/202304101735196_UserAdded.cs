namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 50),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                        Dob = c.DateTime(nullable: false),
                        Address1 = c.String(nullable: false, maxLength: 50),
                        Address2 = c.String(nullable: false, maxLength: 50),
                        Gender = c.String(nullable: false),
                        LastDonatedOn = c.DateTime(nullable: false),
                        Password = c.String(nullable: false, maxLength: 50),
                        BloodGroup = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
        }
    }
}
