namespace CodeStormScheduler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alter_user_profile : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserProfiles", "ImageUrl", c => c.String(maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserProfiles", "ImageUrl");
        }
    }
}
