namespace CookBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrectProductClass : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Recipes", "Unit_Id", "dbo.Units");
            DropIndex("dbo.Recipes", new[] { "Unit_Id" });
            AddColumn("dbo.Products", "Unit_Id", c => c.Int());
            CreateIndex("dbo.Products", "Unit_Id");
            AddForeignKey("dbo.Products", "Unit_Id", "dbo.Units", "Id");
            DropColumn("dbo.Recipes", "Unit_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Recipes", "Unit_Id", c => c.Int());
            DropForeignKey("dbo.Products", "Unit_Id", "dbo.Units");
            DropIndex("dbo.Products", new[] { "Unit_Id" });
            DropColumn("dbo.Products", "Unit_Id");
            CreateIndex("dbo.Recipes", "Unit_Id");
            AddForeignKey("dbo.Recipes", "Unit_Id", "dbo.Units", "Id");
        }
    }
}
