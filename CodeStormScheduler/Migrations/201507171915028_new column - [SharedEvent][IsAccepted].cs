namespace CodeStormScheduler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newcolumnSharedEventIsAccepted : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SharedEvents", "IsAccepted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SharedEvents", "IsAccepted");
        }
    }
}
