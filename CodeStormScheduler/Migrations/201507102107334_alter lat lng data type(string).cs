namespace CodeStormScheduler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alterlatlngdatatypestring : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.EventDetails", "Longitude", c => c.String(maxLength: 10));
            AlterColumn("dbo.EventDetails", "Latitude", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EventDetails", "Latitude", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.EventDetails", "Longitude", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
