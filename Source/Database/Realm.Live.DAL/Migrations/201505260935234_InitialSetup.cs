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
                        InstanceId = c.Long(),
                        ItemId = c.Int(),
                        Quantity = c.Int(nullable: false),
                        CharacterId = c.Int(),
                        DurationInSeconds = c.Int(nullable: false),
                        Reserve = c.Int(nullable: false),
                        IsFinished = c.Boolean(nullable: false),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Characters", t => t.CharacterId)
                .ForeignKey("dbo.Instances", t => t.InstanceId)
                .Index(t => t.InstanceId)
                .Index(t => t.CharacterId);
            
            CreateTable(
                "dbo.AuctionBids",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AuctionId = c.Long(nullable: false),
                        CharacterId = c.Int(),
                        DatePlaced = c.DateTime(nullable: false),
                        Amount = c.Int(nullable: false),
                        IsRetracted = c.Boolean(nullable: false),
                        CreateDateUtc = c.DateTime(),
                        Auction_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Auctions", t => t.Auction_Id)
                .ForeignKey("dbo.Characters", t => t.CharacterId)
                .Index(t => t.CharacterId)
                .Index(t => t.Auction_Id);
            
            CreateTable(
                "dbo.Characters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(),
                        Name = c.String(maxLength: 50),
                        DeletedOn = c.DateTime(),
                        GuildId = c.Int(),
                        LocationId = c.Int(),
                        RaceId = c.Int(),
                        Level = c.Int(nullable: false),
                        Experience = c.Int(nullable: false),
                        Coin = c.Int(nullable: false),
                        Gender = c.Int(nullable: false),
                        AutoAttackAbilityId = c.Int(),
                        TrainingPoints = c.Int(nullable: false),
                        BankId = c.Int(),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Banks", t => t.BankId)
                .ForeignKey("dbo.Guilds", t => t.GuildId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.GuildId)
                .Index(t => t.BankId);
            
            CreateTable(
                "dbo.CharacterAbilities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CharacterId = c.Int(nullable: false),
                        AbilityId = c.Int(),
                        PurchasedOn = c.DateTime(),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Characters", t => t.CharacterId)
                .Index(t => t.CharacterId);
            
            CreateTable(
                "dbo.CharacterAuctions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CharacterId = c.Int(nullable: false),
                        AuctionId = c.Long(),
                        CreateDateUtc = c.DateTime(),
                        Auction_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Auctions", t => t.Auction_Id)
                .ForeignKey("dbo.Characters", t => t.CharacterId)
                .Index(t => t.CharacterId)
                .Index(t => t.Auction_Id);
            
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
                        BankId = c.Int(nullable: false),
                        InstanceId = c.Long(),
                        ItemId = c.Int(),
                        Quantity = c.Int(nullable: false),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Banks", t => t.BankId)
                .ForeignKey("dbo.Instances", t => t.InstanceId)
                .Index(t => t.BankId)
                .Index(t => t.InstanceId);
            
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
                        BankId = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        CharacterName = c.String(maxLength: 50),
                        ItemId = c.Int(),
                        Quantity = c.Int(nullable: false),
                        Withdrew = c.Boolean(nullable: false),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Banks", t => t.BankId)
                .Index(t => t.BankId);
            
            CreateTable(
                "dbo.CharacterChannels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CharacterId = c.Int(nullable: false),
                        ChannelId = c.Int(),
                        Handle = c.String(maxLength: 10),
                        IsEnabled = c.Boolean(nullable: false),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Channels", t => t.ChannelId)
                .ForeignKey("dbo.Characters", t => t.CharacterId)
                .Index(t => t.CharacterId)
                .Index(t => t.ChannelId);
            
            CreateTable(
                "dbo.Channels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        ChannelType = c.Int(nullable: false),
                        Bits = c.Int(nullable: false),
                        OwnerId = c.Int(),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Characters", t => t.OwnerId)
                .Index(t => t.OwnerId);
            
            CreateTable(
                "dbo.CharacterFactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CharacterId = c.Int(nullable: false),
                        FactionId = c.Int(),
                        Reputation = c.Int(nullable: false),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Characters", t => t.CharacterId)
                .Index(t => t.CharacterId);
            
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
                        BankId = c.Int(),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Banks", t => t.BankId)
                .ForeignKey("dbo.Channels", t => t.MemberChannelId)
                .ForeignKey("dbo.Channels", t => t.OfficerChannelId)
                .Index(t => t.MemberChannelId)
                .Index(t => t.OfficerChannelId)
                .Index(t => t.BankId);
            
            CreateTable(
                "dbo.GuildAbilities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GuildId = c.Int(nullable: false),
                        AbilityId = c.Int(),
                        UnlockedOn = c.DateTime(nullable: false),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Guilds", t => t.GuildId)
                .Index(t => t.GuildId);
            
            CreateTable(
                "dbo.GuildMembers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GuildId = c.Int(nullable: false),
                        GuildRankType = c.Int(nullable: false),
                        JoinedOn = c.DateTime(),
                        MemberNote = c.String(maxLength: 255),
                        CreateDateUtc = c.DateTime(),
                        Character_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Characters", t => t.Character_Id)
                .ForeignKey("dbo.Guilds", t => t.GuildId)
                .Index(t => t.GuildId)
                .Index(t => t.Character_Id);
            
            CreateTable(
                "dbo.CharacterItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CharacterId = c.Int(nullable: false),
                        InstanceId = c.Long(),
                        ItemId = c.Int(),
                        Quantity = c.Int(nullable: false),
                        WearLocationId = c.Int(),
                        ContainedInItemId = c.Long(),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Characters", t => t.CharacterId)
                .ForeignKey("dbo.Instances", t => t.ContainedInItemId)
                .ForeignKey("dbo.Instances", t => t.InstanceId)
                .Index(t => t.CharacterId)
                .Index(t => t.InstanceId)
                .Index(t => t.ContainedInItemId);
            
            CreateTable(
                "dbo.CharacterMailbox",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CharacterId = c.Int(nullable: false),
                        FromCharacterName = c.String(maxLength: 50),
                        Subject = c.String(maxLength: 50),
                        Text = c.String(),
                        SentOn = c.DateTime(nullable: false),
                        IsNew = c.Boolean(nullable: false),
                        Coin = c.Int(nullable: false),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Characters", t => t.CharacterId)
                .Index(t => t.CharacterId);
            
            CreateTable(
                "dbo.CharacterMailItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CharacterMailId = c.Int(nullable: false),
                        InstanceId = c.Int(),
                        ItemId = c.Int(),
                        Quantity = c.Int(nullable: false),
                        CreateDateUtc = c.DateTime(),
                        Instance_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CharacterMailbox", t => t.CharacterMailId)
                .ForeignKey("dbo.Instances", t => t.Instance_Id)
                .Index(t => t.CharacterMailId)
                .Index(t => t.Instance_Id);
            
            CreateTable(
                "dbo.CharacterProperties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CharacterId = c.Int(nullable: false),
                        PropertyId = c.Int(),
                        value = c.String(),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Characters", t => t.CharacterId)
                .ForeignKey("dbo.Properties", t => t.PropertyId)
                .Index(t => t.CharacterId)
                .Index(t => t.PropertyId);
            
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
                        CharacterId = c.Int(nullable: false),
                        Statistic = c.Int(nullable: false),
                        SkillId = c.Int(),
                        Value = c.Int(nullable: false),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Characters", t => t.CharacterId)
                .Index(t => t.CharacterId);
            
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
                        BankId = c.Int(),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Banks", t => t.BankId)
                .Index(t => t.BankId);
            
            CreateTable(
                "dbo.UserActions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ActionOccurredAt = c.DateTime(nullable: false),
                        OriginatedFromIpAddress = c.String(maxLength: 50),
                        ActionType = c.Int(nullable: false),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.GameStates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Sessionstart = c.DateTime(nullable: false),
                        SessionEnd = c.DateTime(nullable: false),
                        Year = c.Int(nullable: false),
                        MonthId = c.Long(nullable: false),
                        Day = c.Int(nullable: false),
                        Hour = c.Int(nullable: false),
                        Minute = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Auctions", "InstanceId", "dbo.Instances");
            DropForeignKey("dbo.Auctions", "CharacterId", "dbo.Characters");
            DropForeignKey("dbo.AuctionBids", "CharacterId", "dbo.Characters");
            DropForeignKey("dbo.Characters", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "BankId", "dbo.Banks");
            DropForeignKey("dbo.UserActions", "UserId", "dbo.Users");
            DropForeignKey("dbo.CharacterStatistics", "CharacterId", "dbo.Characters");
            DropForeignKey("dbo.CharacterProperties", "PropertyId", "dbo.Properties");
            DropForeignKey("dbo.CharacterProperties", "CharacterId", "dbo.Characters");
            DropForeignKey("dbo.CharacterMailItems", "Instance_Id", "dbo.Instances");
            DropForeignKey("dbo.CharacterMailItems", "CharacterMailId", "dbo.CharacterMailbox");
            DropForeignKey("dbo.CharacterMailbox", "CharacterId", "dbo.Characters");
            DropForeignKey("dbo.CharacterItems", "InstanceId", "dbo.Instances");
            DropForeignKey("dbo.CharacterItems", "ContainedInItemId", "dbo.Instances");
            DropForeignKey("dbo.CharacterItems", "CharacterId", "dbo.Characters");
            DropForeignKey("dbo.Characters", "GuildId", "dbo.Guilds");
            DropForeignKey("dbo.Guilds", "OfficerChannelId", "dbo.Channels");
            DropForeignKey("dbo.GuildMembers", "GuildId", "dbo.Guilds");
            DropForeignKey("dbo.GuildMembers", "Character_Id", "dbo.Characters");
            DropForeignKey("dbo.Guilds", "MemberChannelId", "dbo.Channels");
            DropForeignKey("dbo.Guilds", "BankId", "dbo.Banks");
            DropForeignKey("dbo.GuildAbilities", "GuildId", "dbo.Guilds");
            DropForeignKey("dbo.CharacterFactions", "CharacterId", "dbo.Characters");
            DropForeignKey("dbo.CharacterChannels", "CharacterId", "dbo.Characters");
            DropForeignKey("dbo.CharacterChannels", "ChannelId", "dbo.Channels");
            DropForeignKey("dbo.Channels", "OwnerId", "dbo.Characters");
            DropForeignKey("dbo.Characters", "BankId", "dbo.Banks");
            DropForeignKey("dbo.BankLogs", "BankId", "dbo.Banks");
            DropForeignKey("dbo.BankItems", "InstanceId", "dbo.Instances");
            DropForeignKey("dbo.BankItems", "BankId", "dbo.Banks");
            DropForeignKey("dbo.CharacterAuctions", "CharacterId", "dbo.Characters");
            DropForeignKey("dbo.CharacterAuctions", "Auction_Id", "dbo.Auctions");
            DropForeignKey("dbo.CharacterAbilities", "CharacterId", "dbo.Characters");
            DropForeignKey("dbo.AuctionBids", "Auction_Id", "dbo.Auctions");
            DropIndex("dbo.UserActions", new[] { "UserId" });
            DropIndex("dbo.Users", new[] { "BankId" });
            DropIndex("dbo.CharacterStatistics", new[] { "CharacterId" });
            DropIndex("dbo.CharacterProperties", new[] { "PropertyId" });
            DropIndex("dbo.CharacterProperties", new[] { "CharacterId" });
            DropIndex("dbo.CharacterMailItems", new[] { "Instance_Id" });
            DropIndex("dbo.CharacterMailItems", new[] { "CharacterMailId" });
            DropIndex("dbo.CharacterMailbox", new[] { "CharacterId" });
            DropIndex("dbo.CharacterItems", new[] { "ContainedInItemId" });
            DropIndex("dbo.CharacterItems", new[] { "InstanceId" });
            DropIndex("dbo.CharacterItems", new[] { "CharacterId" });
            DropIndex("dbo.GuildMembers", new[] { "Character_Id" });
            DropIndex("dbo.GuildMembers", new[] { "GuildId" });
            DropIndex("dbo.GuildAbilities", new[] { "GuildId" });
            DropIndex("dbo.Guilds", new[] { "BankId" });
            DropIndex("dbo.Guilds", new[] { "OfficerChannelId" });
            DropIndex("dbo.Guilds", new[] { "MemberChannelId" });
            DropIndex("dbo.CharacterFactions", new[] { "CharacterId" });
            DropIndex("dbo.Channels", new[] { "OwnerId" });
            DropIndex("dbo.CharacterChannels", new[] { "ChannelId" });
            DropIndex("dbo.CharacterChannels", new[] { "CharacterId" });
            DropIndex("dbo.BankLogs", new[] { "BankId" });
            DropIndex("dbo.BankItems", new[] { "InstanceId" });
            DropIndex("dbo.BankItems", new[] { "BankId" });
            DropIndex("dbo.CharacterAuctions", new[] { "Auction_Id" });
            DropIndex("dbo.CharacterAuctions", new[] { "CharacterId" });
            DropIndex("dbo.CharacterAbilities", new[] { "CharacterId" });
            DropIndex("dbo.Characters", new[] { "BankId" });
            DropIndex("dbo.Characters", new[] { "GuildId" });
            DropIndex("dbo.Characters", new[] { "UserId" });
            DropIndex("dbo.AuctionBids", new[] { "Auction_Id" });
            DropIndex("dbo.AuctionBids", new[] { "CharacterId" });
            DropIndex("dbo.Auctions", new[] { "CharacterId" });
            DropIndex("dbo.Auctions", new[] { "InstanceId" });
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
