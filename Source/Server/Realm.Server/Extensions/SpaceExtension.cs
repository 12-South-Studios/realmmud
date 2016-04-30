//using System;
//using System.Linq;
//using System.Text;
//using Realm.Entity.Entities;
//using Realm.Library.Network;
//using Realm.Server.Attributes;
//using Realm.Server.Effects;
//using Realm.Server.Item;
//using Realm.Server.Managers;
//using Realm.Server.NPC;
//using Realm.Server.Players;
//using Realm.Library.Common;
//using Realm.Server.Properties;
//using Realm.Server.Zones;
//using Realm.Library.Network.Mxp;

//
//namespace Realm.Server
//
//{
//    public static class SpaceExtension
//    {
//        /// <summary>
//        /// Calculates the stamina cost to move into the Space, taking the character's
//        /// skill rating for the Space's terrain into account.
//        /// </summary>
//        public static int CalculateStaminaCost(this ISpace space, ICharacter character)
//        {
//            Validation.IsNotNull(space, "space");
//            Validation.IsNotNull(character, "character");

//            var skill = DataManager.Instance.Get("Skills", space.Terrain.Skill) as Skill;
//            var skillRating = 0;
//            if (skill.IsNotNull())
//                skillRating = character.CalculateSkill(skill);
//            var reduction = 1;

//            if (skillRating >= Game.Instance.GetProperty<int>("terrain_skill_lvl_3_rating"))
//                reduction = Game.Instance.GetProperty<int>("terrain_skill_lvl_3_reduction");
//            else if (skillRating >= Game.Instance.GetProperty<int>("terrain_skill_lvl_2_rating"))
//                reduction = Game.Instance.GetProperty<int>("terrain_skill_lvl_2_reduction");
//            else if (skillRating >= Game.Instance.GetProperty<int>("terrain_skill_lvl_1_rating"))
//                reduction = Game.Instance.GetProperty<int>("terrain_skill_lvl_1_reduction");
//            return Convert.ToInt32(Math.Round((float)(space.Terrain.Cost * (reduction / 100))));
//        }

//        public static void DescribeOccupants(this Space space, ICharacter character)
//        {
//            Validation.IsNotNull(space, "space");
//            Validation.IsNotNull(character, "character");

//             var sb = new StringBuilder();
//             sb.AppendFormat("Contents:{0}", Environment.NewLine);

//             foreach (var entity in space.GetEntities().Where(x => x.IsNotNull() && x != character))
//             {
//                 if (entity is ICharacter)
//                 {
//                     var oUser = entity as Character;
//                     if (oUser.IsNull()) continue;

//                     sb.AppendFormat("  ({0}) ", oUser.Position.GetName());
//                     sb.AppendFormat("{0}{1}{2}", MxpResources.MXP_TAG_MOBILE_OPEN.MxpTag(), oUser.Name, 
//                                     MxpResources.MXP_TAG_MOBILE_CLOSE.MxpTag());
//                     if (character.CanSeeExtendedDetails)
//                     {
//                         sb.AppendFormat("{0} (#{1}{2}){3}", MxpResources.MXP_TAG_ID_OPEN.MxpTag(), 
//                                         oUser.ID, oUser.GetFlags(), MxpResources.MXP_TAG_ID_CLOSE.MxpTag());
//                     }
//                     sb.Append(Environment.NewLine);
//                 }
//                 else if (entity is IGameInstance)
//                 {
//                     if (entity is ItemInstance)
//                     {
//                         var instance = entity as ItemInstance;
//                         string beginMxpTag, endMxpTag;

//                         if (instance.IsType("drink container"))
//                         {
//                             beginMxpTag = MxpResources.MXP_TAG_GRNDITEM_DRINKCNT_OPEN.MxpTag(instance.ID, instance.Name);
//                             endMxpTag = MxpResources.MXP_TAG_GRNDITEM_DRINKCNT_CLOSE.MxpTag();
//                         }
//                         else if (instance.IsType("resource node"))
//                         {
//                             beginMxpTag = MxpResources.MXP_TAG_GRNDITEM_RESNODE_OPEN.MxpTag(instance.ID, instance.Name);
//                             endMxpTag = MxpResources.MXP_TAG_GRNDITEM_RESNODE_CLOSE.MxpTag();
//                         }
//                         else
//                         {
//                             beginMxpTag = MxpResources.MXP_TAG_GRNDITEM_OPEN.MxpTag(instance.ID, instance.Name);
//                             endMxpTag = MxpResources.MXP_TAG_GRNDITEM_CLOSE.MxpTag();
//                         }

//                         if (character.CanSeeExtendedDetails)
//                         {
//                             if (instance.StackSize > 1)
//                                 sb.AppendFormat("  (x{0}) ", instance.StackSize);
//                             else
//                                 sb.Append("  ");

//                             sb.Append(MxpResources.MXP_TAG_ITEM_OPEN.MxpTag());
//                             sb.Append(beginMxpTag);
//                             sb.Append(instance.LongName);
//                             sb.Append(endMxpTag);
//                             sb.Append(MxpResources.MXP_TAG_ITEM_CLOSE.MxpTag());
//                             sb.AppendFormat("{0} (#{1}){2}", MxpResources.MXP_TAG_ID_OPEN.MxpTag(), 
//                                             MxpResources.MXP_TAG_WIZITEM_OPEN.MxpTag(instance.ID, instance.Name) + 
//                                             instance.ID + instance.GetFlags() + 
//                                             MxpResources.MXP_TAG_WIZITEM_CLOSE.MxpTag(), MxpResources.MXP_TAG_ID_CLOSE.MxpTag());
//                         }
//                         else
//                         {
//                             if (instance.StackSize > 1)
//                                 sb.AppendFormat(" (x{0}) ", instance.StackSize);
//                             else
//                                 sb.Append("  ");

//                             sb.Append(MxpResources.MXP_TAG_ITEM_OPEN.MxpTag());
//                             sb.Append(beginMxpTag);
//                             sb.Append(instance.LongName);
//                             sb.Append(endMxpTag);
//                             sb.Append(MxpResources.MXP_TAG_ITEM_CLOSE.MxpTag());
//                         }

//                         sb.Append(Environment.NewLine);
//                     }
//                     else if (entity is EffectInstance)
//                     {
//                         var instance = entity as EffectInstance;

//                         sb.Append(MxpResources.MXP_TAG_EFFECT_OPEN.MxpTag());
//                         sb.Append(instance.Name);
//                         sb.Append(MxpResources.MXP_TAG_EFFECT_CLOSE.MxpTag());

//                         if (character.CanSeeExtendedDetails)
//                         {
//                             sb.AppendFormat("{0} (#{1}){2}", MxpResources.MXP_TAG_ID_OPEN.MxpTag(), 
//                                             MxpResources.MXP_TAG_WIZENTITY_OPEN.MxpTag(instance.ID, instance.Name) + 
//                                             instance.ID + instance.GetFlags() + 
//                                             MxpResources.MXP_TAG_WIZENTITY_CLOSE.MxpTag(), 
//                                             MxpResources.MXP_TAG_ID_CLOSE.MxpTag());
//                         }
//                         sb.Append(Environment.NewLine);    
//                     }
//                     else if (entity is MobInstance)
//                     {
//                         var instance = entity as MobInstance;
//                         string beginMxpTag, endMxpTag;
//                         if (instance.Bits.HasBit(Globals.Globals.MobileBits.IsMerchant))
//                         {
//                             beginMxpTag = MxpResources.MXP_TAG_SHOPKEEP_OPEN.MxpTag(instance.ID, instance.Name);
//                             endMxpTag = MxpResources.MXP_TAG_SHOPKEEP_CLOSE.MxpTag();
//                         }
//                         else if (instance.Bits.HasBit(Globals.Globals.MobileBits.IsGuard))
//                         {
//                             beginMxpTag = MxpResources.MXP_TAG_GUARD_OPEN.MxpTag(instance.ID, instance.Name);
//                             endMxpTag = MxpResources.MXP_TAG_GUARD_CLOSE.MxpTag();
//                         }
//                         else if (instance.Bits.HasBit(Globals.Globals.MobileBits.IsTrainer))
//                         {
//                             beginMxpTag = MxpResources.MXP_TAG_TRAINER_OPEN.MxpTag(instance.ID, instance.Name);
//                             endMxpTag = MxpResources.MXP_TAG_TRAINER_CLOSE.MxpTag();
//                         }
//                         else
//                         {
//                             beginMxpTag = MxpResources.MXP_TAG_MOBILE_OPEN.MxpTag(instance.ID, instance.Name);
//                             endMxpTag = MxpResources.MXP_TAG_MOBILE_CLOSE.MxpTag();
//                         }

//                         sb.AppendFormat("  ({0}) ", instance.Position.GetName());
//                         sb.Append(MxpResources.MXP_TAG_MOBILE_OPEN.MxpTag());
//                         sb.Append(beginMxpTag);
//                         sb.Append(instance.LongName);
//                         sb.Append(endMxpTag);
//                         sb.Append(MxpResources.MXP_TAG_MOBILE_CLOSE.MxpTag());

//                         if (character.CanSeeExtendedDetails)
//                         {
//                             sb.AppendFormat("{0} (#{1}){2}", MxpResources.MXP_TAG_ID_OPEN.MxpTag(), 
//                                             MxpResources.MXP_TAG_WIZMOBILE_OPEN.MxpTag(instance.ID, instance.Name) + 
//                                             instance.ID + instance.GetFlags() + 
//                                             MxpResources.MXP_TAG_WIZMOBILE_CLOSE.MxpTag(), MxpResources.MXP_TAG_ID_CLOSE.MxpTag());
//                         }
//                         sb.Append(Environment.NewLine);
//                     }
//                 }
//                 else
//                 {
//                     sb.AppendFormat("   {0}", entity.LongName);
//                     if (character.CanSeeExtendedDetails)
//                         sb.AppendFormat(" (#{0}{1})", entity.ID, entity.GetFlags());
//                     sb.Append(Environment.NewLine);
//                 }
//             }

//            character.SendText(sb.ToString());
//         }

//        public static void DescribePortals(this Space space, ICharacter character)
//         {
//             Validation.IsNotNull(space, "space");
//             Validation.IsNotNull(character, "character");

//             var sb = new StringBuilder();
//             sb.Append(MxpResources.MXP_TAG_RPORTALS_OPEN.MxpTag());
//             sb.Append("Exits: ");
//             sb.Append(Environment.NewLine);

//             foreach (var portal in space.GetPortals().Values.Where(x => x.IsNotNull()))
//             {
//                 var extendedData = new StringBuilder(portal.GenerateExtendedData());
//                 if (extendedData.Length > 0)
//                 {
//                     extendedData.Insert(0, " (");
//                     extendedData.Append(")");
//                 }
//                 sb.AppendFormat("  {0}{1}{2}{3}{4}",
//                                 MxpResources.MXP_TAG_PORTAL_OPEN.MxpTag(portal.Direction.GetName(),
//                                                                         portal.Direction.GetName()),
//                                 portal.Direction.GetName(), MxpResources.MXP_TAG_PORTAL_CLOSE.MxpTag(), extendedData,
//                                 Environment.NewLine);
//             }

//             sb.Append(MxpResources.MXP_TAG_RPORTALS_CLOSE.MxpTag());
//             sb.Append(Environment.NewLine);
//             character.SendText(sb.ToString());
//         }

//        public static string GenerateExtendedData(this Portal portal)
//        {
//            Validation.IsNotNull(portal, "portal");

//            var sb = new StringBuilder();

//            //// ! monster in destination
//            if (portal.Destination.HasMonsters())
//            {
//                sb.Append(MxpResources.MXP_TAG_COLOR_OPEN.MxpTag("red"));
//                sb.Append("!");
//                sb.Append(MxpResources.MXP_TAG_COLOR_CLOSE.MxpTag());
//            }

//            //// * player in destination
//            if (portal.Destination.HasPlayers())
//            {
//                sb.Append(MxpResources.MXP_TAG_COLOR_OPEN.MxpTag("blue"));
//                sb.Append("*");
//                sb.Append(MxpResources.MXP_TAG_COLOR_CLOSE.MxpTag());
//            }

//            //// = destination is safe Space
//            if (portal.Destination.IsSafe())
//            {
//                sb.Append(MxpResources.MXP_TAG_COLOR_OPEN.MxpTag("white"));
//                sb.Append("=");
//                sb.Append(MxpResources.MXP_TAG_COLOR_CLOSE.MxpTag());
//            }

//            //// ~ destination is tavern
//            if (portal.Destination.IsTavern())
//            {
//                sb.Append(MxpResources.MXP_TAG_COLOR_OPEN.MxpTag("white"));
//                sb.Append("~");
//                sb.Append(MxpResources.MXP_TAG_COLOR_CLOSE.MxpTag());
//            }

//            //// & destination is shrine
//            if (portal.Destination.Bits.HasBit(Globals.Globals.SpaceBits.IsShrine))
//            {
//                sb.Append(MxpResources.MXP_TAG_COLOR_OPEN.MxpTag("white"));
//                sb.Append("&");
//                sb.Append(MxpResources.MXP_TAG_COLOR_CLOSE.MxpTag());
//            }

//            //// @ destination has effects
//            if (portal.Destination.HasEffects())
//            {
//                sb.Append(MxpResources.MXP_TAG_COLOR_OPEN.MxpTag("yellow"));
//                sb.Append("@");
//                sb.Append(MxpResources.MXP_TAG_COLOR_CLOSE.MxpTag());
//            }

//            //// ^ destination has a trainer
//            if (portal.Destination.HasTrainer())
//            {
//                sb.Append(MxpResources.MXP_TAG_COLOR_OPEN.MxpTag("orange"));
//                sb.Append("^");
//                sb.Append(MxpResources.MXP_TAG_COLOR_CLOSE.MxpTag());
//            }

//            //// $ destination has a vendor
//            if (portal.Destination.HasVendor())
//            {
//                sb.Append(MxpResources.MXP_TAG_COLOR_OPEN.MxpTag("green"));
//                sb.Append("$");
//                sb.Append(MxpResources.MXP_TAG_COLOR_CLOSE.MxpTag());
//            }

//            //// % destination has a resource node
//            if (portal.Destination.HasResourceNodes())
//            {
//                sb.Append(MxpResources.MXP_TAG_COLOR_OPEN.MxpTag("cyan"));
//                sb.Append("%");
//                sb.Append(MxpResources.MXP_TAG_COLOR_CLOSE.MxpTag());
//            }

//            //// TODO: : + destination Space has quest givers

//            return sb.ToString();
//        }

//        public static bool Contains(this ISpace space, IGameTemplate template)
//        {
//            Validation.IsNotNull(space, "space");
//            Validation.IsNotNull(template, "template");

//            return space.GetEntities().OfType<ItemInstance>().Any(item => item.Parent == template) 
//                   || space.GetEntities().OfType<MobInstance>().Any(item => item.Parent == template);
//        }

//        #region Portal Handler

//        public static Portal GetPortal(this ISpace space, string keyword)
//        {
//            Validation.IsNotNull(space, "space");
//            Validation.IsNotNullOrEmpty(keyword, "keyword");

//            return space.Portals.GetPortal(keyword);
//        }

//        public static Portal GetPortal(this ISpace space, ISpace target)
//        {
//            Validation.IsNotNull(space, "space");
//            Validation.IsNotNull(target, "target");

//            return space.Portals.GetPortal(target);
//        }

//        public static Portal GetPortal(this ISpace space, Globals.Globals.Directions direction)
//        {
//            Validation.IsNotNull(space, "space");

//            return space.Portals.GetPortal(direction);
//        }

//        public static int PortalCount(this ISpace space)
//        {
//            Validation.IsNotNull(space, "space");

//            return space.Portals.Count;
//        }

//        public static PortalRepository GetPortals(this ISpace space)
//        {
//            Validation.IsNotNull(space, "space");

//            return space.Portals.Portals;
//        }
//        #endregion
//    }
//}
