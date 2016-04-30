namespace Realm.Admin.DAL.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class InitialSetup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EditorLogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LoggedOn = c.DateTime(),
                        ActionType = c.Int(nullable: false),
                        Text = c.String(),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Logins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        LoggedIn = c.DateTime(nullable: false),
                        IpAddress = c.String(maxLength: 50),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Logs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LoggedOn = c.DateTime(),
                        LogLevel = c.String(maxLength: 10),
                        SourceName = c.String(maxLength: 255),
                        MachineName = c.String(maxLength: 255),
                        Text = c.String(),
                        Exception = c.String(),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RestrictedNames",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(maxLength: 50),
                        IsReserved = c.Boolean(nullable: false),
                        IsCopyright = c.Boolean(nullable: false),
                        IsProfanity = c.Boolean(nullable: false),
                        IsRegex = c.Boolean(nullable: false),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sessions",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        SessionDate = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SessionActions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SessionId = c.Guid(nullable: false),
                        ActionType = c.Int(nullable: false),
                        ObjectId = c.String(),
                        ObjectName = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sessions", t => t.SessionId)
                .Index(t => t.SessionId);
            
            CreateTable(
                "dbo.SessionValues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SessionId = c.Guid(nullable: false),
                        RecordType = c.Int(nullable: false),
                        Value = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sessions", t => t.SessionId)
                .Index(t => t.SessionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SessionValues", "SessionId", "dbo.Sessions");
            DropForeignKey("dbo.SessionActions", "SessionId", "dbo.Sessions");
            DropIndex("dbo.SessionValues", new[] { "SessionId" });
            DropIndex("dbo.SessionActions", new[] { "SessionId" });
            DropTable("dbo.SessionValues");
            DropTable("dbo.SessionActions");
            DropTable("dbo.Sessions");
            DropTable("dbo.RestrictedNames");
            DropTable("dbo.Logs");
            DropTable("dbo.Logins");
            DropTable("dbo.EditorLogs");
        }
    }
}
