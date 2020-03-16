namespace CookBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCategoryTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Categories (Name, PhotoPath) VALUES ('Dairy', '~/images/products/dairy/0dairy.jpg')");
            Sql("INSERT INTO Categories (Name, PhotoPath) VALUES ('Fruits', '~/images/products/fruits/0fruits.jpg')");
            Sql("INSERT INTO Categories (Name, PhotoPath) VALUES ('Grains, Beans and Nuts', '~/images/products/grainsBeansNuts/0grains-beans-nuts.jpg')");
            Sql("INSERT INTO Categories (Name, PhotoPath) VALUES ('Meat', '~/images/products/meat/0meat.jpg')");
            Sql("INSERT INTO Categories (Name, PhotoPath) VALUES ('Fish and Seafood', '~/images/products/seafood/0seafood.jpg')");
            Sql("INSERT INTO Categories (Name, PhotoPath) VALUES ('Vegetables', '~/images/products/vegetables/0vegetables.jpg')");
        }
        
        public override void Down()
        {
        }
    }
}
