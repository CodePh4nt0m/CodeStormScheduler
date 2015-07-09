namespace CodeStormScheduler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EventsNewColumnId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "Id", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "Id");
        }
    }
}
