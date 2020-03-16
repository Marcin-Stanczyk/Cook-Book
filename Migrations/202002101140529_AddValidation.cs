namespace CookBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddValidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Recipes", "Name", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Recipes", "Name", c => c.String());
            AlterColumn("dbo.Products", "Name", c => c.String());
        }
    }
}
