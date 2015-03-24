namespace Realm.Live.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialSetup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Auctions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(),
                        Quantity = c.Int(nullable: false),
                        DurationInSeconds = c.Int(nullable: false),
                        Reserve = c.Int(nullable: false),
                        IsFinished = c.Boolean(nullable: false),
                        CreateDateUtc = c.DateTime(),
                        Character_Id = c.Int(),
                        Instance_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Characters", t => t.Character_Id)
                .ForeignKey("dbo.Instances", t => t.Instance_Id)
                .Index(t => t.Character_Id)
                .Index(t => t.Instance_Id);
            
            CreateTable(
                "dbo.AuctionBids",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DatePlaced = c.DateTime(nullable: false),
                        Amount = c.Int(nullable: false),
                        IsRetracted = c.Boolean(nullable: false),
                        CreateDateUtc = c.DateTime(),
                        Character_Id = c.Int(),
                        Auction_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Characters", t => t.Character_Id)
                .ForeignKey("dbo.Auctions", t => t.Auction_Id)
                .Index(t => t.Character_Id)
                .Index(t => t.Auction_Id);
            
            CreateTable(
                "dbo.Characters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        DeletedOn = c.DateTime(),
                        LocationId = c.Int(),
                        RaceId = c.Int(),
                        Level = c.Int(nullable: false),
                        Experience = c.Int(nullable: false),
                        Coin = c.Int(nullable: false),
                        Gender = c.Int(nullable: false),
                        AutoAttackAbilityId = c.Int(),
                        TrainingPoints = c.Int(nullable: false),
                        CreateDateUtc = c.DateTime(),
                        Bank_Id = c.Int(),
                        Guild_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Banks", t => t.Bank_Id)
                .ForeignKey("dbo.Guilds", t => t.Guild_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Bank_Id)
                .Index(t => t.Guild_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.CharacterAbilities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AbilityId = c.Int(),
                        PurchasedOn = c.DateTime(),
                        CreateDateUtc = c.DateTime(),
                        Character_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Characters", t => t.Character_Id)
                .Index(t => t.Character_Id);
            
            CreateTable(
                "dbo.CharacterAuctions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreateDateUtc = c.DateTime(),
                        Auction_Id = c.Int(),
                        Character_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Auctions", t => t.Auction_Id)
                .ForeignKey("dbo.Characters", t => t.Character_Id)
                .Index(t => t.Auction_Id)
                .Index(t => t.Character_Id);
            
            CreateTable(
                "dbo.Banks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Coin = c.Int(nullable: false),
                        Level = c.Int(nullable: false),
                        LastAccessed = c.DateTime(),
                        BankType = c.Int(nullable: false),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BankItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(),
                        Quantity = c.Int(nullable: false),
                        CreateDateUtc = c.DateTime(),
                        Instance_Id = c.Long(),
                        Bank_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Instances", t => t.Instance_Id)
                .ForeignKey("dbo.Banks", t => t.Bank_Id)
                .Index(t => t.Instance_Id)
                .Index(t => t.Bank_Id);
            
            CreateTable(
                "dbo.Instances",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CreatedOn = c.DateTime(nullable: false),
                        InstanceType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BankLogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ModifiedOn = c.DateTime(nullable: false),
                        CharacterName = c.String(maxLength: 50),
                        ItemId = c.Int(),
                        Quantity = c.Int(nullable: false),
                        Withdrew = c.Boolean(nullable: false),
                        CreateDateUtc = c.DateTime(),
                        Bank_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Banks", t => t.Bank_Id)
                .Index(t => t.Bank_Id);
            
            CreateTable(
                "dbo.CharacterChannels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Handle = c.String(maxLength: 10),
                        IsEnabled = c.Boolean(nullable: false),
                        CreateDateUtc = c.DateTime(),
                        Channel_Id = c.Int(),
                        Character_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Channels", t => t.Channel_Id)
                .ForeignKey("dbo.Characters", t => t.Character_Id)
                .Index(t => t.Channel_Id)
                .Index(t => t.Character_Id);
            
            CreateTable(
                "dbo.Channels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        ChannelType = c.Int(nullable: false),
                        Bits = c.Int(nullable: false),
                        CreateDateUtc = c.DateTime(),
                        Owner_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Characters", t => t.Owner_Id)
                .Index(t => t.Owner_Id);
            
            CreateTable(
                "dbo.CharacterFactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FactionId = c.Int(),
                        Reputation = c.Int(nullable: false),
                        CreateDateUtc = c.DateTime(),
                        Character_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Characters", t => t.Character_Id)
                .Index(t => t.Character_Id);
            
            CreateTable(
                "dbo.Guilds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 1024),
                        Motd = c.String(maxLength: 1024),
                        Url = c.String(maxLength: 50),
                        MemberLimit = c.Int(nullable: false),
                        MemberChannelId = c.Int(),
                        OfficerChannelId = c.Int(),
                        Level = c.Int(nullable: false),
                        Experience = c.Int(nullable: false),
                        CreateDateUtc = c.DateTime(),
                        Bank_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Banks", t => t.Bank_Id)
                .ForeignKey("dbo.Channels", t => t.MemberChannelId)
                .ForeignKey("dbo.Channels", t => t.OfficerChannelId)
                .Index(t => t.MemberChannelId)
                .Index(t => t.OfficerChannelId)
                .Index(t => t.Bank_Id);
            
            CreateTable(
                "dbo.GuildAbilities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AbilityId = c.Int(),
                        UnlockedOn = c.DateTime(nullable: false),
                        CreateDateUtc = c.DateTime(),
                        Guild_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Guilds", t => t.Guild_Id)
                .Index(t => t.Guild_Id);
            
            CreateTable(
                "dbo.GuildMembers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GuildRankType = c.Int(nullable: false),
                        JoinedOn = c.DateTime(),
                        MemberNote = c.String(maxLength: 255),
                        CreateDateUtc = c.DateTime(),
                        Character_Id = c.Int(),
                        Guild_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Characters", t => t.Character_Id)
                .ForeignKey("dbo.Guilds", t => t.Guild_Id)
                .Index(t => t.Character_Id)
                .Index(t => t.Guild_Id);
            
            CreateTable(
                "dbo.CharacterItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InstanceId = c.Long(),
                        ItemId = c.Int(),
                        Quantity = c.Int(nullable: false),
                        WearLocationId = c.Int(),
                        ContainedInItemId = c.Long(),
                        CreateDateUtc = c.DateTime(),
                        Character_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Instances", t => t.ContainedInItemId)
                .ForeignKey("dbo.Instances", t => t.InstanceId)
                .ForeignKey("dbo.Characters", t => t.Character_Id)
                .Index(t => t.InstanceId)
                .Index(t => t.ContainedInItemId)
                .Index(t => t.Character_Id);
            
            CreateTable(
                "dbo.CharacterMailbox",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FromCharacterName = c.String(maxLength: 50),
                        Subject = c.String(maxLength: 50),
                        Text = c.String(),
                        SentOn = c.DateTime(nullable: false),
                        IsNew = c.Boolean(nullable: false),
                        Coin = c.Int(nullable: false),
                        CreateDateUtc = c.DateTime(),
                        Character_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Characters", t => t.Character_Id)
                .Index(t => t.Character_Id);
            
            CreateTable(
                "dbo.CharacterMailItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(),
                        Quantity = c.Int(nullable: false),
                        CreateDateUtc = c.DateTime(),
                        Instance_Id = c.Long(),
                        CharacterMail_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Instances", t => t.Instance_Id)
                .ForeignKey("dbo.CharacterMailbox", t => t.CharacterMail_Id)
                .Index(t => t.Instance_Id)
                .Index(t => t.CharacterMail_Id);
            
            CreateTable(
                "dbo.CharacterProperties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        value = c.String(),
                        CreateDateUtc = c.DateTime(),
                        Property_Id = c.Int(),
                        Character_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Properties", t => t.Property_Id)
                .ForeignKey("dbo.Characters", t => t.Character_Id)
                .Index(t => t.Property_Id)
                .Index(t => t.Character_Id);
            
            CreateTable(
                "dbo.Properties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 1024),
                        IsPersistable = c.Boolean(nullable: false),
                        IsVisible = c.Boolean(nullable: false),
                        IsVolatile = c.Boolean(nullable: false),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CharacterStatistics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Statistic = c.Int(nullable: false),
                        SkillId = c.Int(),
                        Value = c.Int(nullable: false),
                        CreateDateUtc = c.DateTime(),
                        Character_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Characters", t => t.Character_Id)
                .Index(t => t.Character_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 25),
                        Password = c.String(nullable: false, maxLength: 256),
                        Salt = c.String(nullable: false, maxLength: 256),
                        PasswordChangeToken = c.String(),
                        PasswordTokenGeneratedAt = c.DateTime(),
                        PasswordTokenExpiresAt = c.DateTime(),
                        DeletedOn = c.DateTime(),
                        CreateDateUtc = c.DateTime(),
                        Bank_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Banks", t => t.Bank_Id)
                .Index(t => t.Bank_Id);
            
            CreateTable(
                "dbo.UserActions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ActionOccurredAt = c.DateTime(nullable: false),
                        OriginatedFromIpAddress = c.String(maxLength: 50),
                        ActionType = c.Int(nullable: false),
                        CreateDateUtc = c.DateTime(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.GameStates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Sessionstart = c.DateTime(nullable: false),
                        SessionEnd = c.DateTime(nullable: false),
                        Year = c.Int(nullable: false),
                        MonthId = c.Int(nullable: false),
                        Day = c.Int(nullable: false),
                        Hour = c.Int(nullable: false),
                        Minute = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Auctions", "Instance_Id", "dbo.Instances");
            DropForeignKey("dbo.Auctions", "Character_Id", "dbo.Characters");
            DropForeignKey("dbo.AuctionBids", "Auction_Id", "dbo.Auctions");
            DropForeignKey("dbo.AuctionBids", "Character_Id", "dbo.Characters");
            DropForeignKey("dbo.Characters", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Users", "Bank_Id", "dbo.Banks");
            DropForeignKey("dbo.UserActions", "User_Id", "dbo.Users");
            DropForeignKey("dbo.CharacterStatistics", "Character_Id", "dbo.Characters");
            DropForeignKey("dbo.CharacterProperties", "Character_Id", "dbo.Characters");
            DropForeignKey("dbo.CharacterProperties", "Property_Id", "dbo.Properties");
            DropForeignKey("dbo.CharacterMailbox", "Character_Id", "dbo.Characters");
            DropForeignKey("dbo.CharacterMailItems", "CharacterMail_Id", "dbo.CharacterMailbox");
            DropForeignKey("dbo.CharacterMailItems", "Instance_Id", "dbo.Instances");
            DropForeignKey("dbo.CharacterItems", "Character_Id", "dbo.Characters");
            DropForeignKey("dbo.CharacterItems", "InstanceId", "dbo.Instances");
            DropForeignKey("dbo.CharacterItems", "ContainedInItemId", "dbo.Instances");
            DropForeignKey("dbo.Characters", "Guild_Id", "dbo.Guilds");
            DropForeignKey("dbo.Guilds", "OfficerChannelId", "dbo.Channels");
            DropForeignKey("dbo.GuildMembers", "Guild_Id", "dbo.Guilds");
            DropForeignKey("dbo.GuildMembers", "Character_Id", "dbo.Characters");
            DropForeignKey("dbo.Guilds", "MemberChannelId", "dbo.Channels");
            DropForeignKey("dbo.Guilds", "Bank_Id", "dbo.Banks");
            DropForeignKey("dbo.GuildAbilities", "Guild_Id", "dbo.Guilds");
            DropForeignKey("dbo.CharacterFactions", "Character_Id", "dbo.Characters");
            DropForeignKey("dbo.CharacterChannels", "Character_Id", "dbo.Characters");
            DropForeignKey("dbo.CharacterChannels", "Channel_Id", "dbo.Channels");
            DropForeignKey("dbo.Channels", "Owner_Id", "dbo.Characters");
            DropForeignKey("dbo.Characters", "Bank_Id", "dbo.Banks");
            DropForeignKey("dbo.BankLogs", "Bank_Id", "dbo.Banks");
            DropForeignKey("dbo.BankItems", "Bank_Id", "dbo.Banks");
            DropForeignKey("dbo.BankItems", "Instance_Id", "dbo.Instances");
            DropForeignKey("dbo.CharacterAuctions", "Character_Id", "dbo.Characters");
            DropForeignKey("dbo.CharacterAuctions", "Auction_Id", "dbo.Auctions");
            DropForeignKey("dbo.CharacterAbilities", "Character_Id", "dbo.Characters");
            DropIndex("dbo.UserActions", new[] { "User_Id" });
            DropIndex("dbo.Users", new[] { "Bank_Id" });
            DropIndex("dbo.CharacterStatistics", new[] { "Character_Id" });
            DropIndex("dbo.CharacterProperties", new[] { "Character_Id" });
            DropIndex("dbo.CharacterProperties", new[] { "Property_Id" });
            DropIndex("dbo.CharacterMailItems", new[] { "CharacterMail_Id" });
            DropIndex("dbo.CharacterMailItems", new[] { "Instance_Id" });
            DropIndex("dbo.CharacterMailbox", new[] { "Character_Id" });
            DropIndex("dbo.CharacterItems", new[] { "Character_Id" });
            DropIndex("dbo.CharacterItems", new[] { "ContainedInItemId" });
            DropIndex("dbo.CharacterItems", new[] { "InstanceId" });
            DropIndex("dbo.GuildMembers", new[] { "Guild_Id" });
            DropIndex("dbo.GuildMembers", new[] { "Character_Id" });
            DropIndex("dbo.GuildAbilities", new[] { "Guild_Id" });
            DropIndex("dbo.Guilds", new[] { "Bank_Id" });
            DropIndex("dbo.Guilds", new[] { "OfficerChannelId" });
            DropIndex("dbo.Guilds", new[] { "MemberChannelId" });
            DropIndex("dbo.CharacterFactions", new[] { "Character_Id" });
            DropIndex("dbo.Channels", new[] { "Owner_Id" });
            DropIndex("dbo.CharacterChannels", new[] { "Character_Id" });
            DropIndex("dbo.CharacterChannels", new[] { "Channel_Id" });
            DropIndex("dbo.BankLogs", new[] { "Bank_Id" });
            DropIndex("dbo.BankItems", new[] { "Bank_Id" });
            DropIndex("dbo.BankItems", new[] { "Instance_Id" });
            DropIndex("dbo.CharacterAuctions", new[] { "Character_Id" });
            DropIndex("dbo.CharacterAuctions", new[] { "Auction_Id" });
            DropIndex("dbo.CharacterAbilities", new[] { "Character_Id" });
            DropIndex("dbo.Characters", new[] { "User_Id" });
            DropIndex("dbo.Characters", new[] { "Guild_Id" });
            DropIndex("dbo.Characters", new[] { "Bank_Id" });
            DropIndex("dbo.AuctionBids", new[] { "Auction_Id" });
            DropIndex("dbo.AuctionBids", new[] { "Character_Id" });
            DropIndex("dbo.Auctions", new[] { "Instance_Id" });
            DropIndex("dbo.Auctions", new[] { "Character_Id" });
            DropTable("dbo.GameStates");
            DropTable("dbo.UserActions");
            DropTable("dbo.Users");
            DropTable("dbo.CharacterStatistics");
            DropTable("dbo.Properties");
            DropTable("dbo.CharacterProperties");
            DropTable("dbo.CharacterMailItems");
            DropTable("dbo.CharacterMailbox");
            DropTable("dbo.CharacterItems");
            DropTable("dbo.GuildMembers");
            DropTable("dbo.GuildAbilities");
            DropTable("dbo.Guilds");
            DropTable("dbo.CharacterFactions");
            DropTable("dbo.Channels");
            DropTable("dbo.CharacterChannels");
            DropTable("dbo.BankLogs");
            DropTable("dbo.Instances");
            DropTable("dbo.BankItems");
            DropTable("dbo.Banks");
            DropTable("dbo.CharacterAuctions");
            DropTable("dbo.CharacterAbilities");
            DropTable("dbo.Characters");
            DropTable("dbo.AuctionBids");
            DropTable("dbo.Auctions");
        }
    }
}
