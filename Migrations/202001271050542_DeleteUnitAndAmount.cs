namespace CookBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteUnitAndAmount : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Unit_Id", "dbo.Units");
            DropIndex("dbo.Products", new[] { "Unit_Id" });
            DropColumn("dbo.Products", "Amount");
            DropColumn("dbo.Products", "Unit_Id");
            DropTable("dbo.Units");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Units",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Products", "Unit_Id", c => c.Int());
            AddColumn("dbo.Products", "Amount", c => c.Single(nullable: false));
            CreateIndex("dbo.Products", "Unit_Id");
            AddForeignKey("dbo.Products", "Unit_Id", "dbo.Units", "Id");
        }
    }
}
