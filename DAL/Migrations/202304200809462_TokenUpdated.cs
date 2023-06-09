﻿namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TokenUpdated : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tokens", "UserID", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tokens", "UserID", c => c.Int(nullable: false));
        }
    }
}
