namespace CookBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropColumnCategory_Id : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "Category_Id" });
            DropColumn("dbo.Products", "CategoryId");
            RenameColumn(table: "dbo.Products", name: "Category_Id", newName: "CategoryId");
            DropPrimaryKey("dbo.Categories");
            AlterColumn("dbo.Categories", "Id", c => c.Byte(nullable: false));
            AlterColumn("dbo.Products", "CategoryId", c => c.Byte());
            AlterColumn("dbo.Products", "CategoryId", c => c.Byte());
            AddPrimaryKey("dbo.Categories", "Id");
            CreateIndex("dbo.Products", "CategoryId");
            AddForeignKey("dbo.Products", "CategoryId", "dbo.Categories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropPrimaryKey("dbo.Categories");
            AlterColumn("dbo.Products", "CategoryId", c => c.Int());
            AlterColumn("dbo.Products", "CategoryId", c => c.Byte(nullable: false));
            AlterColumn("dbo.Categories", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Categories", "Id");
            RenameColumn(table: "dbo.Products", name: "CategoryId", newName: "Category_Id");
            AddColumn("dbo.Products", "CategoryId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Products", "Category_Id");
            AddForeignKey("dbo.Products", "Category_Id", "dbo.Categories", "Id");
        }
    }
}
