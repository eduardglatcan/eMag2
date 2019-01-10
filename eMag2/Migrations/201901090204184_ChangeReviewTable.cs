namespace eMag2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeReviewTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reviews", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Reviews", "ApplicationUser_Id");
            AddForeignKey("dbo.Reviews", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Reviews", "CustomerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reviews", "CustomerId", c => c.String());
            DropForeignKey("dbo.Reviews", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Reviews", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Reviews", "ApplicationUser_Id");
        }
    }
}
