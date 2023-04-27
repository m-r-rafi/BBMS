namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChatUserRelationAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Chats", "UserTo", c => c.Int(nullable: false));
            CreateIndex("dbo.Chats", "UserTo");
            AddForeignKey("dbo.Chats", "UserTo", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Chats", "UserTo", "dbo.Users");
            DropIndex("dbo.Chats", new[] { "UserTo" });
            DropColumn("dbo.Chats", "UserTo");
        }
    }
}
