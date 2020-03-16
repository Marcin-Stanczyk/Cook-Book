namespace CookBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Truncate2ProductsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Category_Id", c => c.Int());
            CreateIndex("dbo.Products", "Category_Id");
            AddForeignKey("dbo.Products", "Category_Id", "dbo.Categories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "Category_Id" });
            DropColumn("dbo.Products", "Category_Id");
        }
    }
}
