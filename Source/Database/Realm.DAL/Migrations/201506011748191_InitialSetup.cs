namespace Realm.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialSetup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Primitives",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SystemName = c.String(nullable: false, maxLength: 255),
                        SystemClassId = c.Int(nullable: false),
                        DisplayName = c.String(nullable: false),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SystemClasses", t => t.SystemClassId)
                .Index(t => t.SystemClassId);
            
            CreateTable(
                "dbo.AbilityEffects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EffectId = c.Int(),
                        TargetClass = c.Int(nullable: false),
                        MaxNumber = c.Int(nullable: false),
                        AbilityId = c.Int(nullable: false),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Abilities", t => t.AbilityId)
                .ForeignKey("dbo.Effects", t => t.EffectId)
                .Index(t => t.EffectId)
                .Index(t => t.AbilityId);
            
            CreateTable(
                "dbo.EffectDynamicZones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ZoneId = c.Int(),
                        EffectId = c.Int(nullable: false),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Effects", t => t.EffectId)
                .ForeignKey("dbo.Zones", t => t.ZoneId)
                .Index(t => t.ZoneId)
                .Index(t => t.EffectId);
            
            CreateTable(
                "dbo.ZoneAccesses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AccessName = c.String(nullable: false),
                        AccessValue = c.Int(nullable: false),
                        ZoneId = c.Int(nullable: false),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Zones", t => t.ZoneId)
                .Index(t => t.ZoneId);
            
            CreateTable(
                "dbo.ZoneDynamics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MaxNumberOfSpaces = c.Int(nullable: false),
                        MinNumberOfSpaces = c.Int(nullable: false),
                        DecayTimeInSeconds = c.Int(nullable: false),
                        AbilityId = c.Int(),
                        MobileId = c.Int(),
                        ZoneId = c.Int(nullable: false),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Abilities", t => t.AbilityId)
                .ForeignKey("dbo.Mobiles", t => t.MobileId)
                .ForeignKey("dbo.Zones", t => t.ZoneId)
                .Index(t => t.AbilityId)
                .Index(t => t.MobileId)
                .Index(t => t.ZoneId);
            
            CreateTable(
                "dbo.MobileAbilities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AbilityId = c.Int(),
                        IsDefault = c.Boolean(nullable: false),
                        MobileId = c.Int(nullable: false),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Abilities", t => t.AbilityId)
                .ForeignKey("dbo.Mobiles", t => t.MobileId)
                .Index(t => t.AbilityId)
                .Index(t => t.MobileId);
            
            CreateTable(
                "dbo.MobileAIs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MonsterClass = c.Int(nullable: false),
                        BehaviorId = c.Int(),
                        MobileId = c.Int(nullable: false),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Behaviors", t => t.BehaviorId)
                .ForeignKey("dbo.Mobiles", t => t.MobileId)
                .Index(t => t.BehaviorId)
                .Index(t => t.MobileId);
            
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
                "dbo.TagSets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TagCategory = c.Int(nullable: false),
                        Name = c.String(maxLength: 50),
                        CreateDateUtc = c.DateTime(),
                        TagSet_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TagSets", t => t.TagSet_Id)
                .Index(t => t.TagSet_Id);
            
            CreateTable(
                "dbo.FactionRelations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TargetFactionId = c.Int(),
                        FactionRelationshipType = c.Int(nullable: false),
                        FactionId = c.Int(nullable: false),
                        CreateDateUtc = c.DateTime(),
                        Faction_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Factions", t => t.FactionId)
                .ForeignKey("dbo.Factions", t => t.TargetFactionId)
                .ForeignKey("dbo.Factions", t => t.Faction_Id)
                .Index(t => t.TargetFactionId)
                .Index(t => t.FactionId)
                .Index(t => t.Faction_Id);
            
            CreateTable(
                "dbo.MobileEquipments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(),
                        WornAtId = c.Int(),
                        Quantity = c.Int(nullable: false),
                        MobileId = c.Int(nullable: false),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Items", t => t.ItemId)
                .ForeignKey("dbo.Mobiles", t => t.MobileId)
                .ForeignKey("dbo.WearLocations", t => t.WornAtId)
                .Index(t => t.ItemId)
                .Index(t => t.WornAtId)
                .Index(t => t.MobileId);
            
            CreateTable(
                "dbo.ItemBooks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(nullable: false),
                        Text = c.String(),
                        AbilityId = c.Int(),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Abilities", t => t.AbilityId)
                .ForeignKey("dbo.Items", t => t.ItemId)
                .Index(t => t.ItemId)
                .Index(t => t.AbilityId);
            
            CreateTable(
                "dbo.ItemContainers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(nullable: false),
                        WeightAllowance = c.Int(nullable: false),
                        VolumeAllowance = c.Int(nullable: false),
                        LockItemId = c.Int(),
                        CreateDateUtc = c.DateTime(),
                        Item_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Items", t => t.ItemId)
                .ForeignKey("dbo.Items", t => t.LockItemId)
                .ForeignKey("dbo.Items", t => t.Item_Id)
                .Index(t => t.ItemId)
                .Index(t => t.LockItemId)
                .Index(t => t.Item_Id);
            
            CreateTable(
                "dbo.ItemDrinkContainers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(nullable: false),
                        LiquidId = c.Int(),
                        MaxCharges = c.Int(nullable: false),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Items", t => t.ItemId)
                .ForeignKey("dbo.Liquids", t => t.LiquidId)
                .Index(t => t.ItemId)
                .Index(t => t.LiquidId);
            
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
                "dbo.ItemFoods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(nullable: false),
                        HungerPoints = c.Int(nullable: false),
                        Charges = c.Int(nullable: false),
                        TimeFoodIsEdibleInSeconds = c.Int(nullable: false),
                        TimeFoodIsDecayingInSeconds = c.Int(nullable: false),
                        DecayDescription = c.String(),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Items", t => t.ItemId)
                .Index(t => t.ItemId);
            
            CreateTable(
                "dbo.ItemFormulaResources",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(nullable: false),
                        ResourceItemId = c.Int(),
                        Quantity = c.Int(nullable: false),
                        CreateDateUtc = c.DateTime(),
                        Item_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Items", t => t.ItemId)
                .ForeignKey("dbo.Items", t => t.ResourceItemId)
                .ForeignKey("dbo.Items", t => t.Item_Id)
                .Index(t => t.ItemId)
                .Index(t => t.ResourceItemId)
                .Index(t => t.Item_Id);
            
            CreateTable(
                "dbo.ItemFormulas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(nullable: false),
                        SkillId = c.Int(),
                        SkillValue = c.Int(nullable: false),
                        ProductItemId = c.Int(nullable: false),
                        ProductQuantity = c.Int(nullable: false),
                        MachineItemId = c.Int(),
                        ToolItemId = c.Int(),
                        ExperienceValue = c.Int(nullable: false),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Items", t => t.ItemId)
                .ForeignKey("dbo.Items", t => t.MachineItemId)
                .ForeignKey("dbo.Items", t => t.ProductItemId)
                .ForeignKey("dbo.Skills", t => t.SkillId)
                .ForeignKey("dbo.Items", t => t.ToolItemId)
                .Index(t => t.ItemId)
                .Index(t => t.SkillId)
                .Index(t => t.ProductItemId)
                .Index(t => t.MachineItemId)
                .Index(t => t.ToolItemId);
            
            CreateTable(
                "dbo.ItemFurnitures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(nullable: false),
                        MaxCapacity = c.Int(nullable: false),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Items", t => t.ItemId)
                .Index(t => t.ItemId);
            
            CreateTable(
                "dbo.ItemSetBonuses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemSetId = c.Int(nullable: false),
                        Statistic = c.Int(nullable: false),
                        SkillId = c.Int(),
                        ValueMod = c.Int(nullable: false),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ItemSets", t => t.ItemSetId)
                .ForeignKey("dbo.Skills", t => t.SkillId)
                .Index(t => t.ItemSetId)
                .Index(t => t.SkillId);
            
            CreateTable(
                "dbo.ItemSetItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemSetId = c.Int(nullable: false),
                        ItemId = c.Int(),
                        CreateDateUtc = c.DateTime(),
                        ItemSet_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Items", t => t.ItemId)
                .ForeignKey("dbo.ItemSets", t => t.ItemSetId)
                .ForeignKey("dbo.ItemSets", t => t.ItemSet_Id)
                .Index(t => t.ItemSetId)
                .Index(t => t.ItemId)
                .Index(t => t.ItemSet_Id);
            
            CreateTable(
                "dbo.ItemLights",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(nullable: false),
                        FuelType = c.Int(nullable: false),
                        FuelItemId = c.Int(),
                        Charges = c.Int(nullable: false),
                        BurnRate = c.Int(nullable: false),
                        CreateDateUtc = c.DateTime(),
                        Item_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Items", t => t.FuelItemId)
                .ForeignKey("dbo.Items", t => t.ItemId)
                .ForeignKey("dbo.Items", t => t.Item_Id)
                .Index(t => t.ItemId)
                .Index(t => t.FuelItemId)
                .Index(t => t.Item_Id);
            
            CreateTable(
                "dbo.ItemLocks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(nullable: false),
                        PickStatistic = c.Int(nullable: false),
                        PickSkillId = c.Int(),
                        Difficulty = c.Int(nullable: false),
                        KeyItemId = c.Int(),
                        CreateDateUtc = c.DateTime(),
                        Item_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Items", t => t.ItemId)
                .ForeignKey("dbo.Items", t => t.KeyItemId)
                .ForeignKey("dbo.Skills", t => t.PickSkillId)
                .ForeignKey("dbo.Items", t => t.Item_Id)
                .Index(t => t.ItemId)
                .Index(t => t.PickSkillId)
                .Index(t => t.KeyItemId)
                .Index(t => t.Item_Id);
            
            CreateTable(
                "dbo.ItemMachines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(nullable: false),
                        MachineType = c.Int(nullable: false),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Items", t => t.ItemId)
                .Index(t => t.ItemId);
            
            CreateTable(
                "dbo.ItemMagicalNodes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(nullable: false),
                        EffectId = c.Int(),
                        Duration = c.Int(nullable: false),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Effects", t => t.EffectId)
                .ForeignKey("dbo.Items", t => t.ItemId)
                .Index(t => t.ItemId)
                .Index(t => t.EffectId);
            
            CreateTable(
                "dbo.ItemMudProgs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(nullable: false),
                        EventId = c.Int(),
                        MudProgId = c.Int(),
                        PercentChance = c.Single(nullable: false),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.EventId)
                .ForeignKey("dbo.Items", t => t.ItemId)
                .ForeignKey("dbo.MudProgs", t => t.MudProgId)
                .Index(t => t.ItemId)
                .Index(t => t.EventId)
                .Index(t => t.MudProgId);
            
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
                "dbo.ItemPortals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(nullable: false),
                        DestinationId = c.Int(),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Spaces", t => t.DestinationId)
                .ForeignKey("dbo.Items", t => t.ItemId)
                .Index(t => t.ItemId)
                .Index(t => t.DestinationId);
            
            CreateTable(
                "dbo.SpacePortals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Direction = c.Int(nullable: false),
                        TargetSpaceId = c.Int(),
                        BarrierId = c.Int(),
                        Bits = c.Int(nullable: false),
                        Keywords = c.String(nullable: false),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Barriers", t => t.BarrierId)
                .ForeignKey("dbo.Spaces", t => t.TargetSpaceId)
                .Index(t => t.TargetSpaceId)
                .Index(t => t.BarrierId);
            
            CreateTable(
                "dbo.TerrainRestrictions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TerrainId = c.Int(nullable: false),
                        CreateDateUtc = c.DateTime(),
                        MoementMode_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MovementModes", t => t.MoementMode_Id)
                .ForeignKey("dbo.Terrains", t => t.TerrainId)
                .Index(t => t.TerrainId)
                .Index(t => t.MoementMode_Id);
            
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
                "dbo.ItemPotions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(nullable: false),
                        AbilityId = c.Int(),
                        Charges = c.Int(nullable: false),
                        ColorId = c.Int(),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Abilities", t => t.AbilityId)
                .ForeignKey("dbo.Colors", t => t.ColorId)
                .ForeignKey("dbo.Items", t => t.ItemId)
                .Index(t => t.ItemId)
                .Index(t => t.AbilityId)
                .Index(t => t.ColorId);
            
            CreateTable(
                "dbo.ItemPrerequisites",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(nullable: false),
                        MinLevel = c.Int(nullable: false),
                        RaceId = c.Int(),
                        FactionId = c.Int(),
                        FactionLevel = c.Int(nullable: false),
                        Statistic = c.Int(nullable: false),
                        StatisticValue = c.Int(nullable: false),
                        SkillId = c.Int(),
                        SkillValue = c.Int(nullable: false),
                        Gender = c.Int(nullable: false),
                        ArchetypeId = c.Int(),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Archetypes", t => t.ArchetypeId)
                .ForeignKey("dbo.Factions", t => t.FactionId)
                .ForeignKey("dbo.Items", t => t.ItemId)
                .ForeignKey("dbo.Races", t => t.RaceId)
                .ForeignKey("dbo.Skills", t => t.SkillId)
                .Index(t => t.ItemId)
                .Index(t => t.RaceId)
                .Index(t => t.FactionId)
                .Index(t => t.SkillId)
                .Index(t => t.ArchetypeId);
            
            CreateTable(
                "dbo.ArchetypeAbilities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AbilityId = c.Int(),
                        IsExempt = c.Boolean(nullable: false),
                        IsAutoAttack = c.Boolean(nullable: false),
                        ArchetypeId = c.Int(nullable: false),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Abilities", t => t.AbilityId)
                .ForeignKey("dbo.Archetypes", t => t.ArchetypeId)
                .Index(t => t.AbilityId)
                .Index(t => t.ArchetypeId);
            
            CreateTable(
                "dbo.ArchetypeSkillCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SkillCategoryId = c.Int(),
                        IsPreferred = c.Boolean(nullable: false),
                        IsRestricted = c.Boolean(nullable: false),
                        ArchetypeId = c.Int(nullable: false),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Archetypes", t => t.ArchetypeId)
                .ForeignKey("dbo.SkillCategories", t => t.SkillCategoryId)
                .Index(t => t.SkillCategoryId)
                .Index(t => t.ArchetypeId);
            
            CreateTable(
                "dbo.ArchetypeStatistics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Statistic = c.Int(nullable: false),
                        SkillId = c.Int(),
                        ModValue = c.Int(nullable: false),
                        IsExempt = c.Boolean(nullable: false),
                        ArchetypeId = c.Int(nullable: false),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Archetypes", t => t.ArchetypeId)
                .ForeignKey("dbo.Skills", t => t.SkillId)
                .Index(t => t.SkillId)
                .Index(t => t.ArchetypeId);
            
            CreateTable(
                "dbo.RaceAbilities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AbilityId = c.Int(),
                        RaceId = c.Int(nullable: false),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Abilities", t => t.AbilityId)
                .ForeignKey("dbo.Races", t => t.RaceId)
                .Index(t => t.AbilityId)
                .Index(t => t.RaceId);
            
            CreateTable(
                "dbo.RaceHitLocations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HitLocationId = c.Int(),
                        RaceId = c.Int(nullable: false),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.WearLocations", t => t.HitLocationId)
                .ForeignKey("dbo.Races", t => t.RaceId)
                .Index(t => t.HitLocationId)
                .Index(t => t.RaceId);
            
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
                "dbo.RaceStatistics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Statistic = c.Int(nullable: false),
                        SkillId = c.Int(),
                        ValueMod = c.Int(nullable: false),
                        RaceId = c.Int(nullable: false),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Races", t => t.RaceId)
                .ForeignKey("dbo.Skills", t => t.SkillId)
                .Index(t => t.SkillId)
                .Index(t => t.RaceId);
            
            CreateTable(
                "dbo.ItemResourceNodes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(nullable: false),
                        ResourceItemId = c.Int(),
                        ToolType = c.Int(nullable: false),
                        SkillId = c.Int(),
                        MinSkill = c.Int(nullable: false),
                        MinGatherAmount = c.Int(nullable: false),
                        MaxGatherAmount = c.Int(nullable: false),
                        CreateDateUtc = c.DateTime(),
                        Item_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Items", t => t.ItemId)
                .ForeignKey("dbo.Items", t => t.ResourceItemId)
                .ForeignKey("dbo.Skills", t => t.SkillId)
                .ForeignKey("dbo.Items", t => t.Item_Id)
                .Index(t => t.ItemId)
                .Index(t => t.ResourceItemId)
                .Index(t => t.SkillId)
                .Index(t => t.Item_Id);
            
            CreateTable(
                "dbo.ItemStatistics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(nullable: false),
                        Statistic = c.Int(nullable: false),
                        SkillId = c.Int(),
                        ValueMod = c.Int(nullable: false),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Items", t => t.ItemId)
                .ForeignKey("dbo.Skills", t => t.SkillId)
                .Index(t => t.ItemId)
                .Index(t => t.SkillId);
            
            CreateTable(
                "dbo.ItemTools",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(nullable: false),
                        ToolType = c.Int(nullable: false),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Items", t => t.ItemId)
                .Index(t => t.ItemId);
            
            CreateTable(
                "dbo.ItemTraps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(nullable: false),
                        DisarmStatistic = c.Int(nullable: false),
                        DisarmSkillId = c.Int(),
                        Difficulty = c.Int(nullable: false),
                        OnFailTargetClassType = c.Int(nullable: false),
                        OnFailEffectId = c.Int(),
                        NotifyRadius = c.Int(nullable: false),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Skills", t => t.DisarmSkillId)
                .ForeignKey("dbo.Items", t => t.ItemId)
                .ForeignKey("dbo.Effects", t => t.OnFailEffectId)
                .Index(t => t.ItemId)
                .Index(t => t.DisarmSkillId)
                .Index(t => t.OnFailEffectId);
            
            CreateTable(
                "dbo.ItemTreasures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(nullable: false),
                        TreasureId = c.Int(),
                        Quantity = c.Int(nullable: false),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Items", t => t.ItemId)
                .ForeignKey("dbo.Treasures", t => t.TreasureId)
                .Index(t => t.ItemId)
                .Index(t => t.TreasureId);
            
            CreateTable(
                "dbo.TreasurePrimitives",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PrimitiveId = c.Int(),
                        Weight = c.Int(nullable: false),
                        MaxPulls = c.Int(nullable: false),
                        TreasureId = c.Int(nullable: false),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Primitives", t => t.PrimitiveId)
                .ForeignKey("dbo.Treasures", t => t.TreasureId)
                .Index(t => t.PrimitiveId)
                .Index(t => t.TreasureId);
            
            CreateTable(
                "dbo.GameCommandPositions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PositionType = c.Int(nullable: false),
                        GameCommandId = c.Int(nullable: false),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GameCommands", t => t.GameCommandId)
                .Index(t => t.GameCommandId);
            
            CreateTable(
                "dbo.GameCommandUserStates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserStateType = c.Int(nullable: false),
                        GameCommandId = c.Int(nullable: false),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GameCommands", t => t.GameCommandId)
                .Index(t => t.GameCommandId);
            
            CreateTable(
                "dbo.MonthEffects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EffectId = c.Int(),
                        MonthId = c.Int(nullable: false),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Effects", t => t.EffectId)
                .ForeignKey("dbo.Months", t => t.MonthId)
                .Index(t => t.EffectId)
                .Index(t => t.MonthId);
            
            CreateTable(
                "dbo.QuestActions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsStart = c.Boolean(nullable: false),
                        MobileId = c.Int(),
                        Coin = c.Int(nullable: false),
                        Experience = c.Int(nullable: false),
                        GivePrimitiveId = c.Int(),
                        DeletePrimitiveId = c.Int(),
                        Quantity = c.Int(nullable: false),
                        MudProgId = c.Int(),
                        JournalEntry = c.String(),
                        QuestId = c.Int(nullable: false),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Primitives", t => t.DeletePrimitiveId)
                .ForeignKey("dbo.Primitives", t => t.GivePrimitiveId)
                .ForeignKey("dbo.Mobiles", t => t.MobileId)
                .ForeignKey("dbo.MudProgs", t => t.MudProgId)
                .ForeignKey("dbo.Quests", t => t.QuestId)
                .Index(t => t.MobileId)
                .Index(t => t.GivePrimitiveId)
                .Index(t => t.DeletePrimitiveId)
                .Index(t => t.MudProgId)
                .Index(t => t.QuestId);
            
            CreateTable(
                "dbo.QuestProgresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuestProgressType = c.Int(nullable: false),
                        PrimitiveId = c.Int(),
                        Quantity = c.Int(nullable: false),
                        ProgressName = c.String(),
                        QuestId = c.Int(nullable: false),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Primitives", t => t.PrimitiveId)
                .ForeignKey("dbo.Quests", t => t.QuestId)
                .Index(t => t.PrimitiveId)
                .Index(t => t.QuestId);
            
            CreateTable(
                "dbo.QuestRequirements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RaceId = c.Int(),
                        NotRaceId = c.Int(),
                        Statistic = c.Int(nullable: false),
                        SkillId = c.Int(),
                        Value = c.Int(nullable: false),
                        Level = c.Int(nullable: false),
                        QuestCompletedId = c.Int(),
                        QuestNotCompletedId = c.Int(),
                        HasItemId = c.Int(),
                        FactionId = c.Int(),
                        FactionLevel = c.Int(nullable: false),
                        QuestId = c.Int(nullable: false),
                        CreateDateUtc = c.DateTime(),
                        Quest_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Factions", t => t.FactionId)
                .ForeignKey("dbo.Items", t => t.HasItemId)
                .ForeignKey("dbo.Races", t => t.NotRaceId)
                .ForeignKey("dbo.Quests", t => t.QuestId)
                .ForeignKey("dbo.Quests", t => t.QuestCompletedId)
                .ForeignKey("dbo.Quests", t => t.QuestNotCompletedId)
                .ForeignKey("dbo.Races", t => t.RaceId)
                .ForeignKey("dbo.Skills", t => t.SkillId)
                .ForeignKey("dbo.Quests", t => t.Quest_Id)
                .Index(t => t.RaceId)
                .Index(t => t.NotRaceId)
                .Index(t => t.SkillId)
                .Index(t => t.QuestCompletedId)
                .Index(t => t.QuestNotCompletedId)
                .Index(t => t.HasItemId)
                .Index(t => t.FactionId)
                .Index(t => t.QuestId)
                .Index(t => t.Quest_Id);
            
            CreateTable(
                "dbo.RitualEffects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EffectId = c.Int(),
                        TargetClassType = c.Int(nullable: false),
                        Bits = c.Int(nullable: false),
                        RitualId = c.Int(nullable: false),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Effects", t => t.EffectId)
                .ForeignKey("dbo.Rituals", t => t.RitualId)
                .Index(t => t.EffectId)
                .Index(t => t.RitualId);
            
            CreateTable(
                "dbo.RitualParticipants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FocusItemId = c.Int(),
                        WearLocationId = c.Int(),
                        RitualId = c.Int(nullable: false),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Items", t => t.FocusItemId)
                .ForeignKey("dbo.Rituals", t => t.RitualId)
                .ForeignKey("dbo.WearLocations", t => t.WearLocationId)
                .Index(t => t.FocusItemId)
                .Index(t => t.WearLocationId)
                .Index(t => t.RitualId);
            
            CreateTable(
                "dbo.RitualReagants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReagantItemId = c.Int(),
                        Quantity = c.Int(nullable: false),
                        RitualId = c.Int(nullable: false),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Items", t => t.ReagantItemId)
                .ForeignKey("dbo.Rituals", t => t.RitualId)
                .Index(t => t.ReagantItemId)
                .Index(t => t.RitualId);
            
            CreateTable(
                "dbo.RitualRequirements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MinLevel = c.Int(nullable: false),
                        RaceId = c.Int(),
                        FactionId = c.Int(),
                        FactionLevel = c.Int(nullable: false),
                        Statistic = c.Int(nullable: false),
                        SkillId = c.Int(),
                        MinValue = c.Int(nullable: false),
                        RitualId = c.Int(nullable: false),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Factions", t => t.FactionId)
                .ForeignKey("dbo.Races", t => t.RaceId)
                .ForeignKey("dbo.Rituals", t => t.RitualId)
                .ForeignKey("dbo.Skills", t => t.SkillId)
                .Index(t => t.RaceId)
                .Index(t => t.FactionId)
                .Index(t => t.SkillId)
                .Index(t => t.RitualId);
            
            CreateTable(
                "dbo.ShopBuyTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemType = c.Int(nullable: false),
                        ShopId = c.Int(nullable: false),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Shops", t => t.ShopId)
                .Index(t => t.ShopId);
            
            CreateTable(
                "dbo.ShopPrimitives",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PrimitiveId = c.Int(),
                        Quantity = c.Int(nullable: false),
                        ShopId = c.Int(nullable: false),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Primitives", t => t.PrimitiveId)
                .ForeignKey("dbo.Shops", t => t.ShopId)
                .Index(t => t.PrimitiveId)
                .Index(t => t.ShopId);
            
            CreateTable(
                "dbo.SpawnLocations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SpaceId = c.Int(),
                        AccessLevel = c.Int(nullable: false),
                        SpawnId = c.Int(nullable: false),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Spaces", t => t.SpaceId)
                .ForeignKey("dbo.Spawns", t => t.SpawnId)
                .Index(t => t.SpaceId)
                .Index(t => t.SpawnId);
            
            CreateTable(
                "dbo.SpawnPrimitives",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PrimitiveId = c.Int(),
                        SpawnId = c.Int(nullable: false),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Primitives", t => t.PrimitiveId)
                .ForeignKey("dbo.Spawns", t => t.SpawnId)
                .Index(t => t.PrimitiveId)
                .Index(t => t.SpawnId);
            
            CreateTable(
                "dbo.ItemVehicles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(nullable: false),
                        MaxCapacity = c.Int(nullable: false),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Items", t => t.ItemId)
                .Index(t => t.ItemId);
            
            CreateTable(
                "dbo.ItemVehicleTerrains",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemVehicleId = c.Int(nullable: false),
                        TerrainId = c.Int(),
                        CreateDateUtc = c.DateTime(),
                        Item_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ItemVehicles", t => t.ItemVehicleId)
                .ForeignKey("dbo.Terrains", t => t.TerrainId)
                .ForeignKey("dbo.Items", t => t.Item_Id)
                .Index(t => t.ItemVehicleId)
                .Index(t => t.TerrainId)
                .Index(t => t.Item_Id);
            
            CreateTable(
                "dbo.ItemWeapons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(nullable: false),
                        DamageType = c.Int(nullable: false),
                        MinDamage = c.Int(nullable: false),
                        MaxDamage = c.Int(nullable: false),
                        SkillId = c.Int(),
                        SpeedClassType = c.Int(nullable: false),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Items", t => t.ItemId)
                .ForeignKey("dbo.Skills", t => t.SkillId)
                .Index(t => t.ItemId)
                .Index(t => t.SkillId);
            
            CreateTable(
                "dbo.ItemWearLocations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(nullable: false),
                        WornAtId = c.Int(),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Items", t => t.ItemId)
                .ForeignKey("dbo.WearLocations", t => t.WornAtId)
                .Index(t => t.ItemId)
                .Index(t => t.WornAtId);
            
            CreateTable(
                "dbo.MobileMudProgs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EventId = c.Int(),
                        MudProgId = c.Int(),
                        PercentChance = c.Single(nullable: false),
                        MobileId = c.Int(nullable: false),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.EventId)
                .ForeignKey("dbo.Mobiles", t => t.MobileId)
                .ForeignKey("dbo.MudProgs", t => t.MudProgId)
                .Index(t => t.EventId)
                .Index(t => t.MudProgId)
                .Index(t => t.MobileId);
            
            CreateTable(
                "dbo.MobileResources",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NodeItemId = c.Int(),
                        NodeType = c.Int(nullable: false),
                        MobileId = c.Int(nullable: false),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Mobiles", t => t.MobileId)
                .ForeignKey("dbo.Items", t => t.NodeItemId)
                .Index(t => t.NodeItemId)
                .Index(t => t.MobileId);
            
            CreateTable(
                "dbo.MobileStatistics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Statistic = c.Int(nullable: false),
                        SkillId = c.Int(),
                        Value = c.Int(nullable: false),
                        MobileId = c.Int(nullable: false),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Mobiles", t => t.MobileId)
                .ForeignKey("dbo.Skills", t => t.SkillId)
                .Index(t => t.SkillId)
                .Index(t => t.MobileId);
            
            CreateTable(
                "dbo.MobileTreasures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MinPulls = c.Int(nullable: false),
                        MaxPulls = c.Int(nullable: false),
                        MobileId = c.Int(nullable: false),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Mobiles", t => t.MobileId)
                .Index(t => t.MobileId);
            
            CreateTable(
                "dbo.MobileTreasureTables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TreasureId = c.Int(),
                        MinCoin = c.Int(nullable: false),
                        MaxCoin = c.Int(nullable: false),
                        Weight = c.Int(nullable: false),
                        MaxPulls = c.Int(nullable: false),
                        MobileId = c.Int(nullable: false),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Mobiles", t => t.MobileId)
                .ForeignKey("dbo.Treasures", t => t.TreasureId)
                .Index(t => t.TreasureId)
                .Index(t => t.MobileId);
            
            CreateTable(
                "dbo.MobileVendor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ShopId = c.Int(),
                        Value = c.Int(nullable: false),
                        MobileId = c.Int(nullable: false),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Mobiles", t => t.MobileId)
                .ForeignKey("dbo.Shops", t => t.ShopId)
                .Index(t => t.ShopId)
                .Index(t => t.MobileId);
            
            CreateTable(
                "dbo.ZoneResets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ResetId = c.Int(),
                        ZoneId = c.Int(nullable: false),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Resets", t => t.ResetId)
                .ForeignKey("dbo.Zones", t => t.ZoneId)
                .Index(t => t.ResetId)
                .Index(t => t.ZoneId);
            
            CreateTable(
                "dbo.ZoneSpaces",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SpaceId = c.Int(),
                        ZoneId = c.Int(nullable: false),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Spaces", t => t.SpaceId)
                .ForeignKey("dbo.Zones", t => t.ZoneId)
                .Index(t => t.SpaceId)
                .Index(t => t.ZoneId);
            
            CreateTable(
                "dbo.ZoneSpawns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SpawnId = c.Int(),
                        ZoneId = c.Int(nullable: false),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Spawns", t => t.SpawnId)
                .ForeignKey("dbo.Zones", t => t.ZoneId)
                .Index(t => t.SpawnId)
                .Index(t => t.ZoneId);
            
            CreateTable(
                "dbo.EffectHealthChanges",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HealthChangeType = c.Int(nullable: false),
                        ChangeMin = c.Int(nullable: false),
                        ChangeMax = c.Int(nullable: false),
                        DamageType = c.Int(nullable: false),
                        EffectId = c.Int(nullable: false),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Effects", t => t.EffectId)
                .Index(t => t.EffectId);
            
            CreateTable(
                "dbo.EffectPositions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PositionType = c.Int(nullable: false),
                        EffectId = c.Int(nullable: false),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Effects", t => t.EffectId)
                .Index(t => t.EffectId);
            
            CreateTable(
                "dbo.EffectPrimitives",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PrimitiveId = c.Int(),
                        EffectId = c.Int(nullable: false),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Effects", t => t.EffectId)
                .ForeignKey("dbo.Primitives", t => t.PrimitiveId)
                .Index(t => t.PrimitiveId)
                .Index(t => t.EffectId);
            
            CreateTable(
                "dbo.EffectStatMods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AffectedStatistic = c.Int(nullable: false),
                        AffectedSkillId = c.Int(),
                        ElementId = c.Int(),
                        MinValue = c.Int(nullable: false),
                        MaxValue = c.Int(nullable: false),
                        EffectId = c.Int(nullable: false),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Skills", t => t.AffectedSkillId)
                .ForeignKey("dbo.Effects", t => t.EffectId)
                .ForeignKey("dbo.Elements", t => t.ElementId)
                .Index(t => t.AffectedSkillId)
                .Index(t => t.ElementId)
                .Index(t => t.EffectId);
            
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
                "dbo.GuildAbilities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AbilityId = c.Int(),
                        Cost = c.Int(nullable: false),
                        RequiredLevel = c.Int(nullable: false),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Abilities", t => t.AbilityId)
                .Index(t => t.AbilityId);
            
            CreateTable(
                "dbo.AbilityPrerequisites",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MinLevel = c.Int(nullable: false),
                        RaceId = c.Int(),
                        FactionId = c.Int(),
                        FactionLevel = c.Int(nullable: false),
                        Statistic = c.Int(nullable: false),
                        StatisticValue = c.Int(nullable: false),
                        SkillId = c.Int(),
                        SkillValue = c.Int(nullable: false),
                        AbilityId = c.Int(nullable: false),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Abilities", t => t.AbilityId)
                .ForeignKey("dbo.Factions", t => t.FactionId)
                .ForeignKey("dbo.Races", t => t.RaceId)
                .ForeignKey("dbo.Skills", t => t.SkillId)
                .Index(t => t.RaceId)
                .Index(t => t.FactionId)
                .Index(t => t.SkillId)
                .Index(t => t.AbilityId);
            
            CreateTable(
                "dbo.AbilityReagants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(),
                        Quantity = c.Int(nullable: false),
                        AbilityId = c.Int(nullable: false),
                        CreateDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Abilities", t => t.AbilityId)
                .ForeignKey("dbo.Items", t => t.ItemId)
                .Index(t => t.ItemId)
                .Index(t => t.AbilityId);
            
            CreateTable(
                "ref.BankUpgrades",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BankLevel = c.Int(nullable: false),
                        UpgradeCost = c.Int(nullable: false),
                        StackLimit = c.Int(nullable: false),
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
                "ref.GameConstants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 1024),
                        Type = c.String(maxLength: 20),
                        GameConstantCategory = c.Int(nullable: false),
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
                        DisplayDescription = c.String(nullable: false),
                        ManaCost = c.Int(nullable: false),
                        StaminaCost = c.Int(nullable: false),
                        PreDelay = c.Single(nullable: false),
                        PostDelay = c.Single(nullable: false),
                        OffensiveStat = c.Int(nullable: false),
                        DefensiveStat = c.Int(nullable: false),
                        Bits = c.Int(nullable: false),
                        TerrainId = c.Int(),
                        TagSetId = c.Int(),
                        InterruptionResistSkillId = c.Int(),
                        InterruptionEffectId = c.Int(),
                        RechargeRate = c.Single(nullable: false),
                        TargetClass = c.Int(nullable: false),
                        VerbalText = c.String(),
                        BeginUseText = c.String(),
                        UseText = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Primitives", t => t.Id)
                .ForeignKey("dbo.Terrains", t => t.TerrainId)
                .ForeignKey("dbo.TagSets", t => t.TagSetId)
                .ForeignKey("dbo.Skills", t => t.InterruptionResistSkillId)
                .ForeignKey("dbo.Effects", t => t.InterruptionEffectId)
                .Index(t => t.Id)
                .Index(t => t.TerrainId)
                .Index(t => t.TagSetId)
                .Index(t => t.InterruptionResistSkillId)
                .Index(t => t.InterruptionEffectId);
            
            CreateTable(
                "dbo.Archetypes",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        DisplayDescription = c.String(nullable: false),
                        TagSetId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Primitives", t => t.Id)
                .ForeignKey("dbo.TagSets", t => t.TagSetId)
                .Index(t => t.Id)
                .Index(t => t.TagSetId);
            
            CreateTable(
                "dbo.Barriers",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        MaterialType = c.Int(nullable: false),
                        Bits = c.Int(nullable: false),
                        KeyItemId = c.Int(),
                        LockItemId = c.Int(),
                        TrapItemId = c.Int(),
                        TagSetId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Primitives", t => t.Id)
                .ForeignKey("dbo.Items", t => t.KeyItemId)
                .ForeignKey("dbo.Items", t => t.LockItemId)
                .ForeignKey("dbo.Items", t => t.TrapItemId)
                .ForeignKey("dbo.TagSets", t => t.TagSetId)
                .Index(t => t.Id)
                .Index(t => t.KeyItemId)
                .Index(t => t.LockItemId)
                .Index(t => t.TrapItemId)
                .Index(t => t.TagSetId);
            
            CreateTable(
                "dbo.Behaviors",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Bits = c.Int(nullable: false),
                        TagSetId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Primitives", t => t.Id)
                .ForeignKey("dbo.TagSets", t => t.TagSetId)
                .Index(t => t.Id)
                .Index(t => t.TagSetId);
            
            CreateTable(
                "dbo.Conversations",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        IsDefault = c.Boolean(nullable: false),
                        RequiredFactionId = c.Int(),
                        RequiredFactionLevel = c.Int(nullable: false),
                        TagSetId = c.Int(),
                        Keywords = c.String(),
                        Text = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Primitives", t => t.Id)
                .ForeignKey("dbo.Factions", t => t.RequiredFactionId)
                .ForeignKey("dbo.TagSets", t => t.TagSetId)
                .Index(t => t.Id)
                .Index(t => t.RequiredFactionId)
                .Index(t => t.TagSetId);
            
            CreateTable(
                "dbo.Effects",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        DisplayDescription = c.String(nullable: false),
                        EffectType = c.Int(nullable: false),
                        Duration = c.Int(nullable: false),
                        Bits = c.Int(nullable: false),
                        ResistStatistic = c.Int(nullable: false),
                        OnFailEffectId = c.Int(),
                        OnResistEffectId = c.Int(),
                        TagSetId = c.Int(),
                        MovementModeBitField = c.Int(nullable: false),
                        ApplicationTextSelf = c.String(),
                        ApplicationTextOther = c.String(),
                        FadeTextSelf = c.String(),
                        FadeTextOther = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Primitives", t => t.Id)
                .ForeignKey("dbo.Effects", t => t.OnFailEffectId)
                .ForeignKey("dbo.Effects", t => t.OnResistEffectId)
                .ForeignKey("dbo.TagSets", t => t.TagSetId)
                .Index(t => t.Id)
                .Index(t => t.OnFailEffectId)
                .Index(t => t.OnResistEffectId)
                .Index(t => t.TagSetId);
            
            CreateTable(
                "dbo.Factions",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        TagSetId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Primitives", t => t.Id)
                .ForeignKey("dbo.TagSets", t => t.TagSetId)
                .Index(t => t.Id)
                .Index(t => t.TagSetId);
            
            CreateTable(
                "dbo.GameCommands",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        LogActionType = c.Int(nullable: false),
                        Bits = c.Int(nullable: false),
                        TagSetId = c.Int(),
                        Keywords = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Primitives", t => t.Id)
                .ForeignKey("dbo.TagSets", t => t.TagSetId)
                .Index(t => t.Id)
                .Index(t => t.TagSetId);
            
            CreateTable(
                "dbo.Helps",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Keywords = c.String(),
                        Text = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Primitives", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        ItemType = c.Int(nullable: false),
                        Weight = c.Int(nullable: false),
                        MaterialType = c.Int(nullable: false),
                        CoinValue = c.Int(nullable: false),
                        SizeType = c.Int(nullable: false),
                        MaxStackSize = c.Int(nullable: false),
                        Bits = c.Int(nullable: false),
                        ConditionType = c.Int(nullable: false),
                        UseAbilityId = c.Int(),
                        UseAbilityFrequency = c.Int(nullable: false),
                        SpotStatistic = c.Int(nullable: false),
                        SpotDifficultyType = c.Int(nullable: false),
                        TrapItemId = c.Int(),
                        TagSetId = c.Int(),
                        ItemClassType = c.Int(nullable: false),
                        ItemSetId = c.Int(),
                        DisplayDescription = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Primitives", t => t.Id)
                .ForeignKey("dbo.Abilities", t => t.UseAbilityId)
                .ForeignKey("dbo.Items", t => t.TrapItemId)
                .ForeignKey("dbo.TagSets", t => t.TagSetId)
                .ForeignKey("dbo.ItemSets", t => t.ItemSetId)
                .Index(t => t.Id)
                .Index(t => t.UseAbilityId)
                .Index(t => t.TrapItemId)
                .Index(t => t.TagSetId)
                .Index(t => t.ItemSetId);
            
            CreateTable(
                "dbo.ItemSets",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        DisplayDescription = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Primitives", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Liquids",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        DisplayDescription = c.String(nullable: false),
                        ColorId = c.Int(),
                        ThirstPoints = c.Int(nullable: false),
                        DrunkPoints = c.Int(nullable: false),
                        CostPerCharge = c.Single(nullable: false),
                        FlammabilityType = c.Int(nullable: false),
                        TagSetId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Primitives", t => t.Id)
                .ForeignKey("dbo.Colors", t => t.ColorId)
                .ForeignKey("dbo.TagSets", t => t.TagSetId)
                .Index(t => t.Id)
                .Index(t => t.ColorId)
                .Index(t => t.TagSetId);
            
            CreateTable(
                "dbo.Mobiles",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        DisplayDescription = c.String(nullable: false),
                        SizeType = c.Int(nullable: false),
                        MobileType = c.Int(nullable: false),
                        Bits = c.Int(nullable: false),
                        RaceId = c.Int(),
                        ConversationId = c.Int(),
                        AccessLevel = c.Int(nullable: false),
                        GenderType = c.Int(nullable: false),
                        Level = c.Int(nullable: false),
                        FactionId = c.Int(),
                        TagSetId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Primitives", t => t.Id)
                .ForeignKey("dbo.Races", t => t.RaceId)
                .ForeignKey("dbo.Conversations", t => t.ConversationId)
                .ForeignKey("dbo.Factions", t => t.FactionId)
                .ForeignKey("dbo.TagSets", t => t.TagSetId)
                .Index(t => t.Id)
                .Index(t => t.RaceId)
                .Index(t => t.ConversationId)
                .Index(t => t.FactionId)
                .Index(t => t.TagSetId);
            
            CreateTable(
                "dbo.Months",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        NumberDays = c.Int(nullable: false),
                        SeasonType = c.Int(nullable: false),
                        IsShrouding = c.Boolean(nullable: false),
                        SortOrder = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Primitives", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.MudProgs",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Data = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Primitives", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Quests",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        DisplayDescription = c.String(nullable: false),
                        Bits = c.Int(nullable: false),
                        Timer = c.Int(nullable: false),
                        TagSetId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Primitives", t => t.Id)
                .ForeignKey("dbo.TagSets", t => t.TagSetId)
                .Index(t => t.Id)
                .Index(t => t.TagSetId);
            
            CreateTable(
                "dbo.Races",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        DisplayDescription = c.String(nullable: false),
                        Bits = c.Int(nullable: false),
                        SizeType = c.Int(nullable: false),
                        BaseHealth = c.Int(nullable: false),
                        BaseMana = c.Int(nullable: false),
                        BaseStamina = c.Int(nullable: false),
                        Abbreviation = c.String(maxLength: 5),
                        TagSetId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Primitives", t => t.Id)
                .ForeignKey("dbo.TagSets", t => t.TagSetId)
                .Index(t => t.Id)
                .Index(t => t.TagSetId);
            
            CreateTable(
                "dbo.Resets",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        ResetType = c.Int(nullable: false),
                        ResetLocationType = c.Int(nullable: false),
                        SpaceId = c.Int(),
                        Limit = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        ObjectId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Primitives", t => t.Id)
                .ForeignKey("dbo.Spaces", t => t.SpaceId)
                .ForeignKey("dbo.Primitives", t => t.ObjectId)
                .Index(t => t.Id)
                .Index(t => t.SpaceId)
                .Index(t => t.ObjectId);
            
            CreateTable(
                "dbo.Rituals",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        DisplayDescription = c.String(nullable: false),
                        MagicalNodeItemId = c.Int(),
                        CastTime = c.Int(nullable: false),
                        TagSetId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Primitives", t => t.Id)
                .ForeignKey("dbo.Items", t => t.MagicalNodeItemId)
                .ForeignKey("dbo.TagSets", t => t.TagSetId)
                .Index(t => t.Id)
                .Index(t => t.MagicalNodeItemId)
                .Index(t => t.TagSetId);
            
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
                .ForeignKey("dbo.Primitives", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.SkillCategories",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Statistic = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Primitives", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        DisplayDescription = c.String(nullable: false),
                        SkillCategoryId = c.Int(),
                        Statistic = c.Int(nullable: false),
                        MaxValue = c.Int(nullable: false),
                        IsMasterable = c.Boolean(nullable: false),
                        ParentSkillId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Primitives", t => t.Id)
                .ForeignKey("dbo.SkillCategories", t => t.SkillCategoryId)
                .ForeignKey("dbo.Skills", t => t.ParentSkillId)
                .Index(t => t.Id)
                .Index(t => t.SkillCategoryId)
                .Index(t => t.ParentSkillId);
            
            CreateTable(
                "dbo.Socials",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        CharNoArg = c.String(),
                        OthersNoArg = c.String(),
                        CharFound = c.String(),
                        OthersFound = c.String(),
                        VictFound = c.String(),
                        CharAuto = c.String(),
                        OthersAuto = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Primitives", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Spaces",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        DisplayDescription = c.String(nullable: false),
                        Bits = c.Int(nullable: false),
                        TerrainId = c.Int(),
                        AccessLevel = c.Int(nullable: false),
                        TagSetId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Primitives", t => t.Id)
                .ForeignKey("dbo.Terrains", t => t.TerrainId)
                .ForeignKey("dbo.TagSets", t => t.TagSetId)
                .Index(t => t.Id)
                .Index(t => t.TerrainId)
                .Index(t => t.TagSetId);
            
            CreateTable(
                "dbo.Spawns",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        MinQuantity = c.Int(nullable: false),
                        MaxQuantity = c.Int(nullable: false),
                        Chance = c.Int(nullable: false),
                        RespawnPeriod = c.Int(nullable: false),
                        SpawnType = c.Int(nullable: false),
                        TagSetId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Primitives", t => t.Id)
                .ForeignKey("dbo.TagSets", t => t.TagSetId)
                .Index(t => t.Id)
                .Index(t => t.TagSetId);
            
            CreateTable(
                "dbo.Terrains",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        DisplayDescription = c.String(nullable: false),
                        Bits = c.Int(nullable: false),
                        MovementCost = c.Int(nullable: false),
                        SkillId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Primitives", t => t.Id)
                .ForeignKey("dbo.Skills", t => t.SkillId)
                .Index(t => t.Id)
                .Index(t => t.SkillId);
            
            CreateTable(
                "dbo.Treasures",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        SystemDescription = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Primitives", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Zones",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        DisplayDescription = c.String(nullable: false),
                        Bits = c.Int(nullable: false),
                        RecycleTime = c.Int(nullable: false),
                        TagSetId = c.Int(),
                        MaxDynamicZones = c.Int(nullable: false),
                        MinDyanmicZoneFrequencySeconds = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Primitives", t => t.Id)
                .ForeignKey("dbo.TagSets", t => t.TagSetId)
                .Index(t => t.Id)
                .Index(t => t.TagSetId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Zones", "TagSetId", "dbo.TagSets");
            DropForeignKey("dbo.Zones", "Id", "dbo.Primitives");
            DropForeignKey("dbo.Treasures", "Id", "dbo.Primitives");
            DropForeignKey("dbo.Terrains", "SkillId", "dbo.Skills");
            DropForeignKey("dbo.Terrains", "Id", "dbo.Primitives");
            DropForeignKey("dbo.Spawns", "TagSetId", "dbo.TagSets");
            DropForeignKey("dbo.Spawns", "Id", "dbo.Primitives");
            DropForeignKey("dbo.Spaces", "TagSetId", "dbo.TagSets");
            DropForeignKey("dbo.Spaces", "TerrainId", "dbo.Terrains");
            DropForeignKey("dbo.Spaces", "Id", "dbo.Primitives");
            DropForeignKey("dbo.Socials", "Id", "dbo.Primitives");
            DropForeignKey("dbo.Skills", "ParentSkillId", "dbo.Skills");
            DropForeignKey("dbo.Skills", "SkillCategoryId", "dbo.SkillCategories");
            DropForeignKey("dbo.Skills", "Id", "dbo.Primitives");
            DropForeignKey("dbo.SkillCategories", "Id", "dbo.Primitives");
            DropForeignKey("dbo.Shops", "Id", "dbo.Primitives");
            DropForeignKey("dbo.Rituals", "TagSetId", "dbo.TagSets");
            DropForeignKey("dbo.Rituals", "MagicalNodeItemId", "dbo.Items");
            DropForeignKey("dbo.Rituals", "Id", "dbo.Primitives");
            DropForeignKey("dbo.Resets", "ObjectId", "dbo.Primitives");
            DropForeignKey("dbo.Resets", "SpaceId", "dbo.Spaces");
            DropForeignKey("dbo.Resets", "Id", "dbo.Primitives");
            DropForeignKey("dbo.Races", "TagSetId", "dbo.TagSets");
            DropForeignKey("dbo.Races", "Id", "dbo.Primitives");
            DropForeignKey("dbo.Quests", "TagSetId", "dbo.TagSets");
            DropForeignKey("dbo.Quests", "Id", "dbo.Primitives");
            DropForeignKey("dbo.MudProgs", "Id", "dbo.Primitives");
            DropForeignKey("dbo.Months", "Id", "dbo.Primitives");
            DropForeignKey("dbo.Mobiles", "TagSetId", "dbo.TagSets");
            DropForeignKey("dbo.Mobiles", "FactionId", "dbo.Factions");
            DropForeignKey("dbo.Mobiles", "ConversationId", "dbo.Conversations");
            DropForeignKey("dbo.Mobiles", "RaceId", "dbo.Races");
            DropForeignKey("dbo.Mobiles", "Id", "dbo.Primitives");
            DropForeignKey("dbo.Liquids", "TagSetId", "dbo.TagSets");
            DropForeignKey("dbo.Liquids", "ColorId", "dbo.Colors");
            DropForeignKey("dbo.Liquids", "Id", "dbo.Primitives");
            DropForeignKey("dbo.ItemSets", "Id", "dbo.Primitives");
            DropForeignKey("dbo.Items", "ItemSetId", "dbo.ItemSets");
            DropForeignKey("dbo.Items", "TagSetId", "dbo.TagSets");
            DropForeignKey("dbo.Items", "TrapItemId", "dbo.Items");
            DropForeignKey("dbo.Items", "UseAbilityId", "dbo.Abilities");
            DropForeignKey("dbo.Items", "Id", "dbo.Primitives");
            DropForeignKey("dbo.Helps", "Id", "dbo.Primitives");
            DropForeignKey("dbo.GameCommands", "TagSetId", "dbo.TagSets");
            DropForeignKey("dbo.GameCommands", "Id", "dbo.Primitives");
            DropForeignKey("dbo.Factions", "TagSetId", "dbo.TagSets");
            DropForeignKey("dbo.Factions", "Id", "dbo.Primitives");
            DropForeignKey("dbo.Effects", "TagSetId", "dbo.TagSets");
            DropForeignKey("dbo.Effects", "OnResistEffectId", "dbo.Effects");
            DropForeignKey("dbo.Effects", "OnFailEffectId", "dbo.Effects");
            DropForeignKey("dbo.Effects", "Id", "dbo.Primitives");
            DropForeignKey("dbo.Conversations", "TagSetId", "dbo.TagSets");
            DropForeignKey("dbo.Conversations", "RequiredFactionId", "dbo.Factions");
            DropForeignKey("dbo.Conversations", "Id", "dbo.Primitives");
            DropForeignKey("dbo.Behaviors", "TagSetId", "dbo.TagSets");
            DropForeignKey("dbo.Behaviors", "Id", "dbo.Primitives");
            DropForeignKey("dbo.Barriers", "TagSetId", "dbo.TagSets");
            DropForeignKey("dbo.Barriers", "TrapItemId", "dbo.Items");
            DropForeignKey("dbo.Barriers", "LockItemId", "dbo.Items");
            DropForeignKey("dbo.Barriers", "KeyItemId", "dbo.Items");
            DropForeignKey("dbo.Barriers", "Id", "dbo.Primitives");
            DropForeignKey("dbo.Archetypes", "TagSetId", "dbo.TagSets");
            DropForeignKey("dbo.Archetypes", "Id", "dbo.Primitives");
            DropForeignKey("dbo.Abilities", "InterruptionEffectId", "dbo.Effects");
            DropForeignKey("dbo.Abilities", "InterruptionResistSkillId", "dbo.Skills");
            DropForeignKey("dbo.Abilities", "TagSetId", "dbo.TagSets");
            DropForeignKey("dbo.Abilities", "TerrainId", "dbo.Terrains");
            DropForeignKey("dbo.Abilities", "Id", "dbo.Primitives");
            DropForeignKey("dbo.AbilityReagants", "ItemId", "dbo.Items");
            DropForeignKey("dbo.AbilityReagants", "AbilityId", "dbo.Abilities");
            DropForeignKey("dbo.AbilityPrerequisites", "SkillId", "dbo.Skills");
            DropForeignKey("dbo.AbilityPrerequisites", "RaceId", "dbo.Races");
            DropForeignKey("dbo.AbilityPrerequisites", "FactionId", "dbo.Factions");
            DropForeignKey("dbo.AbilityPrerequisites", "AbilityId", "dbo.Abilities");
            DropForeignKey("dbo.GuildAbilities", "AbilityId", "dbo.Abilities");
            DropForeignKey("dbo.AbilityEffects", "EffectId", "dbo.Effects");
            DropForeignKey("dbo.EffectStatMods", "ElementId", "dbo.Elements");
            DropForeignKey("dbo.EffectStatMods", "EffectId", "dbo.Effects");
            DropForeignKey("dbo.EffectStatMods", "AffectedSkillId", "dbo.Skills");
            DropForeignKey("dbo.EffectPrimitives", "PrimitiveId", "dbo.Primitives");
            DropForeignKey("dbo.EffectPrimitives", "EffectId", "dbo.Effects");
            DropForeignKey("dbo.EffectPositions", "EffectId", "dbo.Effects");
            DropForeignKey("dbo.EffectHealthChanges", "EffectId", "dbo.Effects");
            DropForeignKey("dbo.EffectDynamicZones", "ZoneId", "dbo.Zones");
            DropForeignKey("dbo.ZoneSpawns", "ZoneId", "dbo.Zones");
            DropForeignKey("dbo.ZoneSpawns", "SpawnId", "dbo.Spawns");
            DropForeignKey("dbo.ZoneSpaces", "ZoneId", "dbo.Zones");
            DropForeignKey("dbo.ZoneSpaces", "SpaceId", "dbo.Spaces");
            DropForeignKey("dbo.ZoneResets", "ZoneId", "dbo.Zones");
            DropForeignKey("dbo.ZoneResets", "ResetId", "dbo.Resets");
            DropForeignKey("dbo.ZoneDynamics", "ZoneId", "dbo.Zones");
            DropForeignKey("dbo.ZoneDynamics", "MobileId", "dbo.Mobiles");
            DropForeignKey("dbo.MobileVendor", "ShopId", "dbo.Shops");
            DropForeignKey("dbo.MobileVendor", "MobileId", "dbo.Mobiles");
            DropForeignKey("dbo.MobileTreasureTables", "TreasureId", "dbo.Treasures");
            DropForeignKey("dbo.MobileTreasureTables", "MobileId", "dbo.Mobiles");
            DropForeignKey("dbo.MobileTreasures", "MobileId", "dbo.Mobiles");
            DropForeignKey("dbo.MobileStatistics", "SkillId", "dbo.Skills");
            DropForeignKey("dbo.MobileStatistics", "MobileId", "dbo.Mobiles");
            DropForeignKey("dbo.MobileResources", "NodeItemId", "dbo.Items");
            DropForeignKey("dbo.MobileResources", "MobileId", "dbo.Mobiles");
            DropForeignKey("dbo.MobileMudProgs", "MudProgId", "dbo.MudProgs");
            DropForeignKey("dbo.MobileMudProgs", "MobileId", "dbo.Mobiles");
            DropForeignKey("dbo.MobileMudProgs", "EventId", "dbo.Events");
            DropForeignKey("dbo.MobileEquipments", "WornAtId", "dbo.WearLocations");
            DropForeignKey("dbo.MobileEquipments", "MobileId", "dbo.Mobiles");
            DropForeignKey("dbo.MobileEquipments", "ItemId", "dbo.Items");
            DropForeignKey("dbo.ItemWearLocations", "WornAtId", "dbo.WearLocations");
            DropForeignKey("dbo.ItemWearLocations", "ItemId", "dbo.Items");
            DropForeignKey("dbo.ItemWeapons", "SkillId", "dbo.Skills");
            DropForeignKey("dbo.ItemWeapons", "ItemId", "dbo.Items");
            DropForeignKey("dbo.ItemVehicleTerrains", "Item_Id", "dbo.Items");
            DropForeignKey("dbo.ItemVehicleTerrains", "TerrainId", "dbo.Terrains");
            DropForeignKey("dbo.ItemVehicleTerrains", "ItemVehicleId", "dbo.ItemVehicles");
            DropForeignKey("dbo.ItemVehicles", "ItemId", "dbo.Items");
            DropForeignKey("dbo.ItemTreasures", "TreasureId", "dbo.Treasures");
            DropForeignKey("dbo.TreasurePrimitives", "TreasureId", "dbo.Treasures");
            DropForeignKey("dbo.TreasurePrimitives", "PrimitiveId", "dbo.Primitives");
            DropForeignKey("dbo.SpawnPrimitives", "SpawnId", "dbo.Spawns");
            DropForeignKey("dbo.SpawnPrimitives", "PrimitiveId", "dbo.Primitives");
            DropForeignKey("dbo.SpawnLocations", "SpawnId", "dbo.Spawns");
            DropForeignKey("dbo.SpawnLocations", "SpaceId", "dbo.Spaces");
            DropForeignKey("dbo.ShopPrimitives", "ShopId", "dbo.Shops");
            DropForeignKey("dbo.ShopPrimitives", "PrimitiveId", "dbo.Primitives");
            DropForeignKey("dbo.ShopBuyTypes", "ShopId", "dbo.Shops");
            DropForeignKey("dbo.RitualRequirements", "SkillId", "dbo.Skills");
            DropForeignKey("dbo.RitualRequirements", "RitualId", "dbo.Rituals");
            DropForeignKey("dbo.RitualRequirements", "RaceId", "dbo.Races");
            DropForeignKey("dbo.RitualRequirements", "FactionId", "dbo.Factions");
            DropForeignKey("dbo.RitualReagants", "RitualId", "dbo.Rituals");
            DropForeignKey("dbo.RitualReagants", "ReagantItemId", "dbo.Items");
            DropForeignKey("dbo.RitualParticipants", "WearLocationId", "dbo.WearLocations");
            DropForeignKey("dbo.RitualParticipants", "RitualId", "dbo.Rituals");
            DropForeignKey("dbo.RitualParticipants", "FocusItemId", "dbo.Items");
            DropForeignKey("dbo.RitualEffects", "RitualId", "dbo.Rituals");
            DropForeignKey("dbo.RitualEffects", "EffectId", "dbo.Effects");
            DropForeignKey("dbo.QuestRequirements", "Quest_Id", "dbo.Quests");
            DropForeignKey("dbo.QuestRequirements", "SkillId", "dbo.Skills");
            DropForeignKey("dbo.QuestRequirements", "RaceId", "dbo.Races");
            DropForeignKey("dbo.QuestRequirements", "QuestNotCompletedId", "dbo.Quests");
            DropForeignKey("dbo.QuestRequirements", "QuestCompletedId", "dbo.Quests");
            DropForeignKey("dbo.QuestRequirements", "QuestId", "dbo.Quests");
            DropForeignKey("dbo.QuestRequirements", "NotRaceId", "dbo.Races");
            DropForeignKey("dbo.QuestRequirements", "HasItemId", "dbo.Items");
            DropForeignKey("dbo.QuestRequirements", "FactionId", "dbo.Factions");
            DropForeignKey("dbo.QuestProgresses", "QuestId", "dbo.Quests");
            DropForeignKey("dbo.QuestProgresses", "PrimitiveId", "dbo.Primitives");
            DropForeignKey("dbo.QuestActions", "QuestId", "dbo.Quests");
            DropForeignKey("dbo.QuestActions", "MudProgId", "dbo.MudProgs");
            DropForeignKey("dbo.QuestActions", "MobileId", "dbo.Mobiles");
            DropForeignKey("dbo.QuestActions", "GivePrimitiveId", "dbo.Primitives");
            DropForeignKey("dbo.QuestActions", "DeletePrimitiveId", "dbo.Primitives");
            DropForeignKey("dbo.MonthEffects", "MonthId", "dbo.Months");
            DropForeignKey("dbo.MonthEffects", "EffectId", "dbo.Effects");
            DropForeignKey("dbo.GameCommandUserStates", "GameCommandId", "dbo.GameCommands");
            DropForeignKey("dbo.GameCommandPositions", "GameCommandId", "dbo.GameCommands");
            DropForeignKey("dbo.Primitives", "SystemClassId", "dbo.SystemClasses");
            DropForeignKey("dbo.ItemTreasures", "ItemId", "dbo.Items");
            DropForeignKey("dbo.ItemTraps", "OnFailEffectId", "dbo.Effects");
            DropForeignKey("dbo.ItemTraps", "ItemId", "dbo.Items");
            DropForeignKey("dbo.ItemTraps", "DisarmSkillId", "dbo.Skills");
            DropForeignKey("dbo.ItemTools", "ItemId", "dbo.Items");
            DropForeignKey("dbo.ItemStatistics", "SkillId", "dbo.Skills");
            DropForeignKey("dbo.ItemStatistics", "ItemId", "dbo.Items");
            DropForeignKey("dbo.ItemResourceNodes", "Item_Id", "dbo.Items");
            DropForeignKey("dbo.ItemResourceNodes", "SkillId", "dbo.Skills");
            DropForeignKey("dbo.ItemResourceNodes", "ResourceItemId", "dbo.Items");
            DropForeignKey("dbo.ItemResourceNodes", "ItemId", "dbo.Items");
            DropForeignKey("dbo.ItemPrerequisites", "SkillId", "dbo.Skills");
            DropForeignKey("dbo.ItemPrerequisites", "RaceId", "dbo.Races");
            DropForeignKey("dbo.RaceStatistics", "SkillId", "dbo.Skills");
            DropForeignKey("dbo.RaceStatistics", "RaceId", "dbo.Races");
            DropForeignKey("dbo.RaceHitLocations", "RaceId", "dbo.Races");
            DropForeignKey("dbo.RaceHitLocations", "HitLocationId", "dbo.WearLocations");
            DropForeignKey("dbo.RaceAbilities", "RaceId", "dbo.Races");
            DropForeignKey("dbo.RaceAbilities", "AbilityId", "dbo.Abilities");
            DropForeignKey("dbo.ItemPrerequisites", "ItemId", "dbo.Items");
            DropForeignKey("dbo.ItemPrerequisites", "FactionId", "dbo.Factions");
            DropForeignKey("dbo.ItemPrerequisites", "ArchetypeId", "dbo.Archetypes");
            DropForeignKey("dbo.ArchetypeStatistics", "SkillId", "dbo.Skills");
            DropForeignKey("dbo.ArchetypeStatistics", "ArchetypeId", "dbo.Archetypes");
            DropForeignKey("dbo.ArchetypeSkillCategories", "SkillCategoryId", "dbo.SkillCategories");
            DropForeignKey("dbo.ArchetypeSkillCategories", "ArchetypeId", "dbo.Archetypes");
            DropForeignKey("dbo.ArchetypeAbilities", "ArchetypeId", "dbo.Archetypes");
            DropForeignKey("dbo.ArchetypeAbilities", "AbilityId", "dbo.Abilities");
            DropForeignKey("dbo.ItemPotions", "ItemId", "dbo.Items");
            DropForeignKey("dbo.ItemPotions", "ColorId", "dbo.Colors");
            DropForeignKey("dbo.ItemPotions", "AbilityId", "dbo.Abilities");
            DropForeignKey("dbo.ItemPortals", "ItemId", "dbo.Items");
            DropForeignKey("dbo.ItemPortals", "DestinationId", "dbo.Spaces");
            DropForeignKey("dbo.TerrainRestrictions", "TerrainId", "dbo.Terrains");
            DropForeignKey("dbo.TerrainRestrictions", "MoementMode_Id", "dbo.MovementModes");
            DropForeignKey("dbo.SpacePortals", "TargetSpaceId", "dbo.Spaces");
            DropForeignKey("dbo.SpacePortals", "BarrierId", "dbo.Barriers");
            DropForeignKey("dbo.ItemMudProgs", "MudProgId", "dbo.MudProgs");
            DropForeignKey("dbo.ItemMudProgs", "ItemId", "dbo.Items");
            DropForeignKey("dbo.ItemMudProgs", "EventId", "dbo.Events");
            DropForeignKey("dbo.ItemMagicalNodes", "ItemId", "dbo.Items");
            DropForeignKey("dbo.ItemMagicalNodes", "EffectId", "dbo.Effects");
            DropForeignKey("dbo.ItemMachines", "ItemId", "dbo.Items");
            DropForeignKey("dbo.ItemLocks", "Item_Id", "dbo.Items");
            DropForeignKey("dbo.ItemLocks", "PickSkillId", "dbo.Skills");
            DropForeignKey("dbo.ItemLocks", "KeyItemId", "dbo.Items");
            DropForeignKey("dbo.ItemLocks", "ItemId", "dbo.Items");
            DropForeignKey("dbo.ItemLights", "Item_Id", "dbo.Items");
            DropForeignKey("dbo.ItemLights", "ItemId", "dbo.Items");
            DropForeignKey("dbo.ItemLights", "FuelItemId", "dbo.Items");
            DropForeignKey("dbo.ItemSetItems", "ItemSet_Id", "dbo.ItemSets");
            DropForeignKey("dbo.ItemSetItems", "ItemSetId", "dbo.ItemSets");
            DropForeignKey("dbo.ItemSetItems", "ItemId", "dbo.Items");
            DropForeignKey("dbo.ItemSetBonuses", "SkillId", "dbo.Skills");
            DropForeignKey("dbo.ItemSetBonuses", "ItemSetId", "dbo.ItemSets");
            DropForeignKey("dbo.ItemFurnitures", "ItemId", "dbo.Items");
            DropForeignKey("dbo.ItemFormulas", "ToolItemId", "dbo.Items");
            DropForeignKey("dbo.ItemFormulas", "SkillId", "dbo.Skills");
            DropForeignKey("dbo.ItemFormulas", "ProductItemId", "dbo.Items");
            DropForeignKey("dbo.ItemFormulas", "MachineItemId", "dbo.Items");
            DropForeignKey("dbo.ItemFormulas", "ItemId", "dbo.Items");
            DropForeignKey("dbo.ItemFormulaResources", "Item_Id", "dbo.Items");
            DropForeignKey("dbo.ItemFormulaResources", "ResourceItemId", "dbo.Items");
            DropForeignKey("dbo.ItemFormulaResources", "ItemId", "dbo.Items");
            DropForeignKey("dbo.ItemFoods", "ItemId", "dbo.Items");
            DropForeignKey("dbo.ItemDrinkContainers", "LiquidId", "dbo.Liquids");
            DropForeignKey("dbo.ItemDrinkContainers", "ItemId", "dbo.Items");
            DropForeignKey("dbo.ItemContainers", "Item_Id", "dbo.Items");
            DropForeignKey("dbo.ItemContainers", "LockItemId", "dbo.Items");
            DropForeignKey("dbo.ItemContainers", "ItemId", "dbo.Items");
            DropForeignKey("dbo.ItemBooks", "ItemId", "dbo.Items");
            DropForeignKey("dbo.ItemBooks", "AbilityId", "dbo.Abilities");
            DropForeignKey("dbo.FactionRelations", "Faction_Id", "dbo.Factions");
            DropForeignKey("dbo.FactionRelations", "TargetFactionId", "dbo.Factions");
            DropForeignKey("dbo.FactionRelations", "FactionId", "dbo.Factions");
            DropForeignKey("dbo.MobileAIs", "MobileId", "dbo.Mobiles");
            DropForeignKey("dbo.MobileAIs", "BehaviorId", "dbo.Behaviors");
            DropForeignKey("dbo.Tags", "TagSet_Id", "dbo.TagSets");
            DropForeignKey("dbo.SystemClasses", "ParentClassId", "dbo.SystemClasses");
            DropForeignKey("dbo.MobileAbilities", "MobileId", "dbo.Mobiles");
            DropForeignKey("dbo.MobileAbilities", "AbilityId", "dbo.Abilities");
            DropForeignKey("dbo.ZoneDynamics", "AbilityId", "dbo.Abilities");
            DropForeignKey("dbo.ZoneAccesses", "ZoneId", "dbo.Zones");
            DropForeignKey("dbo.EffectDynamicZones", "EffectId", "dbo.Effects");
            DropForeignKey("dbo.AbilityEffects", "AbilityId", "dbo.Abilities");
            DropIndex("dbo.Zones", new[] { "TagSetId" });
            DropIndex("dbo.Zones", new[] { "Id" });
            DropIndex("dbo.Treasures", new[] { "Id" });
            DropIndex("dbo.Terrains", new[] { "SkillId" });
            DropIndex("dbo.Terrains", new[] { "Id" });
            DropIndex("dbo.Spawns", new[] { "TagSetId" });
            DropIndex("dbo.Spawns", new[] { "Id" });
            DropIndex("dbo.Spaces", new[] { "TagSetId" });
            DropIndex("dbo.Spaces", new[] { "TerrainId" });
            DropIndex("dbo.Spaces", new[] { "Id" });
            DropIndex("dbo.Socials", new[] { "Id" });
            DropIndex("dbo.Skills", new[] { "ParentSkillId" });
            DropIndex("dbo.Skills", new[] { "SkillCategoryId" });
            DropIndex("dbo.Skills", new[] { "Id" });
            DropIndex("dbo.SkillCategories", new[] { "Id" });
            DropIndex("dbo.Shops", new[] { "Id" });
            DropIndex("dbo.Rituals", new[] { "TagSetId" });
            DropIndex("dbo.Rituals", new[] { "MagicalNodeItemId" });
            DropIndex("dbo.Rituals", new[] { "Id" });
            DropIndex("dbo.Resets", new[] { "ObjectId" });
            DropIndex("dbo.Resets", new[] { "SpaceId" });
            DropIndex("dbo.Resets", new[] { "Id" });
            DropIndex("dbo.Races", new[] { "TagSetId" });
            DropIndex("dbo.Races", new[] { "Id" });
            DropIndex("dbo.Quests", new[] { "TagSetId" });
            DropIndex("dbo.Quests", new[] { "Id" });
            DropIndex("dbo.MudProgs", new[] { "Id" });
            DropIndex("dbo.Months", new[] { "Id" });
            DropIndex("dbo.Mobiles", new[] { "TagSetId" });
            DropIndex("dbo.Mobiles", new[] { "FactionId" });
            DropIndex("dbo.Mobiles", new[] { "ConversationId" });
            DropIndex("dbo.Mobiles", new[] { "RaceId" });
            DropIndex("dbo.Mobiles", new[] { "Id" });
            DropIndex("dbo.Liquids", new[] { "TagSetId" });
            DropIndex("dbo.Liquids", new[] { "ColorId" });
            DropIndex("dbo.Liquids", new[] { "Id" });
            DropIndex("dbo.ItemSets", new[] { "Id" });
            DropIndex("dbo.Items", new[] { "ItemSetId" });
            DropIndex("dbo.Items", new[] { "TagSetId" });
            DropIndex("dbo.Items", new[] { "TrapItemId" });
            DropIndex("dbo.Items", new[] { "UseAbilityId" });
            DropIndex("dbo.Items", new[] { "Id" });
            DropIndex("dbo.Helps", new[] { "Id" });
            DropIndex("dbo.GameCommands", new[] { "TagSetId" });
            DropIndex("dbo.GameCommands", new[] { "Id" });
            DropIndex("dbo.Factions", new[] { "TagSetId" });
            DropIndex("dbo.Factions", new[] { "Id" });
            DropIndex("dbo.Effects", new[] { "TagSetId" });
            DropIndex("dbo.Effects", new[] { "OnResistEffectId" });
            DropIndex("dbo.Effects", new[] { "OnFailEffectId" });
            DropIndex("dbo.Effects", new[] { "Id" });
            DropIndex("dbo.Conversations", new[] { "TagSetId" });
            DropIndex("dbo.Conversations", new[] { "RequiredFactionId" });
            DropIndex("dbo.Conversations", new[] { "Id" });
            DropIndex("dbo.Behaviors", new[] { "TagSetId" });
            DropIndex("dbo.Behaviors", new[] { "Id" });
            DropIndex("dbo.Barriers", new[] { "TagSetId" });
            DropIndex("dbo.Barriers", new[] { "TrapItemId" });
            DropIndex("dbo.Barriers", new[] { "LockItemId" });
            DropIndex("dbo.Barriers", new[] { "KeyItemId" });
            DropIndex("dbo.Barriers", new[] { "Id" });
            DropIndex("dbo.Archetypes", new[] { "TagSetId" });
            DropIndex("dbo.Archetypes", new[] { "Id" });
            DropIndex("dbo.Abilities", new[] { "InterruptionEffectId" });
            DropIndex("dbo.Abilities", new[] { "InterruptionResistSkillId" });
            DropIndex("dbo.Abilities", new[] { "TagSetId" });
            DropIndex("dbo.Abilities", new[] { "TerrainId" });
            DropIndex("dbo.Abilities", new[] { "Id" });
            DropIndex("dbo.AbilityReagants", new[] { "AbilityId" });
            DropIndex("dbo.AbilityReagants", new[] { "ItemId" });
            DropIndex("dbo.AbilityPrerequisites", new[] { "AbilityId" });
            DropIndex("dbo.AbilityPrerequisites", new[] { "SkillId" });
            DropIndex("dbo.AbilityPrerequisites", new[] { "FactionId" });
            DropIndex("dbo.AbilityPrerequisites", new[] { "RaceId" });
            DropIndex("dbo.GuildAbilities", new[] { "AbilityId" });
            DropIndex("dbo.EffectStatMods", new[] { "EffectId" });
            DropIndex("dbo.EffectStatMods", new[] { "ElementId" });
            DropIndex("dbo.EffectStatMods", new[] { "AffectedSkillId" });
            DropIndex("dbo.EffectPrimitives", new[] { "EffectId" });
            DropIndex("dbo.EffectPrimitives", new[] { "PrimitiveId" });
            DropIndex("dbo.EffectPositions", new[] { "EffectId" });
            DropIndex("dbo.EffectHealthChanges", new[] { "EffectId" });
            DropIndex("dbo.ZoneSpawns", new[] { "ZoneId" });
            DropIndex("dbo.ZoneSpawns", new[] { "SpawnId" });
            DropIndex("dbo.ZoneSpaces", new[] { "ZoneId" });
            DropIndex("dbo.ZoneSpaces", new[] { "SpaceId" });
            DropIndex("dbo.ZoneResets", new[] { "ZoneId" });
            DropIndex("dbo.ZoneResets", new[] { "ResetId" });
            DropIndex("dbo.MobileVendor", new[] { "MobileId" });
            DropIndex("dbo.MobileVendor", new[] { "ShopId" });
            DropIndex("dbo.MobileTreasureTables", new[] { "MobileId" });
            DropIndex("dbo.MobileTreasureTables", new[] { "TreasureId" });
            DropIndex("dbo.MobileTreasures", new[] { "MobileId" });
            DropIndex("dbo.MobileStatistics", new[] { "MobileId" });
            DropIndex("dbo.MobileStatistics", new[] { "SkillId" });
            DropIndex("dbo.MobileResources", new[] { "MobileId" });
            DropIndex("dbo.MobileResources", new[] { "NodeItemId" });
            DropIndex("dbo.MobileMudProgs", new[] { "MobileId" });
            DropIndex("dbo.MobileMudProgs", new[] { "MudProgId" });
            DropIndex("dbo.MobileMudProgs", new[] { "EventId" });
            DropIndex("dbo.ItemWearLocations", new[] { "WornAtId" });
            DropIndex("dbo.ItemWearLocations", new[] { "ItemId" });
            DropIndex("dbo.ItemWeapons", new[] { "SkillId" });
            DropIndex("dbo.ItemWeapons", new[] { "ItemId" });
            DropIndex("dbo.ItemVehicleTerrains", new[] { "Item_Id" });
            DropIndex("dbo.ItemVehicleTerrains", new[] { "TerrainId" });
            DropIndex("dbo.ItemVehicleTerrains", new[] { "ItemVehicleId" });
            DropIndex("dbo.ItemVehicles", new[] { "ItemId" });
            DropIndex("dbo.SpawnPrimitives", new[] { "SpawnId" });
            DropIndex("dbo.SpawnPrimitives", new[] { "PrimitiveId" });
            DropIndex("dbo.SpawnLocations", new[] { "SpawnId" });
            DropIndex("dbo.SpawnLocations", new[] { "SpaceId" });
            DropIndex("dbo.ShopPrimitives", new[] { "ShopId" });
            DropIndex("dbo.ShopPrimitives", new[] { "PrimitiveId" });
            DropIndex("dbo.ShopBuyTypes", new[] { "ShopId" });
            DropIndex("dbo.RitualRequirements", new[] { "RitualId" });
            DropIndex("dbo.RitualRequirements", new[] { "SkillId" });
            DropIndex("dbo.RitualRequirements", new[] { "FactionId" });
            DropIndex("dbo.RitualRequirements", new[] { "RaceId" });
            DropIndex("dbo.RitualReagants", new[] { "RitualId" });
            DropIndex("dbo.RitualReagants", new[] { "ReagantItemId" });
            DropIndex("dbo.RitualParticipants", new[] { "RitualId" });
            DropIndex("dbo.RitualParticipants", new[] { "WearLocationId" });
            DropIndex("dbo.RitualParticipants", new[] { "FocusItemId" });
            DropIndex("dbo.RitualEffects", new[] { "RitualId" });
            DropIndex("dbo.RitualEffects", new[] { "EffectId" });
            DropIndex("dbo.QuestRequirements", new[] { "Quest_Id" });
            DropIndex("dbo.QuestRequirements", new[] { "QuestId" });
            DropIndex("dbo.QuestRequirements", new[] { "FactionId" });
            DropIndex("dbo.QuestRequirements", new[] { "HasItemId" });
            DropIndex("dbo.QuestRequirements", new[] { "QuestNotCompletedId" });
            DropIndex("dbo.QuestRequirements", new[] { "QuestCompletedId" });
            DropIndex("dbo.QuestRequirements", new[] { "SkillId" });
            DropIndex("dbo.QuestRequirements", new[] { "NotRaceId" });
            DropIndex("dbo.QuestRequirements", new[] { "RaceId" });
            DropIndex("dbo.QuestProgresses", new[] { "QuestId" });
            DropIndex("dbo.QuestProgresses", new[] { "PrimitiveId" });
            DropIndex("dbo.QuestActions", new[] { "QuestId" });
            DropIndex("dbo.QuestActions", new[] { "MudProgId" });
            DropIndex("dbo.QuestActions", new[] { "DeletePrimitiveId" });
            DropIndex("dbo.QuestActions", new[] { "GivePrimitiveId" });
            DropIndex("dbo.QuestActions", new[] { "MobileId" });
            DropIndex("dbo.MonthEffects", new[] { "MonthId" });
            DropIndex("dbo.MonthEffects", new[] { "EffectId" });
            DropIndex("dbo.GameCommandUserStates", new[] { "GameCommandId" });
            DropIndex("dbo.GameCommandPositions", new[] { "GameCommandId" });
            DropIndex("dbo.TreasurePrimitives", new[] { "TreasureId" });
            DropIndex("dbo.TreasurePrimitives", new[] { "PrimitiveId" });
            DropIndex("dbo.ItemTreasures", new[] { "TreasureId" });
            DropIndex("dbo.ItemTreasures", new[] { "ItemId" });
            DropIndex("dbo.ItemTraps", new[] { "OnFailEffectId" });
            DropIndex("dbo.ItemTraps", new[] { "DisarmSkillId" });
            DropIndex("dbo.ItemTraps", new[] { "ItemId" });
            DropIndex("dbo.ItemTools", new[] { "ItemId" });
            DropIndex("dbo.ItemStatistics", new[] { "SkillId" });
            DropIndex("dbo.ItemStatistics", new[] { "ItemId" });
            DropIndex("dbo.ItemResourceNodes", new[] { "Item_Id" });
            DropIndex("dbo.ItemResourceNodes", new[] { "SkillId" });
            DropIndex("dbo.ItemResourceNodes", new[] { "ResourceItemId" });
            DropIndex("dbo.ItemResourceNodes", new[] { "ItemId" });
            DropIndex("dbo.RaceStatistics", new[] { "RaceId" });
            DropIndex("dbo.RaceStatistics", new[] { "SkillId" });
            DropIndex("dbo.RaceHitLocations", new[] { "RaceId" });
            DropIndex("dbo.RaceHitLocations", new[] { "HitLocationId" });
            DropIndex("dbo.RaceAbilities", new[] { "RaceId" });
            DropIndex("dbo.RaceAbilities", new[] { "AbilityId" });
            DropIndex("dbo.ArchetypeStatistics", new[] { "ArchetypeId" });
            DropIndex("dbo.ArchetypeStatistics", new[] { "SkillId" });
            DropIndex("dbo.ArchetypeSkillCategories", new[] { "ArchetypeId" });
            DropIndex("dbo.ArchetypeSkillCategories", new[] { "SkillCategoryId" });
            DropIndex("dbo.ArchetypeAbilities", new[] { "ArchetypeId" });
            DropIndex("dbo.ArchetypeAbilities", new[] { "AbilityId" });
            DropIndex("dbo.ItemPrerequisites", new[] { "ArchetypeId" });
            DropIndex("dbo.ItemPrerequisites", new[] { "SkillId" });
            DropIndex("dbo.ItemPrerequisites", new[] { "FactionId" });
            DropIndex("dbo.ItemPrerequisites", new[] { "RaceId" });
            DropIndex("dbo.ItemPrerequisites", new[] { "ItemId" });
            DropIndex("dbo.ItemPotions", new[] { "ColorId" });
            DropIndex("dbo.ItemPotions", new[] { "AbilityId" });
            DropIndex("dbo.ItemPotions", new[] { "ItemId" });
            DropIndex("dbo.TerrainRestrictions", new[] { "MoementMode_Id" });
            DropIndex("dbo.TerrainRestrictions", new[] { "TerrainId" });
            DropIndex("dbo.SpacePortals", new[] { "BarrierId" });
            DropIndex("dbo.SpacePortals", new[] { "TargetSpaceId" });
            DropIndex("dbo.ItemPortals", new[] { "DestinationId" });
            DropIndex("dbo.ItemPortals", new[] { "ItemId" });
            DropIndex("dbo.ItemMudProgs", new[] { "MudProgId" });
            DropIndex("dbo.ItemMudProgs", new[] { "EventId" });
            DropIndex("dbo.ItemMudProgs", new[] { "ItemId" });
            DropIndex("dbo.ItemMagicalNodes", new[] { "EffectId" });
            DropIndex("dbo.ItemMagicalNodes", new[] { "ItemId" });
            DropIndex("dbo.ItemMachines", new[] { "ItemId" });
            DropIndex("dbo.ItemLocks", new[] { "Item_Id" });
            DropIndex("dbo.ItemLocks", new[] { "KeyItemId" });
            DropIndex("dbo.ItemLocks", new[] { "PickSkillId" });
            DropIndex("dbo.ItemLocks", new[] { "ItemId" });
            DropIndex("dbo.ItemLights", new[] { "Item_Id" });
            DropIndex("dbo.ItemLights", new[] { "FuelItemId" });
            DropIndex("dbo.ItemLights", new[] { "ItemId" });
            DropIndex("dbo.ItemSetItems", new[] { "ItemSet_Id" });
            DropIndex("dbo.ItemSetItems", new[] { "ItemId" });
            DropIndex("dbo.ItemSetItems", new[] { "ItemSetId" });
            DropIndex("dbo.ItemSetBonuses", new[] { "SkillId" });
            DropIndex("dbo.ItemSetBonuses", new[] { "ItemSetId" });
            DropIndex("dbo.ItemFurnitures", new[] { "ItemId" });
            DropIndex("dbo.ItemFormulas", new[] { "ToolItemId" });
            DropIndex("dbo.ItemFormulas", new[] { "MachineItemId" });
            DropIndex("dbo.ItemFormulas", new[] { "ProductItemId" });
            DropIndex("dbo.ItemFormulas", new[] { "SkillId" });
            DropIndex("dbo.ItemFormulas", new[] { "ItemId" });
            DropIndex("dbo.ItemFormulaResources", new[] { "Item_Id" });
            DropIndex("dbo.ItemFormulaResources", new[] { "ResourceItemId" });
            DropIndex("dbo.ItemFormulaResources", new[] { "ItemId" });
            DropIndex("dbo.ItemFoods", new[] { "ItemId" });
            DropIndex("dbo.ItemDrinkContainers", new[] { "LiquidId" });
            DropIndex("dbo.ItemDrinkContainers", new[] { "ItemId" });
            DropIndex("dbo.ItemContainers", new[] { "Item_Id" });
            DropIndex("dbo.ItemContainers", new[] { "LockItemId" });
            DropIndex("dbo.ItemContainers", new[] { "ItemId" });
            DropIndex("dbo.ItemBooks", new[] { "AbilityId" });
            DropIndex("dbo.ItemBooks", new[] { "ItemId" });
            DropIndex("dbo.MobileEquipments", new[] { "MobileId" });
            DropIndex("dbo.MobileEquipments", new[] { "WornAtId" });
            DropIndex("dbo.MobileEquipments", new[] { "ItemId" });
            DropIndex("dbo.FactionRelations", new[] { "Faction_Id" });
            DropIndex("dbo.FactionRelations", new[] { "FactionId" });
            DropIndex("dbo.FactionRelations", new[] { "TargetFactionId" });
            DropIndex("dbo.Tags", new[] { "TagSet_Id" });
            DropIndex("dbo.SystemClasses", new[] { "ParentClassId" });
            DropIndex("dbo.MobileAIs", new[] { "MobileId" });
            DropIndex("dbo.MobileAIs", new[] { "BehaviorId" });
            DropIndex("dbo.MobileAbilities", new[] { "MobileId" });
            DropIndex("dbo.MobileAbilities", new[] { "AbilityId" });
            DropIndex("dbo.ZoneDynamics", new[] { "ZoneId" });
            DropIndex("dbo.ZoneDynamics", new[] { "MobileId" });
            DropIndex("dbo.ZoneDynamics", new[] { "AbilityId" });
            DropIndex("dbo.ZoneAccesses", new[] { "ZoneId" });
            DropIndex("dbo.EffectDynamicZones", new[] { "EffectId" });
            DropIndex("dbo.EffectDynamicZones", new[] { "ZoneId" });
            DropIndex("dbo.AbilityEffects", new[] { "AbilityId" });
            DropIndex("dbo.AbilityEffects", new[] { "EffectId" });
            DropIndex("dbo.Primitives", new[] { "SystemClassId" });
            DropTable("dbo.Zones");
            DropTable("dbo.Treasures");
            DropTable("dbo.Terrains");
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
            DropTable("dbo.GameCommands");
            DropTable("dbo.Factions");
            DropTable("dbo.Effects");
            DropTable("dbo.Conversations");
            DropTable("dbo.Behaviors");
            DropTable("dbo.Barriers");
            DropTable("dbo.Archetypes");
            DropTable("dbo.Abilities");
            DropTable("dbo.GuildLevels");
            DropTable("ref.GameConstants");
            DropTable("dbo.Bits");
            DropTable("ref.BankUpgrades");
            DropTable("dbo.AbilityReagants");
            DropTable("dbo.AbilityPrerequisites");
            DropTable("dbo.GuildAbilities");
            DropTable("dbo.Elements");
            DropTable("dbo.EffectStatMods");
            DropTable("dbo.EffectPrimitives");
            DropTable("dbo.EffectPositions");
            DropTable("dbo.EffectHealthChanges");
            DropTable("dbo.ZoneSpawns");
            DropTable("dbo.ZoneSpaces");
            DropTable("dbo.ZoneResets");
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
            DropTable("dbo.SpawnPrimitives");
            DropTable("dbo.SpawnLocations");
            DropTable("dbo.ShopPrimitives");
            DropTable("dbo.ShopBuyTypes");
            DropTable("dbo.RitualRequirements");
            DropTable("dbo.RitualReagants");
            DropTable("dbo.RitualParticipants");
            DropTable("dbo.RitualEffects");
            DropTable("dbo.QuestRequirements");
            DropTable("dbo.QuestProgresses");
            DropTable("dbo.QuestActions");
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
            DropTable("dbo.WearLocations");
            DropTable("dbo.RaceHitLocations");
            DropTable("dbo.RaceAbilities");
            DropTable("dbo.ArchetypeStatistics");
            DropTable("dbo.ArchetypeSkillCategories");
            DropTable("dbo.ArchetypeAbilities");
            DropTable("dbo.ItemPrerequisites");
            DropTable("dbo.ItemPotions");
            DropTable("dbo.MovementModes");
            DropTable("dbo.TerrainRestrictions");
            DropTable("dbo.SpacePortals");
            DropTable("dbo.ItemPortals");
            DropTable("dbo.Events");
            DropTable("dbo.ItemMudProgs");
            DropTable("dbo.ItemMagicalNodes");
            DropTable("dbo.ItemMachines");
            DropTable("dbo.ItemLocks");
            DropTable("dbo.ItemLights");
            DropTable("dbo.ItemSetItems");
            DropTable("dbo.ItemSetBonuses");
            DropTable("dbo.ItemFurnitures");
            DropTable("dbo.ItemFormulas");
            DropTable("dbo.ItemFormulaResources");
            DropTable("dbo.ItemFoods");
            DropTable("dbo.Colors");
            DropTable("dbo.ItemDrinkContainers");
            DropTable("dbo.ItemContainers");
            DropTable("dbo.ItemBooks");
            DropTable("dbo.MobileEquipments");
            DropTable("dbo.FactionRelations");
            DropTable("dbo.Tags");
            DropTable("dbo.TagSets");
            DropTable("dbo.SystemClasses");
            DropTable("dbo.MobileAIs");
            DropTable("dbo.MobileAbilities");
            DropTable("dbo.ZoneDynamics");
            DropTable("dbo.ZoneAccesses");
            DropTable("dbo.EffectDynamicZones");
            DropTable("dbo.AbilityEffects");
            DropTable("dbo.Primitives");
        }
    }
}
