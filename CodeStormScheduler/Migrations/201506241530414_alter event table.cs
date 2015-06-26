namespace CodeStormScheduler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class altereventtable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Events", "UserId", c => c.String(maxLength: 128));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Events", "UserId", c => c.String());
        }
    }
}
