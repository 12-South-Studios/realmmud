-- TYPES.LUA
-- Imports all Realm types
-- Revised: 2012.09.01
-- Author: Jason Murdick

luanet.load_assembly("Realm");
luanet.load_assembly("Realm.Server");
luanet.load_assembly("Realm.Library.Ai");
luanet.load_assembly("Realm.Library.Core");
luanet.load_assembly("Realm.Library.Objects");

luanet.import_type("Realm.Library.Core.Cell");
luanet.import_type("Realm.Library.Core.ICell");
luanet.import_type("Realm.Library.Ai.IBehavior");
luanet.import_type("Realm.Library.Objects.Entity");
luanet.import_type("Realm.Library.Objects.IEntity");

luanet.import_type("Realm.Server.Entities.GameEntityConcrete");
luanet.import_type("Realm.Server.Entities.GameEntityInstance");
luanet.import_type("Realm.Server.Entities.GameEntityTemplate");
luanet.import_type("Realm.Server.Entities.IGameEntity");

luanet.import_type("Realm.Server.Zones.Space");
luanet.import_type("Realm.Server.Zones.Zone");
luanet.import_type("Realm.Server.Zones.Exit");

luanet.import_type("Realm.Server.Handlers.BitHandler");
luanet.import_type("Realm.Server.Handlers.ContentsHandler");
luanet.import_type("Realm.Server.Handlers.EffectsHandler");
luanet.import_type("Realm.Server.Handlers.FlagHandler");
luanet.import_type("Realm.Server.Handlers.PropertyHandler");
luanet.import_type("Realm.Server.Handlers.TagHandler");

luanet.import_type("Realm.Server.Item.ItemTemplate");

luanet.import_type("Realm.Server.NPC.MobTemplate");
luanet.import_type("Realm.Server.NPC.Templates.ShopTemplate");
luanet.import_type("Realm.Server.NPC.Templates.ShopkeeperMobTemplate");

-- EOF