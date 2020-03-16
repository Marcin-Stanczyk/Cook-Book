namespace CookBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateRecipeAndProductModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RecipeProducts",
                c => new
                    {
                        Recipe_Id = c.Int(nullable: false),
                        Product_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Recipe_Id, t.Product_Id })
                .ForeignKey("dbo.Recipes", t => t.Recipe_Id, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: true)
                .Index(t => t.Recipe_Id)
                .Index(t => t.Product_Id);
            
            AddColumn("dbo.Products", "Amount", c => c.Single(nullable: false));
            AddColumn("dbo.Recipes", "InstructionSteps", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RecipeProducts", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.RecipeProducts", "Recipe_Id", "dbo.Recipes");
            DropIndex("dbo.RecipeProducts", new[] { "Product_Id" });
            DropIndex("dbo.RecipeProducts", new[] { "Recipe_Id" });
            DropColumn("dbo.Recipes", "InstructionSteps");
            DropColumn("dbo.Products", "Amount");
            DropTable("dbo.RecipeProducts");
        }
    }
}
