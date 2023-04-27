namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserTypeUserRelation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "UserTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Users", "UserTypeId");
            AddForeignKey("dbo.Users", "UserTypeId", "dbo.UserTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "UserTypeId", "dbo.UserTypes");
            DropIndex("dbo.Users", new[] { "UserTypeId" });
            DropColumn("dbo.Users", "UserTypeId");
        }
    }
}
