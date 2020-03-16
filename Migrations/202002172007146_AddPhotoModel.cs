namespace CookBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPhotoModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Path = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Categories", "Photo_Id", c => c.Int());
            AddColumn("dbo.Products", "Photo_Id", c => c.Int());
            AddColumn("dbo.Recipes", "Photo_Id", c => c.Int());
            CreateIndex("dbo.Categories", "Photo_Id");
            CreateIndex("dbo.Products", "Photo_Id");
            CreateIndex("dbo.Recipes", "Photo_Id");
            AddForeignKey("dbo.Categories", "Photo_Id", "dbo.Photos", "Id");
            AddForeignKey("dbo.Products", "Photo_Id", "dbo.Photos", "Id");
            AddForeignKey("dbo.Recipes", "Photo_Id", "dbo.Photos", "Id");
            DropColumn("dbo.Categories", "PhotoPath");
            DropColumn("dbo.Products", "PhotoPath");
            DropColumn("dbo.Recipes", "PhotoPath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Recipes", "PhotoPath", c => c.String());
            AddColumn("dbo.Products", "PhotoPath", c => c.String());
            AddColumn("dbo.Categories", "PhotoPath", c => c.String());
            DropForeignKey("dbo.Recipes", "Photo_Id", "dbo.Photos");
            DropForeignKey("dbo.Products", "Photo_Id", "dbo.Photos");
            DropForeignKey("dbo.Categories", "Photo_Id", "dbo.Photos");
            DropIndex("dbo.Recipes", new[] { "Photo_Id" });
            DropIndex("dbo.Products", new[] { "Photo_Id" });
            DropIndex("dbo.Categories", new[] { "Photo_Id" });
            DropColumn("dbo.Recipes", "Photo_Id");
            DropColumn("dbo.Products", "Photo_Id");
            DropColumn("dbo.Categories", "Photo_Id");
            DropTable("dbo.Photos");
        }
    }
}
