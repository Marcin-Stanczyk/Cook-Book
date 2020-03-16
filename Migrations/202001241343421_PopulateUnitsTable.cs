namespace CookBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateUnitsTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Units(Name) VALUES ('g')");
            Sql("INSERT INTO Units(Name) VALUES ('ml')");
            Sql("INSERT INTO Units(Name) VALUES ('spoon')");
            Sql("INSERT INTO Units(Name) VALUES ('cup')");
            Sql("INSERT INTO Units(Name) VALUES ('glass')");
            Sql("INSERT INTO Units(Name) VALUES ('liter')");
            Sql("INSERT INTO Units(Name) VALUES ('some')");
            Sql("INSERT INTO Units(Name) VALUES ('handful')");
        }
        
        public override void Down()
        {
        }
    }
}
