namespace CookBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExchangeRecipeProductsToIngredientsTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RecipeProducts", "Recipe_Id", "dbo.Recipes");
            DropForeignKey("dbo.RecipeProducts", "Product_Id", "dbo.Products");
            DropIndex("dbo.RecipeProducts", new[] { "Recipe_Id" });
            DropIndex("dbo.RecipeProducts", new[] { "Product_Id" });
            CreateTable(
                "dbo.Ingredients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Product_Id = c.Int(),
                        Recipe_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .ForeignKey("dbo.Recipes", t => t.Recipe_Id)
                .Index(t => t.Product_Id)
                .Index(t => t.Recipe_Id);
            
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
            DropForeignKey("dbo.Ingredients", "Product_Id", "dbo.Products");
            DropIndex("dbo.Ingredients", new[] { "Recipe_Id" });
            DropIndex("dbo.Ingredients", new[] { "Product_Id" });
            DropTable("dbo.Ingredients");
            CreateIndex("dbo.RecipeProducts", "Product_Id");
            CreateIndex("dbo.RecipeProducts", "Recipe_Id");
            AddForeignKey("dbo.RecipeProducts", "Product_Id", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.RecipeProducts", "Recipe_Id", "dbo.Recipes", "Id", cascadeDelete: true);
        }
    }
}
