namespace CodeStormScheduler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EventsColumnColor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "Color", c => c.String(maxLength: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "Color");
        }
    }
}
