namespace CodeStormScheduler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alter_usermsg : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserMessages", "CDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserMessages", "CDate");
        }
    }
}
