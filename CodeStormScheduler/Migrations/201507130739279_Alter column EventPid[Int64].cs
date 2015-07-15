namespace CodeStormScheduler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AltercolumnEventPidInt64 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Events", "EventPid", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Events", "EventPid", c => c.Int(nullable: false));
        }
    }
}
