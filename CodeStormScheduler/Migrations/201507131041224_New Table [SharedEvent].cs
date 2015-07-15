namespace CodeStormScheduler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewTableSharedEvent : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SharedEvents",
                c => new
                    {
                        ShraredEventId = c.Int(nullable: false, identity: true),
                        EventId = c.Long(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ShraredEventId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SharedEvents");
        }
    }
}
