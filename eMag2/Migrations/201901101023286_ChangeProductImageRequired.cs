namespace eMag2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeProductImageRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "ImagePath", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "ImagePath", c => c.String(nullable: false));
        }
    }
}
