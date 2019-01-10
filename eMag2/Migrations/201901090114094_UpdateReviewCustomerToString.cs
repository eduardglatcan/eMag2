namespace eMag2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateReviewCustomerToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Reviews", "CustomerId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reviews", "CustomerId", c => c.Int(nullable: false));
        }
    }
}
