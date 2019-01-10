namespace eMag2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateProductsTableWithCommentCount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "CommentCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "CommentCount");
        }
    }
}
