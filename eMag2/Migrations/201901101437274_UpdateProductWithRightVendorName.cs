namespace eMag2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateProductWithRightVendorName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "SoldBy", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "SoldBy", c => c.String(nullable: false));
        }
    }
}
