namespace CodeStormScheduler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class user_messages : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserMessages",
                c => new
                    {
                        MessageId = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        ReceiverId = c.String(maxLength: 128),
                        SenderId = c.String(maxLength: 128),
                        Status = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.MessageId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserMessages");
        }
    }
}
