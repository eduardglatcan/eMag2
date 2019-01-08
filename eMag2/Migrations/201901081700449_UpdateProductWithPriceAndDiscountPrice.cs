namespace eMag2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateProductWithPriceAndDiscountPrice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "FullPrice", c => c.Single(nullable: false));
            AddColumn("dbo.Products", "DiscountedPrice", c => c.Single(nullable: false));
            DropColumn("dbo.Products", "Price");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Price", c => c.String(nullable: false));
            DropColumn("dbo.Products", "DiscountedPrice");
            DropColumn("dbo.Products", "FullPrice");
        }
    }
}
