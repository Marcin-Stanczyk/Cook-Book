namespace CookBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUnitAndAmountToIngredientModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ingredients", "Amount", c => c.Single(nullable: false));
            AddColumn("dbo.Ingredients", "Unit_Id", c => c.Int());
            CreateIndex("dbo.Ingredients", "Unit_Id");
            AddForeignKey("dbo.Ingredients", "Unit_Id", "dbo.Units", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ingredients", "Unit_Id", "dbo.Units");
            DropIndex("dbo.Ingredients", new[] { "Unit_Id" });
            DropColumn("dbo.Ingredients", "Unit_Id");
            DropColumn("dbo.Ingredients", "Amount");
        }
    }
}
