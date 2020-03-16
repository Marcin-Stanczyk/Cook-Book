namespace CookBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategoryUnitAndIngredientModels1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ingredients", "ProductId", "dbo.Products");
            DropIndex("dbo.Ingredients", new[] { "ProductId" });
            RenameColumn(table: "dbo.Ingredients", name: "ProductId", newName: "Product_Id");
            AlterColumn("dbo.Ingredients", "Product_Id", c => c.Int());
            CreateIndex("dbo.Ingredients", "Product_Id");
            AddForeignKey("dbo.Ingredients", "Product_Id", "dbo.Products", "Id");
            DropColumn("dbo.Ingredients", "UnitId");
            DropColumn("dbo.Products", "CategoryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "CategoryId", c => c.Byte(nullable: false));
            AddColumn("dbo.Ingredients", "UnitId", c => c.Byte(nullable: false));
            DropForeignKey("dbo.Ingredients", "Product_Id", "dbo.Products");
            DropIndex("dbo.Ingredients", new[] { "Product_Id" });
            AlterColumn("dbo.Ingredients", "Product_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Ingredients", name: "Product_Id", newName: "ProductId");
            CreateIndex("dbo.Ingredients", "ProductId");
            AddForeignKey("dbo.Ingredients", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
    }
}
