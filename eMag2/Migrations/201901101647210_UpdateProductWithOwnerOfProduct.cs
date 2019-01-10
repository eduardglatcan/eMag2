namespace eMag2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateProductWithOwnerOfProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "OwnerId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "OwnerId");
        }
    }
}
