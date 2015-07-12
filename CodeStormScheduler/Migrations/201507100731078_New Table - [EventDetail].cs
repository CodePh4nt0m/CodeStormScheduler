namespace CodeStormScheduler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewTableEventDetail : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EventDetails",
                c => new
                    {
                        EventDetailId = c.Int(nullable: false, identity: true),
                        Id = c.Long(nullable: false),
                        Description = c.String(),
                        Location = c.String(),
                        Longitude = c.Single(nullable: false),
                        Latitude = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.EventDetailId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EventDetails");
        }
    }
}
