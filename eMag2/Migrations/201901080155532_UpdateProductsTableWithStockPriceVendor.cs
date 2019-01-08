namespace eMag2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateProductsTableWithStockPriceVendor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "NumberInStock", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "SoldBy", c => c.String(nullable: false));
            AddColumn("dbo.Products", "Price", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Price");
            DropColumn("dbo.Products", "SoldBy");
            DropColumn("dbo.Products", "NumberInStock");
        }
    }
}
