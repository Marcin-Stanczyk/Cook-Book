namespace CookBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategoryUnitAndIngredientModels : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RecipeProducts", "Recipe_Id", "dbo.Recipes");
            DropForeignKey("dbo.RecipeProducts", "Product_Id", "dbo.Products");
            DropIndex("dbo.RecipeProducts", new[] { "Recipe_Id" });
            DropIndex("dbo.RecipeProducts", new[] { "Product_Id" });
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PhotoPath = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ingredients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        UnitId = c.Byte(nullable: false),
                        Amount = c.Single(nullable: false),
                        Unit_Id = c.Int(),
                        Recipe_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Units", t => t.Unit_Id)
                .ForeignKey("dbo.Recipes", t => t.Recipe_Id)
                .Index(t => t.ProductId)
                .Index(t => t.Unit_Id)
                .Index(t => t.Recipe_Id);
            
            CreateTable(
                "dbo.Units",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Products", "CategoryId", c => c.Byte(nullable: false));
            AddColumn("dbo.Products", "InStock", c => c.Boolean(nullable: false));
            AddColumn("dbo.Products", "Category_Id", c => c.Int());
            CreateIndex("dbo.Products", "Category_Id");
            AddForeignKey("dbo.Products", "Category_Id", "dbo.Categories", "Id");
            DropTable("dbo.RecipeProducts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.RecipeProducts",
                c => new
                    {
                        Recipe_Id = c.Int(nullable: false),
                        Product_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Recipe_Id, t.Product_Id });
            
            DropForeignKey("dbo.Ingredients", "Recipe_Id", "dbo.Recipes");
            DropForeignKey("dbo.Ingredients", "Unit_Id", "dbo.Units");
            DropForeignKey("dbo.Ingredients", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "Category_Id" });
            DropIndex("dbo.Ingredients", new[] { "Recipe_Id" });
            DropIndex("dbo.Ingredients", new[] { "Unit_Id" });
            DropIndex("dbo.Ingredients", new[] { "ProductId" });
            DropColumn("dbo.Products", "Category_Id");
            DropColumn("dbo.Products", "InStock");
            DropColumn("dbo.Products", "CategoryId");
            DropTable("dbo.Units");
            DropTable("dbo.Ingredients");
            DropTable("dbo.Categories");
            CreateIndex("dbo.RecipeProducts", "Product_Id");
            CreateIndex("dbo.RecipeProducts", "Recipe_Id");
            AddForeignKey("dbo.RecipeProducts", "Product_Id", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.RecipeProducts", "Recipe_Id", "dbo.Recipes", "Id", cascadeDelete: true);
        }
    }
}
