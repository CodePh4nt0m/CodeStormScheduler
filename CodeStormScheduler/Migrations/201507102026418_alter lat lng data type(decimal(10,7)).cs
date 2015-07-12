namespace CodeStormScheduler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alterlatlngdatatypedecimal107 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.EventDetails", "Longitude", c => c.Decimal(nullable: false, precision: 10, scale: 7));
            AlterColumn("dbo.EventDetails", "Latitude", c => c.Decimal(nullable: false, precision: 10, scale: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EventDetails", "Latitude", c => c.Double(nullable: false));
            AlterColumn("dbo.EventDetails", "Longitude", c => c.Double(nullable: false));
        }
    }
}
