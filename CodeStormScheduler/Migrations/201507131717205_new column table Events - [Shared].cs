namespace CodeStormScheduler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newcolumntableEventsShared : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "Shared", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "Shared");
        }
    }
}
