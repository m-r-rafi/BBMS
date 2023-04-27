namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeFromRelationChat : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Chats", "UserFrom", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Chats", "UserFrom");
        }
    }
}
