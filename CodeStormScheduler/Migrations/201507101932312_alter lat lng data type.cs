namespace CodeStormScheduler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alterlatlngdatatype : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.EventDetails", "Longitude", c => c.Double(nullable: false));
            AlterColumn("dbo.EventDetails", "Latitude", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EventDetails", "Latitude", c => c.Single(nullable: false));
            AlterColumn("dbo.EventDetails", "Longitude", c => c.Single(nullable: false));
        }
    }
}
