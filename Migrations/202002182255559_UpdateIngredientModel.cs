namespace CookBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateIngredientModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ingredients", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Ingredients", "Unit_Id", "dbo.Units");
            DropIndex("dbo.Ingredients", new[] { "Product_Id" });
            DropIndex("dbo.Ingredients", new[] { "Unit_Id" });
            RenameColumn(table: "dbo.Ingredients", name: "Product_Id", newName: "ProductId");
            RenameColumn(table: "dbo.Ingredients", name: "Unit_Id", newName: "UnitId");
            AlterColumn("dbo.Ingredients", "ProductId", c => c.Int(nullable: false));
            AlterColumn("dbo.Ingredients", "UnitId", c => c.Int(nullable: false));
            CreateIndex("dbo.Ingredients", "ProductId");
            CreateIndex("dbo.Ingredients", "UnitId");
            AddForeignKey("dbo.Ingredients", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Ingredients", "UnitId", "dbo.Units", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ingredients", "UnitId", "dbo.Units");
            DropForeignKey("dbo.Ingredients", "ProductId", "dbo.Products");
            DropIndex("dbo.Ingredients", new[] { "UnitId" });
            DropIndex("dbo.Ingredients", new[] { "ProductId" });
            AlterColumn("dbo.Ingredients", "UnitId", c => c.Int());
            AlterColumn("dbo.Ingredients", "ProductId", c => c.Int());
            RenameColumn(table: "dbo.Ingredients", name: "UnitId", newName: "Unit_Id");
            RenameColumn(table: "dbo.Ingredients", name: "ProductId", newName: "Product_Id");
            CreateIndex("dbo.Ingredients", "Unit_Id");
            CreateIndex("dbo.Ingredients", "Product_Id");
            AddForeignKey("dbo.Ingredients", "Unit_Id", "dbo.Units", "Id");
            AddForeignKey("dbo.Ingredients", "Product_Id", "dbo.Products", "Id");
        }
    }
}
