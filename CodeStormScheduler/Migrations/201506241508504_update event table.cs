namespace CodeStormScheduler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateeventtable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "UserId");
        }
    }
}
