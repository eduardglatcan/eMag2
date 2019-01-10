namespace eMag2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateProductTableWithPostedCollumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Posted", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Posted");
        }
    }
}
