namespace CookBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateProductDataAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false, maxLength: 25));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false, maxLength: 100));
        }
    }
}
