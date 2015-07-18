namespace CodeStormScheduler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class altercolumnSharedEventsStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SharedEvents", "Status", c => c.String(maxLength: 10));
            DropColumn("dbo.SharedEvents", "IsAccepted");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SharedEvents", "IsAccepted", c => c.Boolean(nullable: false));
            DropColumn("dbo.SharedEvents", "Status");
        }
    }
}
