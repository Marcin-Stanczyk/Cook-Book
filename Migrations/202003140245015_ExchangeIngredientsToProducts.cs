namespace CookBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExchangeIngredientsToProducts : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ingredients", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Ingredients", "UnitId", "dbo.Units");
            DropForeignKey("dbo.Ingredients", "Recipe_Id", "dbo.Recipes");
            DropIndex("dbo.Ingredients", new[] { "ProductId" });
            DropIndex("dbo.Ingredients", new[] { "UnitId" });
            DropIndex("dbo.Ingredients", new[] { "Recipe_Id" });
            AddColumn("dbo.Products", "Recipe_Id", c => c.Int());
            CreateIndex("dbo.Products", "Recipe_Id");
            AddForeignKey("dbo.Products", "Recipe_Id", "dbo.Recipes", "Id");
            DropTable("dbo.Ingredients");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Ingredients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        UnitId = c.Int(nullable: false),
                        Amount = c.Single(nullable: false),
                        Recipe_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Products", "Recipe_Id", "dbo.Recipes");
            DropIndex("dbo.Products", new[] { "Recipe_Id" });
            DropColumn("dbo.Products", "Recipe_Id");
            CreateIndex("dbo.Ingredients", "Recipe_Id");
            CreateIndex("dbo.Ingredients", "UnitId");
            CreateIndex("dbo.Ingredients", "ProductId");
            AddForeignKey("dbo.Ingredients", "Recipe_Id", "dbo.Recipes", "Id");
            AddForeignKey("dbo.Ingredients", "UnitId", "dbo.Units", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Ingredients", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
    }
}
