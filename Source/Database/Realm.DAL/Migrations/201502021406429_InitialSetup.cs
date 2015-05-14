namespace Realm.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialSetup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Entities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreateDateUtc = c.DateTime(),
                        SystemName = c.String(maxLength: 255),
                        Discriminator = c.String(maxLength: 128),
                        DisplayName_Id = c.Int(),
                        SystemClass_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Strings", t => t.DisplayName_Id)
                .ForeignKey("dbo.SystemClasses", t => t.SystemClass_Id)
                .Index(t => t.DisplayName_Id)
                .Index(t => t.SystemClass_Id);
            
            CreateTable(
                "dbo.SystemClasses",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(maxLength: 50),
                        ParentClassId = c.Int(),
                        SystemType = c.Int(nullable: false),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SystemClasses", t => t.ParentClassId)
                .Index(t => t.ParentClassId);
            
            CreateTable(
                "dbo.Colors",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Ascii = c.String(maxLength: 2),
                        Escape = c.String(maxLength: 10),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        IsItemEvent = c.Boolean(nullable: false),
                        IsMobileEvent = c.Boolean(nullable: false),
                        IsSpaceEvent = c.Boolean(nullable: false),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MovementModes",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                        Value = c.Int(nullable: false),
                        ShortNamne = c.String(),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WearLocations",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                        Value = c.Int(nullable: false),
                        ShortNamne = c.String(),
                        LongName = c.String(),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Elements",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        OppositeElementId = c.Int(nullable: false),
                        LeftElementId = c.Int(nullable: false),
                        RightElementId = c.Int(nullable: false),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Bits",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Value = c.Int(nullable: false),
                        BitType = c.Int(nullable: false),
                        Description = c.String(maxLength: 1024),
                        UniqueGroup = c.String(maxLength: 255),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GuildLevels",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Level = c.Int(nullable: false),
                        XpRequired = c.Int(nullable: false),
                        MaxNumberOfMembers = c.Int(nullable: false),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Abilities",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        BeginUseText_Id = c.Int(),
                        DisplayDescription_Id = c.Int(nullable: false),
                        Effects_Id = c.Int(),
                        GuildUpgrades_Id = c.Int(),
                        InterruptionEffect_Id = c.Int(),
                        InterruptionResistSkill_Id = c.Int(),
                        Prerequisites_Id = c.Int(),
                        Reagants_Id = c.Int(),
                        TagSet_Id = c.Int(),
                        Terrain_Id = c.Int(),
                        UseText_Id = c.Int(),
                        VerbalText_Id = c.Int(),
                        ManaCost = c.Int(nullable: false),
                        StaminaCost = c.Int(nullable: false),
                        PreDelay = c.Single(nullable: false),
                        PostDelay = c.Single(nullable: false),
                        OffensiveStat = c.Int(nullable: false),
                        DefensiveStat = c.Int(nullable: false),
                        Bits = c.Int(nullable: false),
                        RechargeRate = c.Single(nullable: false),
                        TargetClass = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.Strings", t => t.BeginUseText_Id)
                .ForeignKey("dbo.Strings", t => t.DisplayDescription_Id)
                .ForeignKey("dbo.AbilityEffects", t => t.Effects_Id)
                .ForeignKey("dbo.GuildAbilities", t => t.GuildUpgrades_Id)
                .ForeignKey("dbo.Effects", t => t.InterruptionEffect_Id)
                .ForeignKey("dbo.Skills", t => t.InterruptionResistSkill_Id)
                .ForeignKey("dbo.AbilityPrerequisites", t => t.Prerequisites_Id)
                .ForeignKey("dbo.AbilityReagants", t => t.Reagants_Id)
                .ForeignKey("dbo.TagSets", t => t.TagSet_Id)
                .ForeignKey("dbo.Terrains", t => t.Terrain_Id)
                .ForeignKey("dbo.Strings", t => t.UseText_Id)
                .ForeignKey("dbo.Strings", t => t.VerbalText_Id)
                .Index(t => t.Id)
                .Index(t => t.BeginUseText_Id)
                .Index(t => t.DisplayDescription_Id)
                .Index(t => t.Effects_Id)
                .Index(t => t.GuildUpgrades_Id)
                .Index(t => t.InterruptionEffect_Id)
                .Index(t => t.InterruptionResistSkill_Id)
                .Index(t => t.Prerequisites_Id)
                .Index(t => t.Reagants_Id)
                .Index(t => t.TagSet_Id)
                .Index(t => t.Terrain_Id)
                .Index(t => t.UseText_Id)
                .Index(t => t.VerbalText_Id);
            
            CreateTable(
                "dbo.Archetypes",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        DisplayDescription_Id = c.Int(),
                        TagSet_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.Strings", t => t.DisplayDescription_Id)
                .ForeignKey("dbo.TagSets", t => t.TagSet_Id)
                .Index(t => t.Id)
                .Index(t => t.DisplayDescription_Id)
                .Index(t => t.TagSet_Id);
            
            CreateTable(
                "ref.BankUpgrades",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        BankLevel = c.Int(nullable: false),
                        UpgradeCost = c.Int(nullable: false),
                        StackLimit = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Barriers",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        TagSet_Id = c.Int(),
                        MaterialType = c.Int(nullable: false),
                        Bits = c.Int(nullable: false),
                        KeyItemId = c.Int(),
                        LockItemId = c.Int(),
                        TrapItemId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.TagSets", t => t.TagSet_Id)
                .ForeignKey("dbo.Items", t => t.KeyItemId)
                .ForeignKey("dbo.Items", t => t.LockItemId)
                .ForeignKey("dbo.Items", t => t.TrapItemId)
                .Index(t => t.Id)
                .Index(t => t.TagSet_Id)
                .Index(t => t.KeyItemId)
                .Index(t => t.LockItemId)
                .Index(t => t.TrapItemId);
            
            CreateTable(
                "dbo.Behaviors",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        TagSet_Id = c.Int(),
                        Bits = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.TagSets", t => t.TagSet_Id)
                .Index(t => t.Id)
                .Index(t => t.TagSet_Id);
            
            CreateTable(
                "dbo.Conversations",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Keywords_Id = c.Int(),
                        RequiredFaction_Id = c.Int(),
                        TagSet_Id = c.Int(),
                        Text_Id = c.Int(),
                        IsDefault = c.Boolean(nullable: false),
                        RequiredFactionLevel = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.Strings", t => t.Keywords_Id)
                .ForeignKey("dbo.Factions", t => t.RequiredFaction_Id)
                .ForeignKey("dbo.TagSets", t => t.TagSet_Id)
                .ForeignKey("dbo.Strings", t => t.Text_Id)
                .Index(t => t.Id)
                .Index(t => t.Keywords_Id)
                .Index(t => t.RequiredFaction_Id)
                .Index(t => t.TagSet_Id)
                .Index(t => t.Text_Id);
            
            CreateTable(
                "dbo.Effects",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        ApplicationTextOther_Id = c.Int(),
                        ApplicationTextSelf_Id = c.Int(),
                        DisplayDescription_Id = c.Int(),
                        FadeTextOther_Id = c.Int(),
                        FadeTextSelf_Id = c.Int(),
                        TagSet_Id = c.Int(),
                        EffectType = c.Int(nullable: false),
                        Duration = c.Int(nullable: false),
                        Bits = c.Int(nullable: false),
                        ResistStatistic = c.Int(nullable: false),
                        OnFailEffectId = c.Int(),
                        OnResistEffectId = c.Int(),
                        MovementModeBitField = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.Strings", t => t.ApplicationTextOther_Id)
                .ForeignKey("dbo.Strings", t => t.ApplicationTextSelf_Id)
                .ForeignKey("dbo.Strings", t => t.DisplayDescription_Id)
                .ForeignKey("dbo.Strings", t => t.FadeTextOther_Id)
                .ForeignKey("dbo.Strings", t => t.FadeTextSelf_Id)
                .ForeignKey("dbo.TagSets", t => t.TagSet_Id)
                .ForeignKey("dbo.Effects", t => t.OnFailEffectId)
                .ForeignKey("dbo.Effects", t => t.OnResistEffectId)
                .Index(t => t.Id)
                .Index(t => t.ApplicationTextOther_Id)
                .Index(t => t.ApplicationTextSelf_Id)
                .Index(t => t.DisplayDescription_Id)
                .Index(t => t.FadeTextOther_Id)
                .Index(t => t.FadeTextSelf_Id)
                .Index(t => t.TagSet_Id)
                .Index(t => t.OnFailEffectId)
                .Index(t => t.OnResistEffectId);
            
            CreateTable(
                "dbo.Factions",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        TagSet_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.TagSets", t => t.TagSet_Id)
                .Index(t => t.Id)
                .Index(t => t.TagSet_Id);
            
            CreateTable(
                "dbo.GameCommands",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Keywords_Id = c.Int(),
                        TagSet_Id = c.Int(),
                        LogActionType = c.Int(nullable: false),
                        Bits = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.Strings", t => t.Keywords_Id)
                .ForeignKey("dbo.TagSets", t => t.TagSet_Id)
                .Index(t => t.Id)
                .Index(t => t.Keywords_Id)
                .Index(t => t.TagSet_Id);
            
            CreateTable(
                "ref.GameConstants",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 1024),
                        Type = c.String(maxLength: 20),
                        GameConstantCategory = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Helps",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Keywords_Id = c.Int(),
                        Text_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.Strings", t => t.Keywords_Id)
                .ForeignKey("dbo.Strings", t => t.Text_Id)
                .Index(t => t.Id)
                .Index(t => t.Keywords_Id)
                .Index(t => t.Text_Id);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        DisplayDescription_Id = c.Int(),
                        ItemSet_Id = c.Int(),
                        TagSet_Id = c.Int(),
                        TrapItem_Id = c.Int(),
                        UseAbility_Id = c.Int(),
                        ItemType = c.Int(nullable: false),
                        Weight = c.Int(nullable: false),
                        MaterialType = c.Int(nullable: false),
                        CoinValue = c.Int(nullable: false),
                        SizeType = c.Int(nullable: false),
                        MaxStackSize = c.Int(nullable: false),
                        Bits = c.Int(nullable: false),
                        ConditionType = c.Int(nullable: false),
                        UseAbilityFrequency = c.Int(nullable: false),
                        SpotStatistic = c.Int(nullable: false),
                        SpotDifficultyType = c.Int(nullable: false),
                        ItemClassType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.Strings", t => t.DisplayDescription_Id)
                .ForeignKey("dbo.ItemSets", t => t.ItemSet_Id)
                .ForeignKey("dbo.TagSets", t => t.TagSet_Id)
                .ForeignKey("dbo.Items", t => t.TrapItem_Id)
                .ForeignKey("dbo.Abilities", t => t.UseAbility_Id)
                .Index(t => t.Id)
                .Index(t => t.DisplayDescription_Id)
                .Index(t => t.ItemSet_Id)
                .Index(t => t.TagSet_Id)
                .Index(t => t.TrapItem_Id)
                .Index(t => t.UseAbility_Id);
            
            CreateTable(
                "dbo.ItemSets",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        DisplayDescription_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.Strings", t => t.DisplayDescription_Id)
                .Index(t => t.Id)
                .Index(t => t.DisplayDescription_Id);
            
            CreateTable(
                "dbo.Liquids",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Color_Id = c.Int(),
                        DisplayDescription_Id = c.Int(),
                        TagSet_Id = c.Int(),
                        ThirstPoints = c.Int(nullable: false),
                        DrunkPoints = c.Int(nullable: false),
                        CostPerCharge = c.Single(nullable: false),
                        FlammabilityType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.Colors", t => t.Color_Id)
                .ForeignKey("dbo.Strings", t => t.DisplayDescription_Id)
                .ForeignKey("dbo.TagSets", t => t.TagSet_Id)
                .Index(t => t.Id)
                .Index(t => t.Color_Id)
                .Index(t => t.DisplayDescription_Id)
                .Index(t => t.TagSet_Id);
            
            CreateTable(
                "dbo.Mobiles",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Conversation_Id = c.Int(),
                        DisplayDescription_Id = c.Int(),
                        Faction_Id = c.Int(),
                        Race_Id = c.Int(),
                        TagSet_Id = c.Int(),
                        SizeType = c.Int(nullable: false),
                        MobileType = c.Int(nullable: false),
                        Bits = c.Int(nullable: false),
                        AccessLevel = c.Int(nullable: false),
                        GenderType = c.Int(nullable: false),
                        Level = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.Conversations", t => t.Conversation_Id)
                .ForeignKey("dbo.Strings", t => t.DisplayDescription_Id)
                .ForeignKey("dbo.Factions", t => t.Faction_Id)
                .ForeignKey("dbo.Races", t => t.Race_Id)
                .ForeignKey("dbo.TagSets", t => t.TagSet_Id)
                .Index(t => t.Id)
                .Index(t => t.Conversation_Id)
                .Index(t => t.DisplayDescription_Id)
                .Index(t => t.Faction_Id)
                .Index(t => t.Race_Id)
                .Index(t => t.TagSet_Id);
            
            CreateTable(
                "dbo.Months",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        NumberDays = c.Int(nullable: false),
                        SeasonType = c.Int(nullable: false),
                        IsShrouding = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.MudProgs",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Data_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.Strings", t => t.Data_Id)
                .Index(t => t.Id)
                .Index(t => t.Data_Id);
            
            CreateTable(
                "dbo.Quests",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        DisplayDescription_Id = c.Int(),
                        TagSet_Id = c.Int(),
                        Bits = c.Int(nullable: false),
                        Timer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.Strings", t => t.DisplayDescription_Id)
                .ForeignKey("dbo.TagSets", t => t.TagSet_Id)
                .Index(t => t.Id)
                .Index(t => t.DisplayDescription_Id)
                .Index(t => t.TagSet_Id);
            
            CreateTable(
                "dbo.Races",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        DisplayDescription_Id = c.Int(),
                        TagSet_Id = c.Int(),
                        Bits = c.Int(nullable: false),
                        SizeType = c.Int(nullable: false),
                        BaseHealth = c.Int(nullable: false),
                        BaseMana = c.Int(nullable: false),
                        BaseStamina = c.Int(nullable: false),
                        Abbreviation = c.String(maxLength: 5),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.Strings", t => t.DisplayDescription_Id)
                .ForeignKey("dbo.TagSets", t => t.TagSet_Id)
                .Index(t => t.Id)
                .Index(t => t.DisplayDescription_Id)
                .Index(t => t.TagSet_Id);
            
            CreateTable(
                "dbo.Resets",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Object_Id = c.Int(),
                        Space_Id = c.Int(),
                        ResetType = c.Int(nullable: false),
                        ResetLocationType = c.Int(nullable: false),
                        Limit = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Object_Id)
                .ForeignKey("dbo.Spaces", t => t.Space_Id)
                .Index(t => t.Id)
                .Index(t => t.Object_Id)
                .Index(t => t.Space_Id);
            
            CreateTable(
                "dbo.Rituals",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        DisplayDescription_Id = c.Int(),
                        MagicalNodeItem_Id = c.Int(),
                        TagSet_Id = c.Int(),
                        CastTime = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.Strings", t => t.DisplayDescription_Id)
                .ForeignKey("dbo.Items", t => t.MagicalNodeItem_Id)
                .ForeignKey("dbo.TagSets", t => t.TagSet_Id)
                .Index(t => t.Id)
                .Index(t => t.DisplayDescription_Id)
                .Index(t => t.MagicalNodeItem_Id)
                .Index(t => t.TagSet_Id);
            
            CreateTable(
                "dbo.Shops",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        BuyMarkup = c.Int(nullable: false),
                        SellMarkup = c.Int(nullable: false),
                        Bits = c.Int(nullable: false),
                        ShopType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.SkillCategories",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Statistic = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        DisplayDescription_Id = c.Int(),
                        ParentSkill_Id = c.Int(),
                        SkillCategory_Id = c.Int(),
                        Statistic = c.Int(nullable: false),
                        MaxValue = c.Int(nullable: false),
                        IsMasterable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.Strings", t => t.DisplayDescription_Id)
                .ForeignKey("dbo.Skills", t => t.ParentSkill_Id)
                .ForeignKey("dbo.SkillCategories", t => t.SkillCategory_Id)
                .Index(t => t.Id)
                .Index(t => t.DisplayDescription_Id)
                .Index(t => t.ParentSkill_Id)
                .Index(t => t.SkillCategory_Id);
            
            CreateTable(
                "dbo.Socials",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        CharAuto_Id = c.Int(),
                        CharFound_Id = c.Int(),
                        CharNoArg_Id = c.Int(),
                        OthersAuto_Id = c.Int(),
                        OthersFound_Id = c.Int(),
                        OthersNoArg_Id = c.Int(),
                        VictFound_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.Strings", t => t.CharAuto_Id)
                .ForeignKey("dbo.Strings", t => t.CharFound_Id)
                .ForeignKey("dbo.Strings", t => t.CharNoArg_Id)
                .ForeignKey("dbo.Strings", t => t.OthersAuto_Id)
                .ForeignKey("dbo.Strings", t => t.OthersFound_Id)
                .ForeignKey("dbo.Strings", t => t.OthersNoArg_Id)
                .ForeignKey("dbo.Strings", t => t.VictFound_Id)
                .Index(t => t.Id)
                .Index(t => t.CharAuto_Id)
                .Index(t => t.CharFound_Id)
                .Index(t => t.CharNoArg_Id)
                .Index(t => t.OthersAuto_Id)
                .Index(t => t.OthersFound_Id)
                .Index(t => t.OthersNoArg_Id)
                .Index(t => t.VictFound_Id);
            
            CreateTable(
                "dbo.Spaces",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        DisplayDescription_Id = c.Int(),
                        TagSet_Id = c.Int(),
                        Terrain_Id = c.Int(),
                        Bits = c.Int(nullable: false),
                        AccessLevel = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.Strings", t => t.DisplayDescription_Id)
                .ForeignKey("dbo.TagSets", t => t.TagSet_Id)
                .ForeignKey("dbo.Terrains", t => t.Terrain_Id)
                .Index(t => t.Id)
                .Index(t => t.DisplayDescription_Id)
                .Index(t => t.TagSet_Id)
                .Index(t => t.Terrain_Id);
            
            CreateTable(
                "dbo.Spawns",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        TagSet_Id = c.Int(),
                        MinQuantity = c.Int(nullable: false),
                        MaxQuantity = c.Int(nullable: false),
                        Chance = c.Int(nullable: false),
                        RespawnPeriod = c.Int(nullable: false),
                        SpawnType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.TagSets", t => t.TagSet_Id)
                .Index(t => t.Id)
                .Index(t => t.TagSet_Id);
            
            CreateTable(
                "dbo.Strings",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        StringType = c.Int(nullable: false),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        TagSet_Id = c.Int(),
                        TagCategory = c.Int(nullable: false),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.TagSets", t => t.TagSet_Id)
                .Index(t => t.Id)
                .Index(t => t.TagSet_Id);
            
            CreateTable(
                "dbo.TagSets",
                c => new
                    {
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Terrains",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        DisplayDescription_Id = c.Int(),
                        Skill_Id = c.Int(),
                        Bits = c.Int(nullable: false),
                        MovementCost = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.Strings", t => t.DisplayDescription_Id)
                .ForeignKey("dbo.Skills", t => t.Skill_Id)
                .Index(t => t.Id)
                .Index(t => t.DisplayDescription_Id)
                .Index(t => t.Skill_Id);
            
            CreateTable(
                "dbo.Treasures",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        SystemDescription_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.Strings", t => t.SystemDescription_Id)
                .Index(t => t.Id)
                .Index(t => t.SystemDescription_Id);
            
            CreateTable(
                "dbo.Zones",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        DisplayDescription_Id = c.Int(),
                        TagSet_Id = c.Int(),
                        Bits = c.Int(nullable: false),
                        RecycleTime = c.Int(nullable: false),
                        MaxDynamicZones = c.Int(nullable: false),
                        MinDyanmicZoneFrequencySeconds = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.Strings", t => t.DisplayDescription_Id)
                .ForeignKey("dbo.TagSets", t => t.TagSet_Id)
                .Index(t => t.Id)
                .Index(t => t.DisplayDescription_Id)
                .Index(t => t.TagSet_Id);
            
            CreateTable(
                "dbo.ItemFormulas",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Skill_Id = c.Int(),
                        Item_Id = c.Int(),
                        SkillValue = c.Int(nullable: false),
                        ProductItemId = c.Int(nullable: false),
                        ProductQuantity = c.Int(nullable: false),
                        MachineItemId = c.Int(),
                        ToolItemId = c.Int(),
                        ExperienceValue = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.Skills", t => t.Skill_Id)
                .ForeignKey("dbo.Items", t => t.Item_Id)
                .ForeignKey("dbo.Items", t => t.ProductItemId)
                .ForeignKey("dbo.Items", t => t.MachineItemId)
                .ForeignKey("dbo.Items", t => t.ToolItemId)
                .Index(t => t.Id)
                .Index(t => t.Skill_Id)
                .Index(t => t.Item_Id)
                .Index(t => t.ProductItemId)
                .Index(t => t.MachineItemId)
                .Index(t => t.ToolItemId);
            
            CreateTable(
                "dbo.QuestActions",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        JournalEntry_Id = c.Int(),
                        Mobile_Id = c.Int(),
                        MudProg_Id = c.Int(),
                        Quest_Id = c.Int(),
                        IsStart = c.Boolean(nullable: false),
                        Coin = c.Int(nullable: false),
                        Experience = c.Int(nullable: false),
                        GivePrimitiveId = c.Int(),
                        DeletePrimitiveId = c.Int(),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.Strings", t => t.JournalEntry_Id)
                .ForeignKey("dbo.Mobiles", t => t.Mobile_Id)
                .ForeignKey("dbo.MudProgs", t => t.MudProg_Id)
                .ForeignKey("dbo.Quests", t => t.Quest_Id)
                .ForeignKey("dbo.Entities", t => t.GivePrimitiveId)
                .ForeignKey("dbo.Entities", t => t.DeletePrimitiveId)
                .Index(t => t.Id)
                .Index(t => t.JournalEntry_Id)
                .Index(t => t.Mobile_Id)
                .Index(t => t.MudProg_Id)
                .Index(t => t.Quest_Id)
                .Index(t => t.GivePrimitiveId)
                .Index(t => t.DeletePrimitiveId);
            
            CreateTable(
                "dbo.QuestRequirements",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Faction_Id = c.Int(),
                        HasItem_Id = c.Int(),
                        Skill_Id = c.Int(),
                        Quest_Id = c.Int(),
                        RaceId = c.Int(),
                        NotRaceId = c.Int(),
                        Statistic = c.Int(nullable: false),
                        Value = c.Int(nullable: false),
                        Level = c.Int(nullable: false),
                        QuestCompletedId = c.Int(),
                        QuestNotCompletedId = c.Int(),
                        FactionLevel = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.Factions", t => t.Faction_Id)
                .ForeignKey("dbo.Items", t => t.HasItem_Id)
                .ForeignKey("dbo.Skills", t => t.Skill_Id)
                .ForeignKey("dbo.Quests", t => t.Quest_Id)
                .ForeignKey("dbo.Races", t => t.RaceId)
                .ForeignKey("dbo.Races", t => t.NotRaceId)
                .ForeignKey("dbo.Quests", t => t.QuestCompletedId)
                .ForeignKey("dbo.Quests", t => t.QuestNotCompletedId)
                .Index(t => t.Id)
                .Index(t => t.Faction_Id)
                .Index(t => t.HasItem_Id)
                .Index(t => t.Skill_Id)
                .Index(t => t.Quest_Id)
                .Index(t => t.RaceId)
                .Index(t => t.NotRaceId)
                .Index(t => t.QuestCompletedId)
                .Index(t => t.QuestNotCompletedId);
            
            CreateTable(
                "dbo.AbilityEffects",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Effect_Id = c.Int(),
                        TargetClass = c.Int(nullable: false),
                        MaxNumber = c.Int(nullable: false),
                        AbilityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.Effects", t => t.Effect_Id)
                .ForeignKey("dbo.Abilities", t => t.AbilityId)
                .Index(t => t.Id)
                .Index(t => t.Effect_Id)
                .Index(t => t.AbilityId);
            
            CreateTable(
                "dbo.EffectDynamicZones",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Zone_Id = c.Int(),
                        Effect_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.Zones", t => t.Zone_Id)
                .ForeignKey("dbo.Effects", t => t.Effect_Id)
                .Index(t => t.Id)
                .Index(t => t.Zone_Id)
                .Index(t => t.Effect_Id);
            
            CreateTable(
                "dbo.ZoneAccesses",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        AccessName_Id = c.Int(),
                        Zone_Id = c.Int(),
                        AccessValue = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.Strings", t => t.AccessName_Id)
                .ForeignKey("dbo.Zones", t => t.Zone_Id)
                .Index(t => t.Id)
                .Index(t => t.AccessName_Id)
                .Index(t => t.Zone_Id);
            
            CreateTable(
                "dbo.ZoneDynamics",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Ability_Id = c.Int(),
                        Mobile_Id = c.Int(),
                        Zone_Id = c.Int(),
                        MaxNumberOfSpaces = c.Int(nullable: false),
                        MinNumberOfSpaces = c.Int(nullable: false),
                        DecayTimeInSeconds = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.Abilities", t => t.Ability_Id)
                .ForeignKey("dbo.Mobiles", t => t.Mobile_Id)
                .ForeignKey("dbo.Zones", t => t.Zone_Id)
                .Index(t => t.Id)
                .Index(t => t.Ability_Id)
                .Index(t => t.Mobile_Id)
                .Index(t => t.Zone_Id);
            
            CreateTable(
                "dbo.MobileAbilities",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Ability_Id = c.Int(),
                        Mobile_Id = c.Int(),
                        IsDefault = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.Abilities", t => t.Ability_Id)
                .ForeignKey("dbo.Mobiles", t => t.Mobile_Id)
                .Index(t => t.Id)
                .Index(t => t.Ability_Id)
                .Index(t => t.Mobile_Id);
            
            CreateTable(
                "dbo.MobileAIs",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Behavior_Id = c.Int(),
                        Mobile_Id = c.Int(),
                        MonsterClass = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.Behaviors", t => t.Behavior_Id)
                .ForeignKey("dbo.Mobiles", t => t.Mobile_Id)
                .Index(t => t.Id)
                .Index(t => t.Behavior_Id)
                .Index(t => t.Mobile_Id);
            
            CreateTable(
                "dbo.FactionRelations",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        TargetFaction_Id = c.Int(),
                        FactionRelationshipType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.Factions", t => t.TargetFaction_Id)
                .Index(t => t.Id)
                .Index(t => t.TargetFaction_Id);
            
            CreateTable(
                "dbo.MobileEquipments",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Item_Id = c.Int(),
                        WornAt_Id = c.Int(),
                        Mobile_Id = c.Int(),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.Items", t => t.Item_Id)
                .ForeignKey("dbo.WearLocations", t => t.WornAt_Id)
                .ForeignKey("dbo.Mobiles", t => t.Mobile_Id)
                .Index(t => t.Id)
                .Index(t => t.Item_Id)
                .Index(t => t.WornAt_Id)
                .Index(t => t.Mobile_Id);
            
            CreateTable(
                "dbo.ItemBooks",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Ability_Id = c.Int(),
                        Text_Id = c.Int(),
                        Item_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.Abilities", t => t.Ability_Id)
                .ForeignKey("dbo.Strings", t => t.Text_Id)
                .ForeignKey("dbo.Items", t => t.Item_Id)
                .Index(t => t.Id)
                .Index(t => t.Ability_Id)
                .Index(t => t.Text_Id)
                .Index(t => t.Item_Id);
            
            CreateTable(
                "dbo.ItemContainers",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        LockItem_Id = c.Int(),
                        WeightAllowance = c.Int(nullable: false),
                        VolumeAllowance = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.Items", t => t.LockItem_Id)
                .Index(t => t.Id)
                .Index(t => t.LockItem_Id);
            
            CreateTable(
                "dbo.ItemDrinkContainers",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Liquid_Id = c.Int(),
                        Item_Id = c.Int(),
                        MaxCharges = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.Liquids", t => t.Liquid_Id)
                .ForeignKey("dbo.Items", t => t.Item_Id)
                .Index(t => t.Id)
                .Index(t => t.Liquid_Id)
                .Index(t => t.Item_Id);
            
            CreateTable(
                "dbo.ItemFoods",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        DecayDescription_Id = c.Int(),
                        Item_Id = c.Int(),
                        HungerPoints = c.Int(nullable: false),
                        Charges = c.Int(nullable: false),
                        TimeFoodIsEdibleInSeconds = c.Int(nullable: false),
                        TimeFoodIsDecayingInSeconds = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.Strings", t => t.DecayDescription_Id)
                .ForeignKey("dbo.Items", t => t.Item_Id)
                .Index(t => t.Id)
                .Index(t => t.DecayDescription_Id)
                .Index(t => t.Item_Id);
            
            CreateTable(
                "dbo.ItemFormulaResources",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        ResourceItem_Id = c.Int(),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.Items", t => t.ResourceItem_Id)
                .Index(t => t.Id)
                .Index(t => t.ResourceItem_Id);
            
            CreateTable(
                "dbo.ItemFurnitures",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Item_Id = c.Int(),
                        MaxCapacity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.Items", t => t.Item_Id)
                .Index(t => t.Id)
                .Index(t => t.Item_Id);
            
            CreateTable(
                "dbo.ItemSetBonuses",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Skill_Id = c.Int(),
                        ItemSet_Id = c.Int(),
                        Statistic = c.Int(nullable: false),
                        ValueMod = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.Skills", t => t.Skill_Id)
                .ForeignKey("dbo.ItemSets", t => t.ItemSet_Id)
                .Index(t => t.Id)
                .Index(t => t.Skill_Id)
                .Index(t => t.ItemSet_Id);
            
            CreateTable(
                "dbo.ItemSetItems",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Item_Id = c.Int(),
                        ItemSet_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.Items", t => t.Item_Id)
                .ForeignKey("dbo.ItemSets", t => t.ItemSet_Id)
                .Index(t => t.Id)
                .Index(t => t.Item_Id)
                .Index(t => t.ItemSet_Id);
            
            CreateTable(
                "dbo.ItemLights",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        FuelItem_Id = c.Int(),
                        FuelType = c.Int(nullable: false),
                        Charges = c.Int(nullable: false),
                        BurnRate = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.Items", t => t.FuelItem_Id)
                .Index(t => t.Id)
                .Index(t => t.FuelItem_Id);
            
            CreateTable(
                "dbo.ItemLocks",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        KeyItem_Id = c.Int(),
                        PickSkill_Id = c.Int(),
                        PickStatistic = c.Int(nullable: false),
                        Difficulty = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.Items", t => t.KeyItem_Id)
                .ForeignKey("dbo.Skills", t => t.PickSkill_Id)
                .Index(t => t.Id)
                .Index(t => t.KeyItem_Id)
                .Index(t => t.PickSkill_Id);
            
            CreateTable(
                "dbo.ItemMachines",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Item_Id = c.Int(),
                        MachineType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.Items", t => t.Item_Id)
                .Index(t => t.Id)
                .Index(t => t.Item_Id);
            
            CreateTable(
                "dbo.ItemMagicalNodes",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Effect_Id = c.Int(),
                        Item_Id = c.Int(),
                        Duration = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.Effects", t => t.Effect_Id)
                .ForeignKey("dbo.Items", t => t.Item_Id)
                .Index(t => t.Id)
                .Index(t => t.Effect_Id)
                .Index(t => t.Item_Id);
            
            CreateTable(
                "dbo.ItemMudProgs",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Event_Id = c.Int(),
                        MudProg_Id = c.Int(),
                        Item_Id = c.Int(),
                        PercentChance = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.Events", t => t.Event_Id)
                .ForeignKey("dbo.MudProgs", t => t.MudProg_Id)
                .ForeignKey("dbo.Items", t => t.Item_Id)
                .Index(t => t.Id)
                .Index(t => t.Event_Id)
                .Index(t => t.MudProg_Id)
                .Index(t => t.Item_Id);
            
            CreateTable(
                "dbo.ItemPortals",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Destination_Id = c.Int(),
                        Item_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.Spaces", t => t.Destination_Id)
                .ForeignKey("dbo.Items", t => t.Item_Id)
                .Index(t => t.Id)
                .Index(t => t.Destination_Id)
                .Index(t => t.Item_Id);
            
            CreateTable(
                "dbo.SpacePortals",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Barrier_Id = c.Int(),
                        Keywords_Id = c.Int(),
                        TargetSpace_Id = c.Int(),
                        Direction = c.Int(nullable: false),
                        Bits = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.Barriers", t => t.Barrier_Id)
                .ForeignKey("dbo.Strings", t => t.Keywords_Id)
                .ForeignKey("dbo.Spaces", t => t.TargetSpace_Id)
                .Index(t => t.Id)
                .Index(t => t.Barrier_Id)
                .Index(t => t.Keywords_Id)
                .Index(t => t.TargetSpace_Id);
            
            CreateTable(
                "dbo.TerrainRestrictions",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        MoementMode_Id = c.Int(),
                        Terrain_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.MovementModes", t => t.MoementMode_Id)
                .ForeignKey("dbo.Terrains", t => t.Terrain_Id)
                .Index(t => t.Id)
                .Index(t => t.MoementMode_Id)
                .Index(t => t.Terrain_Id);
            
            CreateTable(
                "dbo.ItemPotions",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Ability_Id = c.Int(),
                        Color_Id = c.Int(),
                        Item_Id = c.Int(),
                        Charges = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.Abilities", t => t.Ability_Id)
                .ForeignKey("dbo.Colors", t => t.Color_Id)
                .ForeignKey("dbo.Items", t => t.Item_Id)
                .Index(t => t.Id)
                .Index(t => t.Ability_Id)
                .Index(t => t.Color_Id)
                .Index(t => t.Item_Id);
            
            CreateTable(
                "dbo.ItemPrerequisites",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Archetype_Id = c.Int(),
                        Faction_Id = c.Int(),
                        Race_Id = c.Int(),
                        Skill_Id = c.Int(),
                        Item_Id = c.Int(),
                        MinLevel = c.Int(nullable: false),
                        FactionLevel = c.Int(nullable: false),
                        Statistic = c.Int(nullable: false),
                        StatisticValue = c.Int(nullable: false),
                        SkillValue = c.Int(nullable: false),
                        Gender = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.Archetypes", t => t.Archetype_Id)
                .ForeignKey("dbo.Factions", t => t.Faction_Id)
                .ForeignKey("dbo.Races", t => t.Race_Id)
                .ForeignKey("dbo.Skills", t => t.Skill_Id)
                .ForeignKey("dbo.Items", t => t.Item_Id)
                .Index(t => t.Id)
                .Index(t => t.Archetype_Id)
                .Index(t => t.Faction_Id)
                .Index(t => t.Race_Id)
                .Index(t => t.Skill_Id)
                .Index(t => t.Item_Id);
            
            CreateTable(
                "dbo.ArchetypeAbilities",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Ability_Id = c.Int(),
                        Archetype_Id = c.Int(),
                        IsExempt = c.Boolean(nullable: false),
                        IsAutoAttack = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.Abilities", t => t.Ability_Id)
                .ForeignKey("dbo.Archetypes", t => t.Archetype_Id)
                .Index(t => t.Id)
                .Index(t => t.Ability_Id)
                .Index(t => t.Archetype_Id);
            
            CreateTable(
                "dbo.ArchetypeSkillCategories",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        SkillCategory_Id = c.Int(),
                        Archetype_Id = c.Int(),
                        IsPreferred = c.Boolean(nullable: false),
                        IsRestricted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.SkillCategories", t => t.SkillCategory_Id)
                .ForeignKey("dbo.Archetypes", t => t.Archetype_Id)
                .Index(t => t.Id)
                .Index(t => t.SkillCategory_Id)
                .Index(t => t.Archetype_Id);
            
            CreateTable(
                "dbo.ArchetypeStatistics",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Skill_Id = c.Int(),
                        Archetype_Id = c.Int(),
                        Statistic = c.Int(nullable: false),
                        ModValue = c.Int(nullable: false),
                        IsExempt = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.Skills", t => t.Skill_Id)
                .ForeignKey("dbo.Archetypes", t => t.Archetype_Id)
                .Index(t => t.Id)
                .Index(t => t.Skill_Id)
                .Index(t => t.Archetype_Id);
            
            CreateTable(
                "dbo.RaceAbilities",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Ability_Id = c.Int(),
                        Race_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.Abilities", t => t.Ability_Id)
                .ForeignKey("dbo.Races", t => t.Race_Id)
                .Index(t => t.Id)
                .Index(t => t.Ability_Id)
                .Index(t => t.Race_Id);
            
            CreateTable(
                "dbo.RaceHitLocations",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        HitLocation_Id = c.Int(),
                        Race_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.WearLocations", t => t.HitLocation_Id)
                .ForeignKey("dbo.Races", t => t.Race_Id)
                .Index(t => t.Id)
                .Index(t => t.HitLocation_Id)
                .Index(t => t.Race_Id);
            
            CreateTable(
                "dbo.RaceStatistics",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Skill_Id = c.Int(),
                        Race_Id = c.Int(),
                        Statistic = c.Int(nullable: false),
                        ValueMod = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.Skills", t => t.Skill_Id)
                .ForeignKey("dbo.Races", t => t.Race_Id)
                .Index(t => t.Id)
                .Index(t => t.Skill_Id)
                .Index(t => t.Race_Id);
            
            CreateTable(
                "dbo.ItemResourceNodes",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        ResourceItem_Id = c.Int(),
                        Skill_Id = c.Int(),
                        ToolType = c.Int(nullable: false),
                        MinSkill = c.Int(nullable: false),
                        MinGatherAmount = c.Int(nullable: false),
                        MaxGatherAmount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.Items", t => t.ResourceItem_Id)
                .ForeignKey("dbo.Skills", t => t.Skill_Id)
                .Index(t => t.Id)
                .Index(t => t.ResourceItem_Id)
                .Index(t => t.Skill_Id);
            
            CreateTable(
                "dbo.ItemStatistics",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Skill_Id = c.Int(),
                        Item_Id = c.Int(),
                        Statistic = c.Int(nullable: false),
                        ValueMod = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.Skills", t => t.Skill_Id)
                .ForeignKey("dbo.Items", t => t.Item_Id)
                .Index(t => t.Id)
                .Index(t => t.Skill_Id)
                .Index(t => t.Item_Id);
            
            CreateTable(
                "dbo.ItemTools",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Item_Id = c.Int(),
                        ToolType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.Items", t => t.Item_Id)
                .Index(t => t.Id)
                .Index(t => t.Item_Id);
            
            CreateTable(
                "dbo.ItemTraps",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        DisarmSkill_Id = c.Int(),
                        OnFailEffect_Id = c.Int(),
                        Item_Id = c.Int(),
                        DisarmStatistic = c.Int(nullable: false),
                        Difficulty = c.Int(nullable: false),
                        OnFailTargetClassType = c.Int(nullable: false),
                        NotifyRadius = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.Skills", t => t.DisarmSkill_Id)
                .ForeignKey("dbo.Effects", t => t.OnFailEffect_Id)
                .ForeignKey("dbo.Items", t => t.Item_Id)
                .Index(t => t.Id)
                .Index(t => t.DisarmSkill_Id)
                .Index(t => t.OnFailEffect_Id)
                .Index(t => t.Item_Id);
            
            CreateTable(
                "dbo.ItemTreasures",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Treasure_Id = c.Int(),
                        Item_Id = c.Int(),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.Treasures", t => t.Treasure_Id)
                .ForeignKey("dbo.Items", t => t.Item_Id)
                .Index(t => t.Id)
                .Index(t => t.Treasure_Id)
                .Index(t => t.Item_Id);
            
            CreateTable(
                "dbo.TreasurePrimitives",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Primitive_Id = c.Int(),
                        Treasure_Id = c.Int(),
                        Weight = c.Int(nullable: false),
                        MaxPulls = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Primitive_Id)
                .ForeignKey("dbo.Treasures", t => t.Treasure_Id)
                .Index(t => t.Id)
                .Index(t => t.Primitive_Id)
                .Index(t => t.Treasure_Id);
            
            CreateTable(
                "dbo.GameCommandPositions",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        GameCommand_Id = c.Int(),
                        PositionType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.GameCommands", t => t.GameCommand_Id)
                .Index(t => t.Id)
                .Index(t => t.GameCommand_Id);
            
            CreateTable(
                "dbo.GameCommandUserStates",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        GameCommand_Id = c.Int(),
                        UserStateType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.GameCommands", t => t.GameCommand_Id)
                .Index(t => t.Id)
                .Index(t => t.GameCommand_Id);
            
            CreateTable(
                "dbo.MonthEffects",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Effect_Id = c.Int(),
                        Month_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.Effects", t => t.Effect_Id)
                .ForeignKey("dbo.Months", t => t.Month_Id)
                .Index(t => t.Id)
                .Index(t => t.Effect_Id)
                .Index(t => t.Month_Id);
            
            CreateTable(
                "dbo.QuestProgresses",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Primitive_Id = c.Int(),
                        ProgressName_Id = c.Int(),
                        Quest_Id = c.Int(),
                        QuestProgressType = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Primitive_Id)
                .ForeignKey("dbo.Strings", t => t.ProgressName_Id)
                .ForeignKey("dbo.Quests", t => t.Quest_Id)
                .Index(t => t.Id)
                .Index(t => t.Primitive_Id)
                .Index(t => t.ProgressName_Id)
                .Index(t => t.Quest_Id);
            
            CreateTable(
                "dbo.AbilityPrerequisites",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Faction_Id = c.Int(),
                        Race_Id = c.Int(),
                        Skill_Id = c.Int(),
                        MinLevel = c.Int(nullable: false),
                        FactionLevel = c.Int(nullable: false),
                        Statistic = c.Int(nullable: false),
                        StatisticValue = c.Int(nullable: false),
                        SkillValue = c.Int(nullable: false),
                        AbilityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.Factions", t => t.Faction_Id)
                .ForeignKey("dbo.Races", t => t.Race_Id)
                .ForeignKey("dbo.Skills", t => t.Skill_Id)
                .ForeignKey("dbo.Abilities", t => t.AbilityId)
                .Index(t => t.Id)
                .Index(t => t.Faction_Id)
                .Index(t => t.Race_Id)
                .Index(t => t.Skill_Id)
                .Index(t => t.AbilityId);
            
            CreateTable(
                "dbo.AbilityReagants",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Item_Id = c.Int(),
                        Quantity = c.Int(nullable: false),
                        AbilityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.Items", t => t.Item_Id)
                .ForeignKey("dbo.Abilities", t => t.AbilityId)
                .Index(t => t.Id)
                .Index(t => t.Item_Id)
                .Index(t => t.AbilityId);
            
            CreateTable(
                "dbo.EffectHealthChanges",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Effect_Id = c.Int(),
                        HealthChangeType = c.Int(nullable: false),
                        ChangeMin = c.Int(nullable: false),
                        ChangeMax = c.Int(nullable: false),
                        DamageType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.Effects", t => t.Effect_Id)
                .Index(t => t.Id)
                .Index(t => t.Effect_Id);
            
            CreateTable(
                "dbo.EffectPositions",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Effect_Id = c.Int(),
                        PositionType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.Effects", t => t.Effect_Id)
                .Index(t => t.Id)
                .Index(t => t.Effect_Id);
            
            CreateTable(
                "dbo.EffectPrimitives",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Primitive_Id = c.Int(),
                        Effect_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Primitive_Id)
                .ForeignKey("dbo.Effects", t => t.Effect_Id)
                .Index(t => t.Id)
                .Index(t => t.Primitive_Id)
                .Index(t => t.Effect_Id);
            
            CreateTable(
                "dbo.EffectStatMods",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        AffectedSkill_Id = c.Int(),
                        Element_Id = c.Int(),
                        Effect_Id = c.Int(),
                        AffectedStatistic = c.Int(nullable: false),
                        MinValue = c.Int(nullable: false),
                        MaxValue = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.Skills", t => t.AffectedSkill_Id)
                .ForeignKey("dbo.Elements", t => t.Element_Id)
                .ForeignKey("dbo.Effects", t => t.Effect_Id)
                .Index(t => t.Id)
                .Index(t => t.AffectedSkill_Id)
                .Index(t => t.Element_Id)
                .Index(t => t.Effect_Id);
            
            CreateTable(
                "dbo.GuildAbilities",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Ability_Id = c.Int(),
                        Cost = c.Int(nullable: false),
                        RequiredLevel = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.Abilities", t => t.Ability_Id)
                .Index(t => t.Id)
                .Index(t => t.Ability_Id);
            
            CreateTable(
                "dbo.ItemVehicles",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Item_Id = c.Int(),
                        MaxCapacity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.Items", t => t.Item_Id)
                .Index(t => t.Id)
                .Index(t => t.Item_Id);
            
            CreateTable(
                "dbo.ItemVehicleTerrains",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Terrain_Id = c.Int(),
                        Item_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.Terrains", t => t.Terrain_Id)
                .ForeignKey("dbo.Items", t => t.Item_Id)
                .Index(t => t.Id)
                .Index(t => t.Terrain_Id)
                .Index(t => t.Item_Id);
            
            CreateTable(
                "dbo.ItemWeapons",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Skill_Id = c.Int(),
                        Item_Id = c.Int(),
                        DamageType = c.Int(nullable: false),
                        MinDamage = c.Int(nullable: false),
                        MaxDamage = c.Int(nullable: false),
                        SpeedClassType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.Skills", t => t.Skill_Id)
                .ForeignKey("dbo.Items", t => t.Item_Id)
                .Index(t => t.Id)
                .Index(t => t.Skill_Id)
                .Index(t => t.Item_Id);
            
            CreateTable(
                "dbo.ItemWearLocations",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        WornAt_Id = c.Int(),
                        Item_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.WearLocations", t => t.WornAt_Id)
                .ForeignKey("dbo.Items", t => t.Item_Id)
                .Index(t => t.Id)
                .Index(t => t.WornAt_Id)
                .Index(t => t.Item_Id);
            
            CreateTable(
                "dbo.MobileMudProgs",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Event_Id = c.Int(),
                        MudProg_Id = c.Int(),
                        Mobile_Id = c.Int(),
                        PercentChance = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.Events", t => t.Event_Id)
                .ForeignKey("dbo.MudProgs", t => t.MudProg_Id)
                .ForeignKey("dbo.Mobiles", t => t.Mobile_Id)
                .Index(t => t.Id)
                .Index(t => t.Event_Id)
                .Index(t => t.MudProg_Id)
                .Index(t => t.Mobile_Id);
            
            CreateTable(
                "dbo.MobileResources",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        NodeItem_Id = c.Int(),
                        Mobile_Id = c.Int(),
                        NodeType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.Items", t => t.NodeItem_Id)
                .ForeignKey("dbo.Mobiles", t => t.Mobile_Id)
                .Index(t => t.Id)
                .Index(t => t.NodeItem_Id)
                .Index(t => t.Mobile_Id);
            
            CreateTable(
                "dbo.MobileStatistics",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Skill_Id = c.Int(),
                        Mobile_Id = c.Int(),
                        Statistic = c.Int(nullable: false),
                        Value = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.Skills", t => t.Skill_Id)
                .ForeignKey("dbo.Mobiles", t => t.Mobile_Id)
                .Index(t => t.Id)
                .Index(t => t.Skill_Id)
                .Index(t => t.Mobile_Id);
            
            CreateTable(
                "dbo.MobileTreasures",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Mobile_Id = c.Int(),
                        MinPulls = c.Int(nullable: false),
                        MaxPulls = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.Mobiles", t => t.Mobile_Id)
                .Index(t => t.Id)
                .Index(t => t.Mobile_Id);
            
            CreateTable(
                "dbo.MobileTreasureTables",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Treasure_Id = c.Int(),
                        Mobile_Id = c.Int(),
                        MinCoin = c.Int(nullable: false),
                        MaxCoin = c.Int(nullable: false),
                        Weight = c.Int(nullable: false),
                        MaxPulls = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.Treasures", t => t.Treasure_Id)
                .ForeignKey("dbo.Mobiles", t => t.Mobile_Id)
                .Index(t => t.Id)
                .Index(t => t.Treasure_Id)
                .Index(t => t.Mobile_Id);
            
            CreateTable(
                "dbo.MobileVendor",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Shop_Id = c.Int(),
                        Mobile_Id = c.Int(),
                        Value = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.Shops", t => t.Shop_Id)
                .ForeignKey("dbo.Mobiles", t => t.Mobile_Id)
                .Index(t => t.Id)
                .Index(t => t.Shop_Id)
                .Index(t => t.Mobile_Id);
            
            CreateTable(
                "dbo.ShopBuyTypes",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Shop_Id = c.Int(),
                        ItemType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.Shops", t => t.Shop_Id)
                .Index(t => t.Id)
                .Index(t => t.Shop_Id);
            
            CreateTable(
                "dbo.ShopPrimitives",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Primitive_Id = c.Int(),
                        Shop_Id = c.Int(),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Primitive_Id)
                .ForeignKey("dbo.Shops", t => t.Shop_Id)
                .Index(t => t.Id)
                .Index(t => t.Primitive_Id)
                .Index(t => t.Shop_Id);
            
            CreateTable(
                "dbo.RitualEffects",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Effect_Id = c.Int(),
                        Ritual_Id = c.Int(),
                        TargetClassType = c.Int(nullable: false),
                        Bits = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.Effects", t => t.Effect_Id)
                .ForeignKey("dbo.Rituals", t => t.Ritual_Id)
                .Index(t => t.Id)
                .Index(t => t.Effect_Id)
                .Index(t => t.Ritual_Id);
            
            CreateTable(
                "dbo.RitualParticipants",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        FocusItem_Id = c.Int(),
                        WearLocation_Id = c.Int(),
                        Ritual_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.Items", t => t.FocusItem_Id)
                .ForeignKey("dbo.WearLocations", t => t.WearLocation_Id)
                .ForeignKey("dbo.Rituals", t => t.Ritual_Id)
                .Index(t => t.Id)
                .Index(t => t.FocusItem_Id)
                .Index(t => t.WearLocation_Id)
                .Index(t => t.Ritual_Id);
            
            CreateTable(
                "dbo.RitualReagants",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        ReagantItem_Id = c.Int(),
                        Ritual_Id = c.Int(),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.Items", t => t.ReagantItem_Id)
                .ForeignKey("dbo.Rituals", t => t.Ritual_Id)
                .Index(t => t.Id)
                .Index(t => t.ReagantItem_Id)
                .Index(t => t.Ritual_Id);
            
            CreateTable(
                "dbo.RitualRequirements",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Faction_Id = c.Int(),
                        Race_Id = c.Int(),
                        Ritual_Id = c.Int(),
                        MinLevel = c.Int(nullable: false),
                        FactionLevel = c.Int(nullable: false),
                        Statistic = c.Int(nullable: false),
                        MinValue = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.Factions", t => t.Faction_Id)
                .ForeignKey("dbo.Races", t => t.Race_Id)
                .ForeignKey("dbo.Rituals", t => t.Ritual_Id)
                .Index(t => t.Id)
                .Index(t => t.Faction_Id)
                .Index(t => t.Race_Id)
                .Index(t => t.Ritual_Id);
            
            CreateTable(
                "dbo.SpawnLocations",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Space_Id = c.Int(),
                        Spawn_Id = c.Int(),
                        AccessLevel = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.Spaces", t => t.Space_Id)
                .ForeignKey("dbo.Spawns", t => t.Spawn_Id)
                .Index(t => t.Id)
                .Index(t => t.Space_Id)
                .Index(t => t.Spawn_Id);
            
            CreateTable(
                "dbo.SpawnPrimitives",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Primitive_Id = c.Int(),
                        Spawn_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Primitive_Id)
                .ForeignKey("dbo.Spawns", t => t.Spawn_Id)
                .Index(t => t.Id)
                .Index(t => t.Primitive_Id)
                .Index(t => t.Spawn_Id);
            
            CreateTable(
                "dbo.ZoneResets",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Reset_Id = c.Int(),
                        Zone_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.Resets", t => t.Reset_Id)
                .ForeignKey("dbo.Zones", t => t.Zone_Id)
                .Index(t => t.Id)
                .Index(t => t.Reset_Id)
                .Index(t => t.Zone_Id);
            
            CreateTable(
                "dbo.ZoneSpaces",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Space_Id = c.Int(),
                        Zone_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.Spaces", t => t.Space_Id)
                .ForeignKey("dbo.Zones", t => t.Zone_Id)
                .Index(t => t.Id)
                .Index(t => t.Space_Id)
                .Index(t => t.Zone_Id);
            
            CreateTable(
                "dbo.ZoneSpawns",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Spawn_Id = c.Int(),
                        Zone_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .ForeignKey("dbo.Spawns", t => t.Spawn_Id)
                .ForeignKey("dbo.Zones", t => t.Zone_Id)
                .Index(t => t.Id)
                .Index(t => t.Spawn_Id)
                .Index(t => t.Zone_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ZoneSpawns", "Zone_Id", "dbo.Zones");
            DropForeignKey("dbo.ZoneSpawns", "Spawn_Id", "dbo.Spawns");
            DropForeignKey("dbo.ZoneSpawns", "Id", "dbo.Entities");
            DropForeignKey("dbo.ZoneSpaces", "Zone_Id", "dbo.Zones");
            DropForeignKey("dbo.ZoneSpaces", "Space_Id", "dbo.Spaces");
            DropForeignKey("dbo.ZoneSpaces", "Id", "dbo.Entities");
            DropForeignKey("dbo.ZoneResets", "Zone_Id", "dbo.Zones");
            DropForeignKey("dbo.ZoneResets", "Reset_Id", "dbo.Resets");
            DropForeignKey("dbo.ZoneResets", "Id", "dbo.Entities");
            DropForeignKey("dbo.SpawnPrimitives", "Spawn_Id", "dbo.Spawns");
            DropForeignKey("dbo.SpawnPrimitives", "Primitive_Id", "dbo.Entities");
            DropForeignKey("dbo.SpawnPrimitives", "Id", "dbo.Entities");
            DropForeignKey("dbo.SpawnLocations", "Spawn_Id", "dbo.Spawns");
            DropForeignKey("dbo.SpawnLocations", "Space_Id", "dbo.Spaces");
            DropForeignKey("dbo.SpawnLocations", "Id", "dbo.Entities");
            DropForeignKey("dbo.RitualRequirements", "Ritual_Id", "dbo.Rituals");
            DropForeignKey("dbo.RitualRequirements", "Race_Id", "dbo.Races");
            DropForeignKey("dbo.RitualRequirements", "Faction_Id", "dbo.Factions");
            DropForeignKey("dbo.RitualRequirements", "Id", "dbo.Entities");
            DropForeignKey("dbo.RitualReagants", "Ritual_Id", "dbo.Rituals");
            DropForeignKey("dbo.RitualReagants", "ReagantItem_Id", "dbo.Items");
            DropForeignKey("dbo.RitualReagants", "Id", "dbo.Entities");
            DropForeignKey("dbo.RitualParticipants", "Ritual_Id", "dbo.Rituals");
            DropForeignKey("dbo.RitualParticipants", "WearLocation_Id", "dbo.WearLocations");
            DropForeignKey("dbo.RitualParticipants", "FocusItem_Id", "dbo.Items");
            DropForeignKey("dbo.RitualParticipants", "Id", "dbo.Entities");
            DropForeignKey("dbo.RitualEffects", "Ritual_Id", "dbo.Rituals");
            DropForeignKey("dbo.RitualEffects", "Effect_Id", "dbo.Effects");
            DropForeignKey("dbo.RitualEffects", "Id", "dbo.Entities");
            DropForeignKey("dbo.ShopPrimitives", "Shop_Id", "dbo.Shops");
            DropForeignKey("dbo.ShopPrimitives", "Primitive_Id", "dbo.Entities");
            DropForeignKey("dbo.ShopPrimitives", "Id", "dbo.Entities");
            DropForeignKey("dbo.ShopBuyTypes", "Shop_Id", "dbo.Shops");
            DropForeignKey("dbo.ShopBuyTypes", "Id", "dbo.Entities");
            DropForeignKey("dbo.MobileVendor", "Mobile_Id", "dbo.Mobiles");
            DropForeignKey("dbo.MobileVendor", "Shop_Id", "dbo.Shops");
            DropForeignKey("dbo.MobileVendor", "Id", "dbo.Entities");
            DropForeignKey("dbo.MobileTreasureTables", "Mobile_Id", "dbo.Mobiles");
            DropForeignKey("dbo.MobileTreasureTables", "Treasure_Id", "dbo.Treasures");
            DropForeignKey("dbo.MobileTreasureTables", "Id", "dbo.Entities");
            DropForeignKey("dbo.MobileTreasures", "Mobile_Id", "dbo.Mobiles");
            DropForeignKey("dbo.MobileTreasures", "Id", "dbo.Entities");
            DropForeignKey("dbo.MobileStatistics", "Mobile_Id", "dbo.Mobiles");
            DropForeignKey("dbo.MobileStatistics", "Skill_Id", "dbo.Skills");
            DropForeignKey("dbo.MobileStatistics", "Id", "dbo.Entities");
            DropForeignKey("dbo.MobileResources", "Mobile_Id", "dbo.Mobiles");
            DropForeignKey("dbo.MobileResources", "NodeItem_Id", "dbo.Items");
            DropForeignKey("dbo.MobileResources", "Id", "dbo.Entities");
            DropForeignKey("dbo.MobileMudProgs", "Mobile_Id", "dbo.Mobiles");
            DropForeignKey("dbo.MobileMudProgs", "MudProg_Id", "dbo.MudProgs");
            DropForeignKey("dbo.MobileMudProgs", "Event_Id", "dbo.Events");
            DropForeignKey("dbo.MobileMudProgs", "Id", "dbo.Entities");
            DropForeignKey("dbo.ItemWearLocations", "Item_Id", "dbo.Items");
            DropForeignKey("dbo.ItemWearLocations", "WornAt_Id", "dbo.WearLocations");
            DropForeignKey("dbo.ItemWearLocations", "Id", "dbo.Entities");
            DropForeignKey("dbo.ItemWeapons", "Item_Id", "dbo.Items");
            DropForeignKey("dbo.ItemWeapons", "Skill_Id", "dbo.Skills");
            DropForeignKey("dbo.ItemWeapons", "Id", "dbo.Entities");
            DropForeignKey("dbo.ItemVehicleTerrains", "Item_Id", "dbo.Items");
            DropForeignKey("dbo.ItemVehicleTerrains", "Terrain_Id", "dbo.Terrains");
            DropForeignKey("dbo.ItemVehicleTerrains", "Id", "dbo.Entities");
            DropForeignKey("dbo.ItemVehicles", "Item_Id", "dbo.Items");
            DropForeignKey("dbo.ItemVehicles", "Id", "dbo.Entities");
            DropForeignKey("dbo.GuildAbilities", "Ability_Id", "dbo.Abilities");
            DropForeignKey("dbo.GuildAbilities", "Id", "dbo.Entities");
            DropForeignKey("dbo.EffectStatMods", "Effect_Id", "dbo.Effects");
            DropForeignKey("dbo.EffectStatMods", "Element_Id", "dbo.Elements");
            DropForeignKey("dbo.EffectStatMods", "AffectedSkill_Id", "dbo.Skills");
            DropForeignKey("dbo.EffectStatMods", "Id", "dbo.Entities");
            DropForeignKey("dbo.EffectPrimitives", "Effect_Id", "dbo.Effects");
            DropForeignKey("dbo.EffectPrimitives", "Primitive_Id", "dbo.Entities");
            DropForeignKey("dbo.EffectPrimitives", "Id", "dbo.Entities");
            DropForeignKey("dbo.EffectPositions", "Effect_Id", "dbo.Effects");
            DropForeignKey("dbo.EffectPositions", "Id", "dbo.Entities");
            DropForeignKey("dbo.EffectHealthChanges", "Effect_Id", "dbo.Effects");
            DropForeignKey("dbo.EffectHealthChanges", "Id", "dbo.Entities");
            DropForeignKey("dbo.AbilityReagants", "AbilityId", "dbo.Abilities");
            DropForeignKey("dbo.AbilityReagants", "Item_Id", "dbo.Items");
            DropForeignKey("dbo.AbilityReagants", "Id", "dbo.Entities");
            DropForeignKey("dbo.AbilityPrerequisites", "AbilityId", "dbo.Abilities");
            DropForeignKey("dbo.AbilityPrerequisites", "Skill_Id", "dbo.Skills");
            DropForeignKey("dbo.AbilityPrerequisites", "Race_Id", "dbo.Races");
            DropForeignKey("dbo.AbilityPrerequisites", "Faction_Id", "dbo.Factions");
            DropForeignKey("dbo.AbilityPrerequisites", "Id", "dbo.Entities");
            DropForeignKey("dbo.QuestProgresses", "Quest_Id", "dbo.Quests");
            DropForeignKey("dbo.QuestProgresses", "ProgressName_Id", "dbo.Strings");
            DropForeignKey("dbo.QuestProgresses", "Primitive_Id", "dbo.Entities");
            DropForeignKey("dbo.QuestProgresses", "Id", "dbo.Entities");
            DropForeignKey("dbo.MonthEffects", "Month_Id", "dbo.Months");
            DropForeignKey("dbo.MonthEffects", "Effect_Id", "dbo.Effects");
            DropForeignKey("dbo.MonthEffects", "Id", "dbo.Entities");
            DropForeignKey("dbo.GameCommandUserStates", "GameCommand_Id", "dbo.GameCommands");
            DropForeignKey("dbo.GameCommandUserStates", "Id", "dbo.Entities");
            DropForeignKey("dbo.GameCommandPositions", "GameCommand_Id", "dbo.GameCommands");
            DropForeignKey("dbo.GameCommandPositions", "Id", "dbo.Entities");
            DropForeignKey("dbo.TreasurePrimitives", "Treasure_Id", "dbo.Treasures");
            DropForeignKey("dbo.TreasurePrimitives", "Primitive_Id", "dbo.Entities");
            DropForeignKey("dbo.TreasurePrimitives", "Id", "dbo.Entities");
            DropForeignKey("dbo.ItemTreasures", "Item_Id", "dbo.Items");
            DropForeignKey("dbo.ItemTreasures", "Treasure_Id", "dbo.Treasures");
            DropForeignKey("dbo.ItemTreasures", "Id", "dbo.Entities");
            DropForeignKey("dbo.ItemTraps", "Item_Id", "dbo.Items");
            DropForeignKey("dbo.ItemTraps", "OnFailEffect_Id", "dbo.Effects");
            DropForeignKey("dbo.ItemTraps", "DisarmSkill_Id", "dbo.Skills");
            DropForeignKey("dbo.ItemTraps", "Id", "dbo.Entities");
            DropForeignKey("dbo.ItemTools", "Item_Id", "dbo.Items");
            DropForeignKey("dbo.ItemTools", "Id", "dbo.Entities");
            DropForeignKey("dbo.ItemStatistics", "Item_Id", "dbo.Items");
            DropForeignKey("dbo.ItemStatistics", "Skill_Id", "dbo.Skills");
            DropForeignKey("dbo.ItemStatistics", "Id", "dbo.Entities");
            DropForeignKey("dbo.ItemResourceNodes", "Skill_Id", "dbo.Skills");
            DropForeignKey("dbo.ItemResourceNodes", "ResourceItem_Id", "dbo.Items");
            DropForeignKey("dbo.ItemResourceNodes", "Id", "dbo.Entities");
            DropForeignKey("dbo.RaceStatistics", "Race_Id", "dbo.Races");
            DropForeignKey("dbo.RaceStatistics", "Skill_Id", "dbo.Skills");
            DropForeignKey("dbo.RaceStatistics", "Id", "dbo.Entities");
            DropForeignKey("dbo.RaceHitLocations", "Race_Id", "dbo.Races");
            DropForeignKey("dbo.RaceHitLocations", "HitLocation_Id", "dbo.WearLocations");
            DropForeignKey("dbo.RaceHitLocations", "Id", "dbo.Entities");
            DropForeignKey("dbo.RaceAbilities", "Race_Id", "dbo.Races");
            DropForeignKey("dbo.RaceAbilities", "Ability_Id", "dbo.Abilities");
            DropForeignKey("dbo.RaceAbilities", "Id", "dbo.Entities");
            DropForeignKey("dbo.ArchetypeStatistics", "Archetype_Id", "dbo.Archetypes");
            DropForeignKey("dbo.ArchetypeStatistics", "Skill_Id", "dbo.Skills");
            DropForeignKey("dbo.ArchetypeStatistics", "Id", "dbo.Entities");
            DropForeignKey("dbo.ArchetypeSkillCategories", "Archetype_Id", "dbo.Archetypes");
            DropForeignKey("dbo.ArchetypeSkillCategories", "SkillCategory_Id", "dbo.SkillCategories");
            DropForeignKey("dbo.ArchetypeSkillCategories", "Id", "dbo.Entities");
            DropForeignKey("dbo.ArchetypeAbilities", "Archetype_Id", "dbo.Archetypes");
            DropForeignKey("dbo.ArchetypeAbilities", "Ability_Id", "dbo.Abilities");
            DropForeignKey("dbo.ArchetypeAbilities", "Id", "dbo.Entities");
            DropForeignKey("dbo.ItemPrerequisites", "Item_Id", "dbo.Items");
            DropForeignKey("dbo.ItemPrerequisites", "Skill_Id", "dbo.Skills");
            DropForeignKey("dbo.ItemPrerequisites", "Race_Id", "dbo.Races");
            DropForeignKey("dbo.ItemPrerequisites", "Faction_Id", "dbo.Factions");
            DropForeignKey("dbo.ItemPrerequisites", "Archetype_Id", "dbo.Archetypes");
            DropForeignKey("dbo.ItemPrerequisites", "Id", "dbo.Entities");
            DropForeignKey("dbo.ItemPotions", "Item_Id", "dbo.Items");
            DropForeignKey("dbo.ItemPotions", "Color_Id", "dbo.Colors");
            DropForeignKey("dbo.ItemPotions", "Ability_Id", "dbo.Abilities");
            DropForeignKey("dbo.ItemPotions", "Id", "dbo.Entities");
            DropForeignKey("dbo.TerrainRestrictions", "Terrain_Id", "dbo.Terrains");
            DropForeignKey("dbo.TerrainRestrictions", "MoementMode_Id", "dbo.MovementModes");
            DropForeignKey("dbo.TerrainRestrictions", "Id", "dbo.Entities");
            DropForeignKey("dbo.SpacePortals", "TargetSpace_Id", "dbo.Spaces");
            DropForeignKey("dbo.SpacePortals", "Keywords_Id", "dbo.Strings");
            DropForeignKey("dbo.SpacePortals", "Barrier_Id", "dbo.Barriers");
            DropForeignKey("dbo.SpacePortals", "Id", "dbo.Entities");
            DropForeignKey("dbo.ItemPortals", "Item_Id", "dbo.Items");
            DropForeignKey("dbo.ItemPortals", "Destination_Id", "dbo.Spaces");
            DropForeignKey("dbo.ItemPortals", "Id", "dbo.Entities");
            DropForeignKey("dbo.ItemMudProgs", "Item_Id", "dbo.Items");
            DropForeignKey("dbo.ItemMudProgs", "MudProg_Id", "dbo.MudProgs");
            DropForeignKey("dbo.ItemMudProgs", "Event_Id", "dbo.Events");
            DropForeignKey("dbo.ItemMudProgs", "Id", "dbo.Entities");
            DropForeignKey("dbo.ItemMagicalNodes", "Item_Id", "dbo.Items");
            DropForeignKey("dbo.ItemMagicalNodes", "Effect_Id", "dbo.Effects");
            DropForeignKey("dbo.ItemMagicalNodes", "Id", "dbo.Entities");
            DropForeignKey("dbo.ItemMachines", "Item_Id", "dbo.Items");
            DropForeignKey("dbo.ItemMachines", "Id", "dbo.Entities");
            DropForeignKey("dbo.ItemLocks", "PickSkill_Id", "dbo.Skills");
            DropForeignKey("dbo.ItemLocks", "KeyItem_Id", "dbo.Items");
            DropForeignKey("dbo.ItemLocks", "Id", "dbo.Entities");
            DropForeignKey("dbo.ItemLights", "FuelItem_Id", "dbo.Items");
            DropForeignKey("dbo.ItemLights", "Id", "dbo.Entities");
            DropForeignKey("dbo.ItemSetItems", "ItemSet_Id", "dbo.ItemSets");
            DropForeignKey("dbo.ItemSetItems", "Item_Id", "dbo.Items");
            DropForeignKey("dbo.ItemSetItems", "Id", "dbo.Entities");
            DropForeignKey("dbo.ItemSetBonuses", "ItemSet_Id", "dbo.ItemSets");
            DropForeignKey("dbo.ItemSetBonuses", "Skill_Id", "dbo.Skills");
            DropForeignKey("dbo.ItemSetBonuses", "Id", "dbo.Entities");
            DropForeignKey("dbo.ItemFurnitures", "Item_Id", "dbo.Items");
            DropForeignKey("dbo.ItemFurnitures", "Id", "dbo.Entities");
            DropForeignKey("dbo.ItemFormulaResources", "ResourceItem_Id", "dbo.Items");
            DropForeignKey("dbo.ItemFormulaResources", "Id", "dbo.Entities");
            DropForeignKey("dbo.ItemFoods", "Item_Id", "dbo.Items");
            DropForeignKey("dbo.ItemFoods", "DecayDescription_Id", "dbo.Strings");
            DropForeignKey("dbo.ItemFoods", "Id", "dbo.Entities");
            DropForeignKey("dbo.ItemDrinkContainers", "Item_Id", "dbo.Items");
            DropForeignKey("dbo.ItemDrinkContainers", "Liquid_Id", "dbo.Liquids");
            DropForeignKey("dbo.ItemDrinkContainers", "Id", "dbo.Entities");
            DropForeignKey("dbo.ItemContainers", "LockItem_Id", "dbo.Items");
            DropForeignKey("dbo.ItemContainers", "Id", "dbo.Entities");
            DropForeignKey("dbo.ItemBooks", "Item_Id", "dbo.Items");
            DropForeignKey("dbo.ItemBooks", "Text_Id", "dbo.Strings");
            DropForeignKey("dbo.ItemBooks", "Ability_Id", "dbo.Abilities");
            DropForeignKey("dbo.ItemBooks", "Id", "dbo.Entities");
            DropForeignKey("dbo.MobileEquipments", "Mobile_Id", "dbo.Mobiles");
            DropForeignKey("dbo.MobileEquipments", "WornAt_Id", "dbo.WearLocations");
            DropForeignKey("dbo.MobileEquipments", "Item_Id", "dbo.Items");
            DropForeignKey("dbo.MobileEquipments", "Id", "dbo.Entities");
            DropForeignKey("dbo.FactionRelations", "TargetFaction_Id", "dbo.Factions");
            DropForeignKey("dbo.FactionRelations", "Id", "dbo.Entities");
            DropForeignKey("dbo.MobileAIs", "Mobile_Id", "dbo.Mobiles");
            DropForeignKey("dbo.MobileAIs", "Behavior_Id", "dbo.Behaviors");
            DropForeignKey("dbo.MobileAIs", "Id", "dbo.Entities");
            DropForeignKey("dbo.MobileAbilities", "Mobile_Id", "dbo.Mobiles");
            DropForeignKey("dbo.MobileAbilities", "Ability_Id", "dbo.Abilities");
            DropForeignKey("dbo.MobileAbilities", "Id", "dbo.Entities");
            DropForeignKey("dbo.ZoneDynamics", "Zone_Id", "dbo.Zones");
            DropForeignKey("dbo.ZoneDynamics", "Mobile_Id", "dbo.Mobiles");
            DropForeignKey("dbo.ZoneDynamics", "Ability_Id", "dbo.Abilities");
            DropForeignKey("dbo.ZoneDynamics", "Id", "dbo.Entities");
            DropForeignKey("dbo.ZoneAccesses", "Zone_Id", "dbo.Zones");
            DropForeignKey("dbo.ZoneAccesses", "AccessName_Id", "dbo.Strings");
            DropForeignKey("dbo.ZoneAccesses", "Id", "dbo.Entities");
            DropForeignKey("dbo.EffectDynamicZones", "Effect_Id", "dbo.Effects");
            DropForeignKey("dbo.EffectDynamicZones", "Zone_Id", "dbo.Zones");
            DropForeignKey("dbo.EffectDynamicZones", "Id", "dbo.Entities");
            DropForeignKey("dbo.AbilityEffects", "AbilityId", "dbo.Abilities");
            DropForeignKey("dbo.AbilityEffects", "Effect_Id", "dbo.Effects");
            DropForeignKey("dbo.AbilityEffects", "Id", "dbo.Entities");
            DropForeignKey("dbo.QuestRequirements", "QuestNotCompletedId", "dbo.Quests");
            DropForeignKey("dbo.QuestRequirements", "QuestCompletedId", "dbo.Quests");
            DropForeignKey("dbo.QuestRequirements", "NotRaceId", "dbo.Races");
            DropForeignKey("dbo.QuestRequirements", "RaceId", "dbo.Races");
            DropForeignKey("dbo.QuestRequirements", "Quest_Id", "dbo.Quests");
            DropForeignKey("dbo.QuestRequirements", "Skill_Id", "dbo.Skills");
            DropForeignKey("dbo.QuestRequirements", "HasItem_Id", "dbo.Items");
            DropForeignKey("dbo.QuestRequirements", "Faction_Id", "dbo.Factions");
            DropForeignKey("dbo.QuestRequirements", "Id", "dbo.Entities");
            DropForeignKey("dbo.QuestActions", "DeletePrimitiveId", "dbo.Entities");
            DropForeignKey("dbo.QuestActions", "GivePrimitiveId", "dbo.Entities");
            DropForeignKey("dbo.QuestActions", "Quest_Id", "dbo.Quests");
            DropForeignKey("dbo.QuestActions", "MudProg_Id", "dbo.MudProgs");
            DropForeignKey("dbo.QuestActions", "Mobile_Id", "dbo.Mobiles");
            DropForeignKey("dbo.QuestActions", "JournalEntry_Id", "dbo.Strings");
            DropForeignKey("dbo.QuestActions", "Id", "dbo.Entities");
            DropForeignKey("dbo.ItemFormulas", "ToolItemId", "dbo.Items");
            DropForeignKey("dbo.ItemFormulas", "MachineItemId", "dbo.Items");
            DropForeignKey("dbo.ItemFormulas", "ProductItemId", "dbo.Items");
            DropForeignKey("dbo.ItemFormulas", "Item_Id", "dbo.Items");
            DropForeignKey("dbo.ItemFormulas", "Skill_Id", "dbo.Skills");
            DropForeignKey("dbo.ItemFormulas", "Id", "dbo.Entities");
            DropForeignKey("dbo.Zones", "TagSet_Id", "dbo.TagSets");
            DropForeignKey("dbo.Zones", "DisplayDescription_Id", "dbo.Strings");
            DropForeignKey("dbo.Zones", "Id", "dbo.Entities");
            DropForeignKey("dbo.Treasures", "SystemDescription_Id", "dbo.Strings");
            DropForeignKey("dbo.Treasures", "Id", "dbo.Entities");
            DropForeignKey("dbo.Terrains", "Skill_Id", "dbo.Skills");
            DropForeignKey("dbo.Terrains", "DisplayDescription_Id", "dbo.Strings");
            DropForeignKey("dbo.Terrains", "Id", "dbo.Entities");
            DropForeignKey("dbo.TagSets", "Id", "dbo.Entities");
            DropForeignKey("dbo.Tags", "TagSet_Id", "dbo.TagSets");
            DropForeignKey("dbo.Tags", "Id", "dbo.Entities");
            DropForeignKey("dbo.Strings", "Id", "dbo.Entities");
            DropForeignKey("dbo.Spawns", "TagSet_Id", "dbo.TagSets");
            DropForeignKey("dbo.Spawns", "Id", "dbo.Entities");
            DropForeignKey("dbo.Spaces", "Terrain_Id", "dbo.Terrains");
            DropForeignKey("dbo.Spaces", "TagSet_Id", "dbo.TagSets");
            DropForeignKey("dbo.Spaces", "DisplayDescription_Id", "dbo.Strings");
            DropForeignKey("dbo.Spaces", "Id", "dbo.Entities");
            DropForeignKey("dbo.Socials", "VictFound_Id", "dbo.Strings");
            DropForeignKey("dbo.Socials", "OthersNoArg_Id", "dbo.Strings");
            DropForeignKey("dbo.Socials", "OthersFound_Id", "dbo.Strings");
            DropForeignKey("dbo.Socials", "OthersAuto_Id", "dbo.Strings");
            DropForeignKey("dbo.Socials", "CharNoArg_Id", "dbo.Strings");
            DropForeignKey("dbo.Socials", "CharFound_Id", "dbo.Strings");
            DropForeignKey("dbo.Socials", "CharAuto_Id", "dbo.Strings");
            DropForeignKey("dbo.Socials", "Id", "dbo.Entities");
            DropForeignKey("dbo.Skills", "SkillCategory_Id", "dbo.SkillCategories");
            DropForeignKey("dbo.Skills", "ParentSkill_Id", "dbo.Skills");
            DropForeignKey("dbo.Skills", "DisplayDescription_Id", "dbo.Strings");
            DropForeignKey("dbo.Skills", "Id", "dbo.Entities");
            DropForeignKey("dbo.SkillCategories", "Id", "dbo.Entities");
            DropForeignKey("dbo.Shops", "Id", "dbo.Entities");
            DropForeignKey("dbo.Rituals", "TagSet_Id", "dbo.TagSets");
            DropForeignKey("dbo.Rituals", "MagicalNodeItem_Id", "dbo.Items");
            DropForeignKey("dbo.Rituals", "DisplayDescription_Id", "dbo.Strings");
            DropForeignKey("dbo.Rituals", "Id", "dbo.Entities");
            DropForeignKey("dbo.Resets", "Space_Id", "dbo.Spaces");
            DropForeignKey("dbo.Resets", "Object_Id", "dbo.Entities");
            DropForeignKey("dbo.Resets", "Id", "dbo.Entities");
            DropForeignKey("dbo.Races", "TagSet_Id", "dbo.TagSets");
            DropForeignKey("dbo.Races", "DisplayDescription_Id", "dbo.Strings");
            DropForeignKey("dbo.Races", "Id", "dbo.Entities");
            DropForeignKey("dbo.Quests", "TagSet_Id", "dbo.TagSets");
            DropForeignKey("dbo.Quests", "DisplayDescription_Id", "dbo.Strings");
            DropForeignKey("dbo.Quests", "Id", "dbo.Entities");
            DropForeignKey("dbo.MudProgs", "Data_Id", "dbo.Strings");
            DropForeignKey("dbo.MudProgs", "Id", "dbo.Entities");
            DropForeignKey("dbo.Months", "Id", "dbo.Entities");
            DropForeignKey("dbo.Mobiles", "TagSet_Id", "dbo.TagSets");
            DropForeignKey("dbo.Mobiles", "Race_Id", "dbo.Races");
            DropForeignKey("dbo.Mobiles", "Faction_Id", "dbo.Factions");
            DropForeignKey("dbo.Mobiles", "DisplayDescription_Id", "dbo.Strings");
            DropForeignKey("dbo.Mobiles", "Conversation_Id", "dbo.Conversations");
            DropForeignKey("dbo.Mobiles", "Id", "dbo.Entities");
            DropForeignKey("dbo.Liquids", "TagSet_Id", "dbo.TagSets");
            DropForeignKey("dbo.Liquids", "DisplayDescription_Id", "dbo.Strings");
            DropForeignKey("dbo.Liquids", "Color_Id", "dbo.Colors");
            DropForeignKey("dbo.Liquids", "Id", "dbo.Entities");
            DropForeignKey("dbo.ItemSets", "DisplayDescription_Id", "dbo.Strings");
            DropForeignKey("dbo.ItemSets", "Id", "dbo.Entities");
            DropForeignKey("dbo.Items", "UseAbility_Id", "dbo.Abilities");
            DropForeignKey("dbo.Items", "TrapItem_Id", "dbo.Items");
            DropForeignKey("dbo.Items", "TagSet_Id", "dbo.TagSets");
            DropForeignKey("dbo.Items", "ItemSet_Id", "dbo.ItemSets");
            DropForeignKey("dbo.Items", "DisplayDescription_Id", "dbo.Strings");
            DropForeignKey("dbo.Items", "Id", "dbo.Entities");
            DropForeignKey("dbo.Helps", "Text_Id", "dbo.Strings");
            DropForeignKey("dbo.Helps", "Keywords_Id", "dbo.Strings");
            DropForeignKey("dbo.Helps", "Id", "dbo.Entities");
            DropForeignKey("ref.GameConstants", "Id", "dbo.Entities");
            DropForeignKey("dbo.GameCommands", "TagSet_Id", "dbo.TagSets");
            DropForeignKey("dbo.GameCommands", "Keywords_Id", "dbo.Strings");
            DropForeignKey("dbo.GameCommands", "Id", "dbo.Entities");
            DropForeignKey("dbo.Factions", "TagSet_Id", "dbo.TagSets");
            DropForeignKey("dbo.Factions", "Id", "dbo.Entities");
            DropForeignKey("dbo.Effects", "OnResistEffectId", "dbo.Effects");
            DropForeignKey("dbo.Effects", "OnFailEffectId", "dbo.Effects");
            DropForeignKey("dbo.Effects", "TagSet_Id", "dbo.TagSets");
            DropForeignKey("dbo.Effects", "FadeTextSelf_Id", "dbo.Strings");
            DropForeignKey("dbo.Effects", "FadeTextOther_Id", "dbo.Strings");
            DropForeignKey("dbo.Effects", "DisplayDescription_Id", "dbo.Strings");
            DropForeignKey("dbo.Effects", "ApplicationTextSelf_Id", "dbo.Strings");
            DropForeignKey("dbo.Effects", "ApplicationTextOther_Id", "dbo.Strings");
            DropForeignKey("dbo.Effects", "Id", "dbo.Entities");
            DropForeignKey("dbo.Conversations", "Text_Id", "dbo.Strings");
            DropForeignKey("dbo.Conversations", "TagSet_Id", "dbo.TagSets");
            DropForeignKey("dbo.Conversations", "RequiredFaction_Id", "dbo.Factions");
            DropForeignKey("dbo.Conversations", "Keywords_Id", "dbo.Strings");
            DropForeignKey("dbo.Conversations", "Id", "dbo.Entities");
            DropForeignKey("dbo.Behaviors", "TagSet_Id", "dbo.TagSets");
            DropForeignKey("dbo.Behaviors", "Id", "dbo.Entities");
            DropForeignKey("dbo.Barriers", "TrapItemId", "dbo.Items");
            DropForeignKey("dbo.Barriers", "LockItemId", "dbo.Items");
            DropForeignKey("dbo.Barriers", "KeyItemId", "dbo.Items");
            DropForeignKey("dbo.Barriers", "TagSet_Id", "dbo.TagSets");
            DropForeignKey("dbo.Barriers", "Id", "dbo.Entities");
            DropForeignKey("ref.BankUpgrades", "Id", "dbo.Entities");
            DropForeignKey("dbo.Archetypes", "TagSet_Id", "dbo.TagSets");
            DropForeignKey("dbo.Archetypes", "DisplayDescription_Id", "dbo.Strings");
            DropForeignKey("dbo.Archetypes", "Id", "dbo.Entities");
            DropForeignKey("dbo.Abilities", "VerbalText_Id", "dbo.Strings");
            DropForeignKey("dbo.Abilities", "UseText_Id", "dbo.Strings");
            DropForeignKey("dbo.Abilities", "Terrain_Id", "dbo.Terrains");
            DropForeignKey("dbo.Abilities", "TagSet_Id", "dbo.TagSets");
            DropForeignKey("dbo.Abilities", "Reagants_Id", "dbo.AbilityReagants");
            DropForeignKey("dbo.Abilities", "Prerequisites_Id", "dbo.AbilityPrerequisites");
            DropForeignKey("dbo.Abilities", "InterruptionResistSkill_Id", "dbo.Skills");
            DropForeignKey("dbo.Abilities", "InterruptionEffect_Id", "dbo.Effects");
            DropForeignKey("dbo.Abilities", "GuildUpgrades_Id", "dbo.GuildAbilities");
            DropForeignKey("dbo.Abilities", "Effects_Id", "dbo.AbilityEffects");
            DropForeignKey("dbo.Abilities", "DisplayDescription_Id", "dbo.Strings");
            DropForeignKey("dbo.Abilities", "BeginUseText_Id", "dbo.Strings");
            DropForeignKey("dbo.Abilities", "Id", "dbo.Entities");
            DropForeignKey("dbo.Entities", "SystemClass_Id", "dbo.SystemClasses");
            DropForeignKey("dbo.Entities", "DisplayName_Id", "dbo.Strings");
            DropForeignKey("dbo.SystemClasses", "ParentClassId", "dbo.SystemClasses");
            DropIndex("dbo.ZoneSpawns", new[] { "Zone_Id" });
            DropIndex("dbo.ZoneSpawns", new[] { "Spawn_Id" });
            DropIndex("dbo.ZoneSpawns", new[] { "Id" });
            DropIndex("dbo.ZoneSpaces", new[] { "Zone_Id" });
            DropIndex("dbo.ZoneSpaces", new[] { "Space_Id" });
            DropIndex("dbo.ZoneSpaces", new[] { "Id" });
            DropIndex("dbo.ZoneResets", new[] { "Zone_Id" });
            DropIndex("dbo.ZoneResets", new[] { "Reset_Id" });
            DropIndex("dbo.ZoneResets", new[] { "Id" });
            DropIndex("dbo.SpawnPrimitives", new[] { "Spawn_Id" });
            DropIndex("dbo.SpawnPrimitives", new[] { "Primitive_Id" });
            DropIndex("dbo.SpawnPrimitives", new[] { "Id" });
            DropIndex("dbo.SpawnLocations", new[] { "Spawn_Id" });
            DropIndex("dbo.SpawnLocations", new[] { "Space_Id" });
            DropIndex("dbo.SpawnLocations", new[] { "Id" });
            DropIndex("dbo.RitualRequirements", new[] { "Ritual_Id" });
            DropIndex("dbo.RitualRequirements", new[] { "Race_Id" });
            DropIndex("dbo.RitualRequirements", new[] { "Faction_Id" });
            DropIndex("dbo.RitualRequirements", new[] { "Id" });
            DropIndex("dbo.RitualReagants", new[] { "Ritual_Id" });
            DropIndex("dbo.RitualReagants", new[] { "ReagantItem_Id" });
            DropIndex("dbo.RitualReagants", new[] { "Id" });
            DropIndex("dbo.RitualParticipants", new[] { "Ritual_Id" });
            DropIndex("dbo.RitualParticipants", new[] { "WearLocation_Id" });
            DropIndex("dbo.RitualParticipants", new[] { "FocusItem_Id" });
            DropIndex("dbo.RitualParticipants", new[] { "Id" });
            DropIndex("dbo.RitualEffects", new[] { "Ritual_Id" });
            DropIndex("dbo.RitualEffects", new[] { "Effect_Id" });
            DropIndex("dbo.RitualEffects", new[] { "Id" });
            DropIndex("dbo.ShopPrimitives", new[] { "Shop_Id" });
            DropIndex("dbo.ShopPrimitives", new[] { "Primitive_Id" });
            DropIndex("dbo.ShopPrimitives", new[] { "Id" });
            DropIndex("dbo.ShopBuyTypes", new[] { "Shop_Id" });
            DropIndex("dbo.ShopBuyTypes", new[] { "Id" });
            DropIndex("dbo.MobileVendor", new[] { "Mobile_Id" });
            DropIndex("dbo.MobileVendor", new[] { "Shop_Id" });
            DropIndex("dbo.MobileVendor", new[] { "Id" });
            DropIndex("dbo.MobileTreasureTables", new[] { "Mobile_Id" });
            DropIndex("dbo.MobileTreasureTables", new[] { "Treasure_Id" });
            DropIndex("dbo.MobileTreasureTables", new[] { "Id" });
            DropIndex("dbo.MobileTreasures", new[] { "Mobile_Id" });
            DropIndex("dbo.MobileTreasures", new[] { "Id" });
            DropIndex("dbo.MobileStatistics", new[] { "Mobile_Id" });
            DropIndex("dbo.MobileStatistics", new[] { "Skill_Id" });
            DropIndex("dbo.MobileStatistics", new[] { "Id" });
            DropIndex("dbo.MobileResources", new[] { "Mobile_Id" });
            DropIndex("dbo.MobileResources", new[] { "NodeItem_Id" });
            DropIndex("dbo.MobileResources", new[] { "Id" });
            DropIndex("dbo.MobileMudProgs", new[] { "Mobile_Id" });
            DropIndex("dbo.MobileMudProgs", new[] { "MudProg_Id" });
            DropIndex("dbo.MobileMudProgs", new[] { "Event_Id" });
            DropIndex("dbo.MobileMudProgs", new[] { "Id" });
            DropIndex("dbo.ItemWearLocations", new[] { "Item_Id" });
            DropIndex("dbo.ItemWearLocations", new[] { "WornAt_Id" });
            DropIndex("dbo.ItemWearLocations", new[] { "Id" });
            DropIndex("dbo.ItemWeapons", new[] { "Item_Id" });
            DropIndex("dbo.ItemWeapons", new[] { "Skill_Id" });
            DropIndex("dbo.ItemWeapons", new[] { "Id" });
            DropIndex("dbo.ItemVehicleTerrains", new[] { "Item_Id" });
            DropIndex("dbo.ItemVehicleTerrains", new[] { "Terrain_Id" });
            DropIndex("dbo.ItemVehicleTerrains", new[] { "Id" });
            DropIndex("dbo.ItemVehicles", new[] { "Item_Id" });
            DropIndex("dbo.ItemVehicles", new[] { "Id" });
            DropIndex("dbo.GuildAbilities", new[] { "Ability_Id" });
            DropIndex("dbo.GuildAbilities", new[] { "Id" });
            DropIndex("dbo.EffectStatMods", new[] { "Effect_Id" });
            DropIndex("dbo.EffectStatMods", new[] { "Element_Id" });
            DropIndex("dbo.EffectStatMods", new[] { "AffectedSkill_Id" });
            DropIndex("dbo.EffectStatMods", new[] { "Id" });
            DropIndex("dbo.EffectPrimitives", new[] { "Effect_Id" });
            DropIndex("dbo.EffectPrimitives", new[] { "Primitive_Id" });
            DropIndex("dbo.EffectPrimitives", new[] { "Id" });
            DropIndex("dbo.EffectPositions", new[] { "Effect_Id" });
            DropIndex("dbo.EffectPositions", new[] { "Id" });
            DropIndex("dbo.EffectHealthChanges", new[] { "Effect_Id" });
            DropIndex("dbo.EffectHealthChanges", new[] { "Id" });
            DropIndex("dbo.AbilityReagants", new[] { "AbilityId" });
            DropIndex("dbo.AbilityReagants", new[] { "Item_Id" });
            DropIndex("dbo.AbilityReagants", new[] { "Id" });
            DropIndex("dbo.AbilityPrerequisites", new[] { "AbilityId" });
            DropIndex("dbo.AbilityPrerequisites", new[] { "Skill_Id" });
            DropIndex("dbo.AbilityPrerequisites", new[] { "Race_Id" });
            DropIndex("dbo.AbilityPrerequisites", new[] { "Faction_Id" });
            DropIndex("dbo.AbilityPrerequisites", new[] { "Id" });
            DropIndex("dbo.QuestProgresses", new[] { "Quest_Id" });
            DropIndex("dbo.QuestProgresses", new[] { "ProgressName_Id" });
            DropIndex("dbo.QuestProgresses", new[] { "Primitive_Id" });
            DropIndex("dbo.QuestProgresses", new[] { "Id" });
            DropIndex("dbo.MonthEffects", new[] { "Month_Id" });
            DropIndex("dbo.MonthEffects", new[] { "Effect_Id" });
            DropIndex("dbo.MonthEffects", new[] { "Id" });
            DropIndex("dbo.GameCommandUserStates", new[] { "GameCommand_Id" });
            DropIndex("dbo.GameCommandUserStates", new[] { "Id" });
            DropIndex("dbo.GameCommandPositions", new[] { "GameCommand_Id" });
            DropIndex("dbo.GameCommandPositions", new[] { "Id" });
            DropIndex("dbo.TreasurePrimitives", new[] { "Treasure_Id" });
            DropIndex("dbo.TreasurePrimitives", new[] { "Primitive_Id" });
            DropIndex("dbo.TreasurePrimitives", new[] { "Id" });
            DropIndex("dbo.ItemTreasures", new[] { "Item_Id" });
            DropIndex("dbo.ItemTreasures", new[] { "Treasure_Id" });
            DropIndex("dbo.ItemTreasures", new[] { "Id" });
            DropIndex("dbo.ItemTraps", new[] { "Item_Id" });
            DropIndex("dbo.ItemTraps", new[] { "OnFailEffect_Id" });
            DropIndex("dbo.ItemTraps", new[] { "DisarmSkill_Id" });
            DropIndex("dbo.ItemTraps", new[] { "Id" });
            DropIndex("dbo.ItemTools", new[] { "Item_Id" });
            DropIndex("dbo.ItemTools", new[] { "Id" });
            DropIndex("dbo.ItemStatistics", new[] { "Item_Id" });
            DropIndex("dbo.ItemStatistics", new[] { "Skill_Id" });
            DropIndex("dbo.ItemStatistics", new[] { "Id" });
            DropIndex("dbo.ItemResourceNodes", new[] { "Skill_Id" });
            DropIndex("dbo.ItemResourceNodes", new[] { "ResourceItem_Id" });
            DropIndex("dbo.ItemResourceNodes", new[] { "Id" });
            DropIndex("dbo.RaceStatistics", new[] { "Race_Id" });
            DropIndex("dbo.RaceStatistics", new[] { "Skill_Id" });
            DropIndex("dbo.RaceStatistics", new[] { "Id" });
            DropIndex("dbo.RaceHitLocations", new[] { "Race_Id" });
            DropIndex("dbo.RaceHitLocations", new[] { "HitLocation_Id" });
            DropIndex("dbo.RaceHitLocations", new[] { "Id" });
            DropIndex("dbo.RaceAbilities", new[] { "Race_Id" });
            DropIndex("dbo.RaceAbilities", new[] { "Ability_Id" });
            DropIndex("dbo.RaceAbilities", new[] { "Id" });
            DropIndex("dbo.ArchetypeStatistics", new[] { "Archetype_Id" });
            DropIndex("dbo.ArchetypeStatistics", new[] { "Skill_Id" });
            DropIndex("dbo.ArchetypeStatistics", new[] { "Id" });
            DropIndex("dbo.ArchetypeSkillCategories", new[] { "Archetype_Id" });
            DropIndex("dbo.ArchetypeSkillCategories", new[] { "SkillCategory_Id" });
            DropIndex("dbo.ArchetypeSkillCategories", new[] { "Id" });
            DropIndex("dbo.ArchetypeAbilities", new[] { "Archetype_Id" });
            DropIndex("dbo.ArchetypeAbilities", new[] { "Ability_Id" });
            DropIndex("dbo.ArchetypeAbilities", new[] { "Id" });
            DropIndex("dbo.ItemPrerequisites", new[] { "Item_Id" });
            DropIndex("dbo.ItemPrerequisites", new[] { "Skill_Id" });
            DropIndex("dbo.ItemPrerequisites", new[] { "Race_Id" });
            DropIndex("dbo.ItemPrerequisites", new[] { "Faction_Id" });
            DropIndex("dbo.ItemPrerequisites", new[] { "Archetype_Id" });
            DropIndex("dbo.ItemPrerequisites", new[] { "Id" });
            DropIndex("dbo.ItemPotions", new[] { "Item_Id" });
            DropIndex("dbo.ItemPotions", new[] { "Color_Id" });
            DropIndex("dbo.ItemPotions", new[] { "Ability_Id" });
            DropIndex("dbo.ItemPotions", new[] { "Id" });
            DropIndex("dbo.TerrainRestrictions", new[] { "Terrain_Id" });
            DropIndex("dbo.TerrainRestrictions", new[] { "MoementMode_Id" });
            DropIndex("dbo.TerrainRestrictions", new[] { "Id" });
            DropIndex("dbo.SpacePortals", new[] { "TargetSpace_Id" });
            DropIndex("dbo.SpacePortals", new[] { "Keywords_Id" });
            DropIndex("dbo.SpacePortals", new[] { "Barrier_Id" });
            DropIndex("dbo.SpacePortals", new[] { "Id" });
            DropIndex("dbo.ItemPortals", new[] { "Item_Id" });
            DropIndex("dbo.ItemPortals", new[] { "Destination_Id" });
            DropIndex("dbo.ItemPortals", new[] { "Id" });
            DropIndex("dbo.ItemMudProgs", new[] { "Item_Id" });
            DropIndex("dbo.ItemMudProgs", new[] { "MudProg_Id" });
            DropIndex("dbo.ItemMudProgs", new[] { "Event_Id" });
            DropIndex("dbo.ItemMudProgs", new[] { "Id" });
            DropIndex("dbo.ItemMagicalNodes", new[] { "Item_Id" });
            DropIndex("dbo.ItemMagicalNodes", new[] { "Effect_Id" });
            DropIndex("dbo.ItemMagicalNodes", new[] { "Id" });
            DropIndex("dbo.ItemMachines", new[] { "Item_Id" });
            DropIndex("dbo.ItemMachines", new[] { "Id" });
            DropIndex("dbo.ItemLocks", new[] { "PickSkill_Id" });
            DropIndex("dbo.ItemLocks", new[] { "KeyItem_Id" });
            DropIndex("dbo.ItemLocks", new[] { "Id" });
            DropIndex("dbo.ItemLights", new[] { "FuelItem_Id" });
            DropIndex("dbo.ItemLights", new[] { "Id" });
            DropIndex("dbo.ItemSetItems", new[] { "ItemSet_Id" });
            DropIndex("dbo.ItemSetItems", new[] { "Item_Id" });
            DropIndex("dbo.ItemSetItems", new[] { "Id" });
            DropIndex("dbo.ItemSetBonuses", new[] { "ItemSet_Id" });
            DropIndex("dbo.ItemSetBonuses", new[] { "Skill_Id" });
            DropIndex("dbo.ItemSetBonuses", new[] { "Id" });
            DropIndex("dbo.ItemFurnitures", new[] { "Item_Id" });
            DropIndex("dbo.ItemFurnitures", new[] { "Id" });
            DropIndex("dbo.ItemFormulaResources", new[] { "ResourceItem_Id" });
            DropIndex("dbo.ItemFormulaResources", new[] { "Id" });
            DropIndex("dbo.ItemFoods", new[] { "Item_Id" });
            DropIndex("dbo.ItemFoods", new[] { "DecayDescription_Id" });
            DropIndex("dbo.ItemFoods", new[] { "Id" });
            DropIndex("dbo.ItemDrinkContainers", new[] { "Item_Id" });
            DropIndex("dbo.ItemDrinkContainers", new[] { "Liquid_Id" });
            DropIndex("dbo.ItemDrinkContainers", new[] { "Id" });
            DropIndex("dbo.ItemContainers", new[] { "LockItem_Id" });
            DropIndex("dbo.ItemContainers", new[] { "Id" });
            DropIndex("dbo.ItemBooks", new[] { "Item_Id" });
            DropIndex("dbo.ItemBooks", new[] { "Text_Id" });
            DropIndex("dbo.ItemBooks", new[] { "Ability_Id" });
            DropIndex("dbo.ItemBooks", new[] { "Id" });
            DropIndex("dbo.MobileEquipments", new[] { "Mobile_Id" });
            DropIndex("dbo.MobileEquipments", new[] { "WornAt_Id" });
            DropIndex("dbo.MobileEquipments", new[] { "Item_Id" });
            DropIndex("dbo.MobileEquipments", new[] { "Id" });
            DropIndex("dbo.FactionRelations", new[] { "TargetFaction_Id" });
            DropIndex("dbo.FactionRelations", new[] { "Id" });
            DropIndex("dbo.MobileAIs", new[] { "Mobile_Id" });
            DropIndex("dbo.MobileAIs", new[] { "Behavior_Id" });
            DropIndex("dbo.MobileAIs", new[] { "Id" });
            DropIndex("dbo.MobileAbilities", new[] { "Mobile_Id" });
            DropIndex("dbo.MobileAbilities", new[] { "Ability_Id" });
            DropIndex("dbo.MobileAbilities", new[] { "Id" });
            DropIndex("dbo.ZoneDynamics", new[] { "Zone_Id" });
            DropIndex("dbo.ZoneDynamics", new[] { "Mobile_Id" });
            DropIndex("dbo.ZoneDynamics", new[] { "Ability_Id" });
            DropIndex("dbo.ZoneDynamics", new[] { "Id" });
            DropIndex("dbo.ZoneAccesses", new[] { "Zone_Id" });
            DropIndex("dbo.ZoneAccesses", new[] { "AccessName_Id" });
            DropIndex("dbo.ZoneAccesses", new[] { "Id" });
            DropIndex("dbo.EffectDynamicZones", new[] { "Effect_Id" });
            DropIndex("dbo.EffectDynamicZones", new[] { "Zone_Id" });
            DropIndex("dbo.EffectDynamicZones", new[] { "Id" });
            DropIndex("dbo.AbilityEffects", new[] { "AbilityId" });
            DropIndex("dbo.AbilityEffects", new[] { "Effect_Id" });
            DropIndex("dbo.AbilityEffects", new[] { "Id" });
            DropIndex("dbo.QuestRequirements", new[] { "QuestNotCompletedId" });
            DropIndex("dbo.QuestRequirements", new[] { "QuestCompletedId" });
            DropIndex("dbo.QuestRequirements", new[] { "NotRaceId" });
            DropIndex("dbo.QuestRequirements", new[] { "RaceId" });
            DropIndex("dbo.QuestRequirements", new[] { "Quest_Id" });
            DropIndex("dbo.QuestRequirements", new[] { "Skill_Id" });
            DropIndex("dbo.QuestRequirements", new[] { "HasItem_Id" });
            DropIndex("dbo.QuestRequirements", new[] { "Faction_Id" });
            DropIndex("dbo.QuestRequirements", new[] { "Id" });
            DropIndex("dbo.QuestActions", new[] { "DeletePrimitiveId" });
            DropIndex("dbo.QuestActions", new[] { "GivePrimitiveId" });
            DropIndex("dbo.QuestActions", new[] { "Quest_Id" });
            DropIndex("dbo.QuestActions", new[] { "MudProg_Id" });
            DropIndex("dbo.QuestActions", new[] { "Mobile_Id" });
            DropIndex("dbo.QuestActions", new[] { "JournalEntry_Id" });
            DropIndex("dbo.QuestActions", new[] { "Id" });
            DropIndex("dbo.ItemFormulas", new[] { "ToolItemId" });
            DropIndex("dbo.ItemFormulas", new[] { "MachineItemId" });
            DropIndex("dbo.ItemFormulas", new[] { "ProductItemId" });
            DropIndex("dbo.ItemFormulas", new[] { "Item_Id" });
            DropIndex("dbo.ItemFormulas", new[] { "Skill_Id" });
            DropIndex("dbo.ItemFormulas", new[] { "Id" });
            DropIndex("dbo.Zones", new[] { "TagSet_Id" });
            DropIndex("dbo.Zones", new[] { "DisplayDescription_Id" });
            DropIndex("dbo.Zones", new[] { "Id" });
            DropIndex("dbo.Treasures", new[] { "SystemDescription_Id" });
            DropIndex("dbo.Treasures", new[] { "Id" });
            DropIndex("dbo.Terrains", new[] { "Skill_Id" });
            DropIndex("dbo.Terrains", new[] { "DisplayDescription_Id" });
            DropIndex("dbo.Terrains", new[] { "Id" });
            DropIndex("dbo.TagSets", new[] { "Id" });
            DropIndex("dbo.Tags", new[] { "TagSet_Id" });
            DropIndex("dbo.Tags", new[] { "Id" });
            DropIndex("dbo.Strings", new[] { "Id" });
            DropIndex("dbo.Spawns", new[] { "TagSet_Id" });
            DropIndex("dbo.Spawns", new[] { "Id" });
            DropIndex("dbo.Spaces", new[] { "Terrain_Id" });
            DropIndex("dbo.Spaces", new[] { "TagSet_Id" });
            DropIndex("dbo.Spaces", new[] { "DisplayDescription_Id" });
            DropIndex("dbo.Spaces", new[] { "Id" });
            DropIndex("dbo.Socials", new[] { "VictFound_Id" });
            DropIndex("dbo.Socials", new[] { "OthersNoArg_Id" });
            DropIndex("dbo.Socials", new[] { "OthersFound_Id" });
            DropIndex("dbo.Socials", new[] { "OthersAuto_Id" });
            DropIndex("dbo.Socials", new[] { "CharNoArg_Id" });
            DropIndex("dbo.Socials", new[] { "CharFound_Id" });
            DropIndex("dbo.Socials", new[] { "CharAuto_Id" });
            DropIndex("dbo.Socials", new[] { "Id" });
            DropIndex("dbo.Skills", new[] { "SkillCategory_Id" });
            DropIndex("dbo.Skills", new[] { "ParentSkill_Id" });
            DropIndex("dbo.Skills", new[] { "DisplayDescription_Id" });
            DropIndex("dbo.Skills", new[] { "Id" });
            DropIndex("dbo.SkillCategories", new[] { "Id" });
            DropIndex("dbo.Shops", new[] { "Id" });
            DropIndex("dbo.Rituals", new[] { "TagSet_Id" });
            DropIndex("dbo.Rituals", new[] { "MagicalNodeItem_Id" });
            DropIndex("dbo.Rituals", new[] { "DisplayDescription_Id" });
            DropIndex("dbo.Rituals", new[] { "Id" });
            DropIndex("dbo.Resets", new[] { "Space_Id" });
            DropIndex("dbo.Resets", new[] { "Object_Id" });
            DropIndex("dbo.Resets", new[] { "Id" });
            DropIndex("dbo.Races", new[] { "TagSet_Id" });
            DropIndex("dbo.Races", new[] { "DisplayDescription_Id" });
            DropIndex("dbo.Races", new[] { "Id" });
            DropIndex("dbo.Quests", new[] { "TagSet_Id" });
            DropIndex("dbo.Quests", new[] { "DisplayDescription_Id" });
            DropIndex("dbo.Quests", new[] { "Id" });
            DropIndex("dbo.MudProgs", new[] { "Data_Id" });
            DropIndex("dbo.MudProgs", new[] { "Id" });
            DropIndex("dbo.Months", new[] { "Id" });
            DropIndex("dbo.Mobiles", new[] { "TagSet_Id" });
            DropIndex("dbo.Mobiles", new[] { "Race_Id" });
            DropIndex("dbo.Mobiles", new[] { "Faction_Id" });
            DropIndex("dbo.Mobiles", new[] { "DisplayDescription_Id" });
            DropIndex("dbo.Mobiles", new[] { "Conversation_Id" });
            DropIndex("dbo.Mobiles", new[] { "Id" });
            DropIndex("dbo.Liquids", new[] { "TagSet_Id" });
            DropIndex("dbo.Liquids", new[] { "DisplayDescription_Id" });
            DropIndex("dbo.Liquids", new[] { "Color_Id" });
            DropIndex("dbo.Liquids", new[] { "Id" });
            DropIndex("dbo.ItemSets", new[] { "DisplayDescription_Id" });
            DropIndex("dbo.ItemSets", new[] { "Id" });
            DropIndex("dbo.Items", new[] { "UseAbility_Id" });
            DropIndex("dbo.Items", new[] { "TrapItem_Id" });
            DropIndex("dbo.Items", new[] { "TagSet_Id" });
            DropIndex("dbo.Items", new[] { "ItemSet_Id" });
            DropIndex("dbo.Items", new[] { "DisplayDescription_Id" });
            DropIndex("dbo.Items", new[] { "Id" });
            DropIndex("dbo.Helps", new[] { "Text_Id" });
            DropIndex("dbo.Helps", new[] { "Keywords_Id" });
            DropIndex("dbo.Helps", new[] { "Id" });
            DropIndex("ref.GameConstants", new[] { "Id" });
            DropIndex("dbo.GameCommands", new[] { "TagSet_Id" });
            DropIndex("dbo.GameCommands", new[] { "Keywords_Id" });
            DropIndex("dbo.GameCommands", new[] { "Id" });
            DropIndex("dbo.Factions", new[] { "TagSet_Id" });
            DropIndex("dbo.Factions", new[] { "Id" });
            DropIndex("dbo.Effects", new[] { "OnResistEffectId" });
            DropIndex("dbo.Effects", new[] { "OnFailEffectId" });
            DropIndex("dbo.Effects", new[] { "TagSet_Id" });
            DropIndex("dbo.Effects", new[] { "FadeTextSelf_Id" });
            DropIndex("dbo.Effects", new[] { "FadeTextOther_Id" });
            DropIndex("dbo.Effects", new[] { "DisplayDescription_Id" });
            DropIndex("dbo.Effects", new[] { "ApplicationTextSelf_Id" });
            DropIndex("dbo.Effects", new[] { "ApplicationTextOther_Id" });
            DropIndex("dbo.Effects", new[] { "Id" });
            DropIndex("dbo.Conversations", new[] { "Text_Id" });
            DropIndex("dbo.Conversations", new[] { "TagSet_Id" });
            DropIndex("dbo.Conversations", new[] { "RequiredFaction_Id" });
            DropIndex("dbo.Conversations", new[] { "Keywords_Id" });
            DropIndex("dbo.Conversations", new[] { "Id" });
            DropIndex("dbo.Behaviors", new[] { "TagSet_Id" });
            DropIndex("dbo.Behaviors", new[] { "Id" });
            DropIndex("dbo.Barriers", new[] { "TrapItemId" });
            DropIndex("dbo.Barriers", new[] { "LockItemId" });
            DropIndex("dbo.Barriers", new[] { "KeyItemId" });
            DropIndex("dbo.Barriers", new[] { "TagSet_Id" });
            DropIndex("dbo.Barriers", new[] { "Id" });
            DropIndex("ref.BankUpgrades", new[] { "Id" });
            DropIndex("dbo.Archetypes", new[] { "TagSet_Id" });
            DropIndex("dbo.Archetypes", new[] { "DisplayDescription_Id" });
            DropIndex("dbo.Archetypes", new[] { "Id" });
            DropIndex("dbo.Abilities", new[] { "VerbalText_Id" });
            DropIndex("dbo.Abilities", new[] { "UseText_Id" });
            DropIndex("dbo.Abilities", new[] { "Terrain_Id" });
            DropIndex("dbo.Abilities", new[] { "TagSet_Id" });
            DropIndex("dbo.Abilities", new[] { "Reagants_Id" });
            DropIndex("dbo.Abilities", new[] { "Prerequisites_Id" });
            DropIndex("dbo.Abilities", new[] { "InterruptionResistSkill_Id" });
            DropIndex("dbo.Abilities", new[] { "InterruptionEffect_Id" });
            DropIndex("dbo.Abilities", new[] { "GuildUpgrades_Id" });
            DropIndex("dbo.Abilities", new[] { "Effects_Id" });
            DropIndex("dbo.Abilities", new[] { "DisplayDescription_Id" });
            DropIndex("dbo.Abilities", new[] { "BeginUseText_Id" });
            DropIndex("dbo.Abilities", new[] { "Id" });
            DropIndex("dbo.SystemClasses", new[] { "ParentClassId" });
            DropIndex("dbo.Entities", new[] { "SystemClass_Id" });
            DropIndex("dbo.Entities", new[] { "DisplayName_Id" });
            DropTable("dbo.ZoneSpawns");
            DropTable("dbo.ZoneSpaces");
            DropTable("dbo.ZoneResets");
            DropTable("dbo.SpawnPrimitives");
            DropTable("dbo.SpawnLocations");
            DropTable("dbo.RitualRequirements");
            DropTable("dbo.RitualReagants");
            DropTable("dbo.RitualParticipants");
            DropTable("dbo.RitualEffects");
            DropTable("dbo.ShopPrimitives");
            DropTable("dbo.ShopBuyTypes");
            DropTable("dbo.MobileVendor");
            DropTable("dbo.MobileTreasureTables");
            DropTable("dbo.MobileTreasures");
            DropTable("dbo.MobileStatistics");
            DropTable("dbo.MobileResources");
            DropTable("dbo.MobileMudProgs");
            DropTable("dbo.ItemWearLocations");
            DropTable("dbo.ItemWeapons");
            DropTable("dbo.ItemVehicleTerrains");
            DropTable("dbo.ItemVehicles");
            DropTable("dbo.GuildAbilities");
            DropTable("dbo.EffectStatMods");
            DropTable("dbo.EffectPrimitives");
            DropTable("dbo.EffectPositions");
            DropTable("dbo.EffectHealthChanges");
            DropTable("dbo.AbilityReagants");
            DropTable("dbo.AbilityPrerequisites");
            DropTable("dbo.QuestProgresses");
            DropTable("dbo.MonthEffects");
            DropTable("dbo.GameCommandUserStates");
            DropTable("dbo.GameCommandPositions");
            DropTable("dbo.TreasurePrimitives");
            DropTable("dbo.ItemTreasures");
            DropTable("dbo.ItemTraps");
            DropTable("dbo.ItemTools");
            DropTable("dbo.ItemStatistics");
            DropTable("dbo.ItemResourceNodes");
            DropTable("dbo.RaceStatistics");
            DropTable("dbo.RaceHitLocations");
            DropTable("dbo.RaceAbilities");
            DropTable("dbo.ArchetypeStatistics");
            DropTable("dbo.ArchetypeSkillCategories");
            DropTable("dbo.ArchetypeAbilities");
            DropTable("dbo.ItemPrerequisites");
            DropTable("dbo.ItemPotions");
            DropTable("dbo.TerrainRestrictions");
            DropTable("dbo.SpacePortals");
            DropTable("dbo.ItemPortals");
            DropTable("dbo.ItemMudProgs");
            DropTable("dbo.ItemMagicalNodes");
            DropTable("dbo.ItemMachines");
            DropTable("dbo.ItemLocks");
            DropTable("dbo.ItemLights");
            DropTable("dbo.ItemSetItems");
            DropTable("dbo.ItemSetBonuses");
            DropTable("dbo.ItemFurnitures");
            DropTable("dbo.ItemFormulaResources");
            DropTable("dbo.ItemFoods");
            DropTable("dbo.ItemDrinkContainers");
            DropTable("dbo.ItemContainers");
            DropTable("dbo.ItemBooks");
            DropTable("dbo.MobileEquipments");
            DropTable("dbo.FactionRelations");
            DropTable("dbo.MobileAIs");
            DropTable("dbo.MobileAbilities");
            DropTable("dbo.ZoneDynamics");
            DropTable("dbo.ZoneAccesses");
            DropTable("dbo.EffectDynamicZones");
            DropTable("dbo.AbilityEffects");
            DropTable("dbo.QuestRequirements");
            DropTable("dbo.QuestActions");
            DropTable("dbo.ItemFormulas");
            DropTable("dbo.Zones");
            DropTable("dbo.Treasures");
            DropTable("dbo.Terrains");
            DropTable("dbo.TagSets");
            DropTable("dbo.Tags");
            DropTable("dbo.Strings");
            DropTable("dbo.Spawns");
            DropTable("dbo.Spaces");
            DropTable("dbo.Socials");
            DropTable("dbo.Skills");
            DropTable("dbo.SkillCategories");
            DropTable("dbo.Shops");
            DropTable("dbo.Rituals");
            DropTable("dbo.Resets");
            DropTable("dbo.Races");
            DropTable("dbo.Quests");
            DropTable("dbo.MudProgs");
            DropTable("dbo.Months");
            DropTable("dbo.Mobiles");
            DropTable("dbo.Liquids");
            DropTable("dbo.ItemSets");
            DropTable("dbo.Items");
            DropTable("dbo.Helps");
            DropTable("ref.GameConstants");
            DropTable("dbo.GameCommands");
            DropTable("dbo.Factions");
            DropTable("dbo.Effects");
            DropTable("dbo.Conversations");
            DropTable("dbo.Behaviors");
            DropTable("dbo.Barriers");
            DropTable("ref.BankUpgrades");
            DropTable("dbo.Archetypes");
            DropTable("dbo.Abilities");
            DropTable("dbo.GuildLevels");
            DropTable("dbo.Bits");
            DropTable("dbo.Elements");
            DropTable("dbo.WearLocations");
            DropTable("dbo.MovementModes");
            DropTable("dbo.Events");
            DropTable("dbo.Colors");
            DropTable("dbo.SystemClasses");
            DropTable("dbo.Entities");
        }
    }
}
