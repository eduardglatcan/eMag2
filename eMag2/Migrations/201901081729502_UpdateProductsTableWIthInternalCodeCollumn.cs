namespace eMag2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateProductsTableWIthInternalCodeCollumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "InternalCode", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "InternalCode");
        }
    }
}
