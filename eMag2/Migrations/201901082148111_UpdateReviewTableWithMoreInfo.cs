namespace eMag2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateReviewTableWithMoreInfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reviews", "CustomerId", c => c.Int(nullable: false));
            AddColumn("dbo.Reviews", "PostedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Reviews", "Title", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reviews", "Title");
            DropColumn("dbo.Reviews", "PostedDate");
            DropColumn("dbo.Reviews", "CustomerId");
        }
    }
}
