namespace CodeStormScheduler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserProfile : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserProfiles",
                c => new
                    {
                        ProfileId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 100),
                        LastName = c.String(maxLength: 150),
                        Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ProfileId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserProfiles");
        }
    }
}
