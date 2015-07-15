namespace CodeStormScheduler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class altertableUserProfile : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserProfiles", "Gender", c => c.String(maxLength: 10));
            AddColumn("dbo.UserProfiles", "DOB", c => c.DateTime(nullable: false));
            AddColumn("dbo.UserProfiles", "Location", c => c.String(maxLength: 200));
            AddColumn("dbo.UserProfiles", "Mobile", c => c.String(maxLength: 15));
            AddColumn("dbo.UserProfiles", "Profession", c => c.String(maxLength: 150));
            AddColumn("dbo.UserProfiles", "Twitter", c => c.String(maxLength: 100));
            AddColumn("dbo.UserProfiles", "Facebook", c => c.String());
            AddColumn("dbo.UserProfiles", "AboutMe", c => c.String());
            AddColumn("dbo.UserProfiles", "Interests", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserProfiles", "Interests");
            DropColumn("dbo.UserProfiles", "AboutMe");
            DropColumn("dbo.UserProfiles", "Facebook");
            DropColumn("dbo.UserProfiles", "Twitter");
            DropColumn("dbo.UserProfiles", "Profession");
            DropColumn("dbo.UserProfiles", "Mobile");
            DropColumn("dbo.UserProfiles", "Location");
            DropColumn("dbo.UserProfiles", "DOB");
            DropColumn("dbo.UserProfiles", "Gender");
        }
    }
}
