namespace CookBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletePhotoModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Categories", "Photo_Id", "dbo.Photos");
            DropForeignKey("dbo.Products", "Photo_Id", "dbo.Photos");
            DropForeignKey("dbo.Recipes", "Photo_Id", "dbo.Photos");
            DropIndex("dbo.Categories", new[] { "Photo_Id" });
            DropIndex("dbo.Products", new[] { "Photo_Id" });
            DropIndex("dbo.Recipes", new[] { "Photo_Id" });
            AddColumn("dbo.Categories", "PhotoPath", c => c.String());
            AddColumn("dbo.Products", "PhotoPath", c => c.String());
            AddColumn("dbo.Recipes", "PhotoPath", c => c.String());
            DropColumn("dbo.Categories", "Photo_Id");
            DropColumn("dbo.Products", "Photo_Id");
            DropColumn("dbo.Recipes", "Photo_Id");
            DropTable("dbo.Photos");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Path = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Recipes", "Photo_Id", c => c.Int());
            AddColumn("dbo.Products", "Photo_Id", c => c.Int());
            AddColumn("dbo.Categories", "Photo_Id", c => c.Int());
            DropColumn("dbo.Recipes", "PhotoPath");
            DropColumn("dbo.Products", "PhotoPath");
            DropColumn("dbo.Categories", "PhotoPath");
            CreateIndex("dbo.Recipes", "Photo_Id");
            CreateIndex("dbo.Products", "Photo_Id");
            CreateIndex("dbo.Categories", "Photo_Id");
            AddForeignKey("dbo.Recipes", "Photo_Id", "dbo.Photos", "Id");
            AddForeignKey("dbo.Products", "Photo_Id", "dbo.Photos", "Id");
            AddForeignKey("dbo.Categories", "Photo_Id", "dbo.Photos", "Id");
        }
    }
}
