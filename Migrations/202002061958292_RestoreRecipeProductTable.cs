namespace CookBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RestoreRecipeProductTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RecipeProducts", "Recipe_Id", "dbo.Recipes");
            DropForeignKey("dbo.RecipeProducts", "Product_Id", "dbo.Products");
            DropIndex("dbo.RecipeProducts", new[] { "Recipe_Id" });
            DropIndex("dbo.RecipeProducts", new[] { "Product_Id" });
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
            
            CreateIndex("dbo.RecipeProducts", "Product_Id");
            CreateIndex("dbo.RecipeProducts", "Recipe_Id");
            AddForeignKey("dbo.RecipeProducts", "Product_Id", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.RecipeProducts", "Recipe_Id", "dbo.Recipes", "Id", cascadeDelete: true);
        }
    }
}
