using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Realm.DatabaseEdmx;

namespace Realm.Build.Tool
{
    public class RealmDal
    {
        internal class TypeTable
        {
            public string TableName;
            public string IdColumn;
            public string NameColumn;
            public Delegate Delegate;
        }

        private readonly Dictionary<string, TypeTable> TypeRepository = new Dictionary<string,TypeTable>(); 

        public string ConnectionString { get; private set; }

        public RealmDal(string connection)
        {
            RefContext = new RefContext(connection);
            DboContext = new DboContext(connection);
            ConnectionString = connection;

            // Build the table of types that will be parsed out into the Globals file(s)
            // TODO: BankUpgrade
            TypeRepository.Add("ref.BitType", new TypeTable { TableName = "BitType", IdColumn = "BitTypeID", NameColumn = "Name" });
            TypeRepository.Add("ref.ChannelStatusType", new TypeTable { TableName = "ChannelStatusType", IdColumn = "ChannelStatusTypeID", NameColumn = "Name" });
            TypeRepository.Add("ref.ChannelType", new TypeTable { TableName = "ChannelType", IdColumn = "ChannelTypeID", NameColumn = "Name" });
            TypeRepository.Add("ref.ColorType", new TypeTable 
                                                      { 
                                                          TableName = "ColorType", 
                                                          IdColumn = "ColorTypeID", 
                                                          NameColumn = "Name", 
                                                          Delegate = new Func<IList<ConstantValue>>(GetColorTypes)
                                                      });
            TypeRepository.Add("ref.CombatHitResultType", new TypeTable { TableName = "CombatHitResultType", IdColumn = "CombatHitResultTypeID", NameColumn = "Name" });
            TypeRepository.Add("ref.ConditionType", new TypeTable
                                                        {
                                                            TableName = "ConditionType",
                                                            IdColumn = "ConditionTypeID",
                                                            NameColumn = "Name",
                                                            Delegate = new Func<IList<ConstantValue>>(GetConditionTypes) 
                                                        });
            TypeRepository.Add("ref.DamageType", new TypeTable { TableName = "DamageType", IdColumn = "DamageTypeID", NameColumn = "Name" });
            TypeRepository.Add("ref.DayStateType", new TypeTable
                                                       {
                                                           TableName = "DayStateType",
                                                           IdColumn = "DayStateTypeID",
                                                           NameColumn = "Name",
                                                           Delegate = new Func<IList<ConstantValue>>(GetDayStateTypes) 
                                                       });
            TypeRepository.Add("ref.DifficultyType", new TypeTable { TableName = "DifficultyType", IdColumn = "DifficultyTypeID", NameColumn = "Name" });
            TypeRepository.Add("ref.Direction", new TypeTable { TableName = "Direction", IdColumn = "DirectionID", NameColumn = "Name" });
            TypeRepository.Add("ref.EffectType", new TypeTable { TableName = "EffectType", IdColumn = "EffectTypeID", NameColumn = "Name" });
            TypeRepository.Add("ref.EffectDamageSourceType", new TypeTable { TableName = "EffectDamageSourceType", IdColumn = "EffectDamageSourceTypeID", NameColumn = "Name" });
            TypeRepository.Add("ref.ElementType", new TypeTable
                                                      {
                                                          TableName = "ElementType",
                                                          IdColumn = "ElementTypeID",
                                                          NameColumn = "Name",
                                                          Delegate = new Func<IList<ConstantValue>>(GetElementTypes)
                                                      });
            TypeRepository.Add("ref.EntityLocationType", new TypeTable
                                                             {
                                                                 TableName = "EntityLocationType",
                                                                 IdColumn = "EntityLocationTypeID",
                                                                 NameColumn = "Name",
                                                                 Delegate = new Func<IList<ConstantValue>>(GetEntityLocationTypes) 
                                                             });
            TypeRepository.Add("ref.EventType", new TypeTable
                                                    {
                                                        TableName = "EventType",
                                                        IdColumn = "EventTypeID",
                                                        NameColumn = "Name",
                                                        Delegate = new Func<IList<ConstantValue>>(GetEventTypes)
                                                    });
            TypeRepository.Add("ref.FactionRelationshipType", new TypeTable { TableName = "FactionRelationshipType", IdColumn = "FactionRelationshipTypeID", NameColumn = "Name" });
            TypeRepository.Add("ref.FlagType", new TypeTable
                                                   {
                                                       TableName = "FlagType",
                                                       IdColumn = "FlagTypeID",
                                                       NameColumn = "Name",
                                                       Delegate = new Func<IList<ConstantValue>>(GetFlagTypes)
                                                   });
            TypeRepository.Add("ref.FlammabilityType", new TypeTable { TableName = "FlammabilityType", IdColumn = "FlammabilityTypeID", NameColumn = "Name" });
            TypeRepository.Add("ref.FuelType", new TypeTable { TableName = "FuelType", IdColumn = "FuelTypeID", NameColumn = "Name" });
            TypeRepository.Add("ref.GameConstant", new TypeTable
                                                       {
                                                           TableName = "GameConstant",
                                                           IdColumn = "GameConstantID",
                                                           NameColumn = "Name",
                                                           Delegate = new Func<IList<ConstantValue>>(GetGameConstants)
                                                       });
            TypeRepository.Add("ref.GameConstantCategory", new TypeTable { TableName = "GameConstantCategory", IdColumn = "GameConstantCategoryID", NameColumn = "Name" });
            TypeRepository.Add("ref.GenderType", new TypeTable { TableName = "GenderType", IdColumn = "GenderTypeID", NameColumn = "Name" });
            TypeRepository.Add("ref.GuildActionType", new TypeTable { TableName = "GuildActionType", IdColumn = "GuildActionTypeID", NameColumn = "Name" });
            TypeRepository.Add("ref.GuildRankType", new TypeTable { TableName = "GuildRankType", IdColumn = "GuildRankTypeID", NameColumn = "Name" });
            // TODO: GuildRankActionMap?
            // TODO: GuildxpTable?
            TypeRepository.Add("ref.HealthChangeType", new TypeTable { TableName = "HealthChangeType", IdColumn = "HealthChangeTypeID", NameColumn = "Name" });
            TypeRepository.Add("ref.InstanceType", new TypeTable { TableName = "InstanceType", IdColumn = "InstanceTypeID", NameColumn = "Name" });
            TypeRepository.Add("ref.ItemClassType", new TypeTable
                                                        {
                                                            TableName = "ItemClassType",
                                                            IdColumn = "ItemClassTypeID",
                                                            NameColumn = "Name",
                                                            Delegate = new Func<IList<ConstantValue>>(GetItemClassTypes)
                                                        });
            TypeRepository.Add("ref.ItemType", new TypeTable
                                                   {
                                                       TableName = "ItemType",
                                                       IdColumn = "ItemTypeID",
                                                       NameColumn = "Name",
                                                       Delegate = new Func<IList<ConstantValue>>(GetItemTypes)
                                                   });
            TypeRepository.Add("ref.LogActionType", new TypeTable { TableName = "LogActionType", IdColumn = "LogActionTypeID", NameColumn = "Name" });
            TypeRepository.Add("ref.MachineType", new TypeTable { TableName = "MachineType", IdColumn = "MachineTypeID", NameColumn = "Name" });
            TypeRepository.Add("ref.MaterialType", new TypeTable { TableName = "MaterialType", IdColumn = "MaterialTypeID", NameColumn = "Name" });
            TypeRepository.Add("ref.MerchantStatementType", new TypeTable { TableName = "MerchantStatementType", IdColumn = "MerchantStatementTypeID", NameColumn = "Name" });
            TypeRepository.Add("ref.MessageScopeType", new TypeTable
                                                           {
                                                               TableName = "MessageScopeType",
                                                               IdColumn = "MessageScopeTypeID",
                                                               NameColumn = "Name",
                                                               Delegate = new Func<IList<ConstantValue>>(GetMessageScopeTypes) 
                                                           });
            TypeRepository.Add("ref.MobileType", new TypeTable { TableName = "MobileType", IdColumn = "MobileTypeID", NameColumn = "Name" });
            TypeRepository.Add("ref.MobileNodeType", new TypeTable { TableName = "MobileNodeType", IdColumn = "MobileNodeTypeID", NameColumn = "Name" });
            TypeRepository.Add("ref.MonsterClassType", new TypeTable { TableName = "MonsterClassType", IdColumn = "MonsterClassTypeID", NameColumn = "Name" });
            TypeRepository.Add("ref.MovementModeType", new TypeTable
                                                           {
                                                               TableName = "MovementModeType",
                                                               IdColumn = "MovementModeTypeID",
                                                               NameColumn = "Name",
                                                               Delegate = new Func<IList<ConstantValue>>(GetMovementModeTypes) 
                                                           });
            TypeRepository.Add("ref.PositionType", new TypeTable
                                                       {
                                                           TableName = "PositionType",
                                                           IdColumn = "PositionTypeID",
                                                           NameColumn = "Name",
                                                           Delegate = new Func<IList<ConstantValue>>(GetPositionTypes)
                                                       });
            TypeRepository.Add("ref.QuestProgressType", new TypeTable { TableName="QuestProgressType", IdColumn = "QuestProgressTypeID", NameColumn = "Name" });
            TypeRepository.Add("ref.ResetLocationType", new TypeTable { TableName = "ResetLocationType", IdColumn = "ResetLocationTypeID", NameColumn = "Name" });
            TypeRepository.Add("ref.ResetType", new TypeTable { TableName = "ResetType", IdColumn = "ResetTypeID", NameColumn = "Name" });
            TypeRepository.Add("ref.SeasonType", new TypeTable { TableName = "SeasonType", IdColumn = "SeasonTypeID", NameColumn = "Name" });
            TypeRepository.Add("ref.ShopType", new TypeTable { TableName = "ShopType", IdColumn = "ShopTypeID", NameColumn = "Name" });
            TypeRepository.Add("ref.SizeType", new TypeTable { TableName = "SizeType", IdColumn = "SizeTypeID", NameColumn = "Name" });
            TypeRepository.Add("ref.SkillTestResultType", new TypeTable { TableName = "SkillTestResultType", IdColumn = "SkillTestResultTypeID", NameColumn = "Name" });
            TypeRepository.Add("ref.SpawnType", new TypeTable { TableName = "SpawnType", IdColumn = "SpawnTypeID", NameColumn = "Name" });
            TypeRepository.Add("ref.SpeechType", new TypeTable { TableName = "SpeechType", IdColumn = "SpeechTypeID", NameColumn = "Name" });
            TypeRepository.Add("ref.SpeedClassType", new TypeTable { TableName = "SpeedClassType", IdColumn = "SpeedClassTypeID", NameColumn = "Name" });
            TypeRepository.Add("ref.Statistic", new TypeTable { TableName = "Statistic", IdColumn = "StatisticID", NameColumn = "Name" });
            TypeRepository.Add("ref.StatusEffectType", new TypeTable
                                                           {
                                                               TableName = "StatusEffectType", 
                                                               IdColumn = "StatusEffectTypeID",
                                                               NameColumn = "Name",
                                                               Delegate = new Func<IList<ConstantValue>>(GetStatusEffectTypes) 
                                                           });
            TypeRepository.Add("ref.StringType", new TypeTable { TableName = "StringType", IdColumn = "StringTypeID", NameColumn = "Name" });
            TypeRepository.Add("ref.SystemType", new TypeTable { TableName = "SystemType", IdColumn = "SystemTypeID", NameColumn = "Name" });
            TypeRepository.Add("ref.TagCategoryType", new TypeTable { TableName = "TagCategoryType", IdColumn = "TagCategoryTypeID", NameColumn = "Name" });
            TypeRepository.Add("ref.TargetClassType", new TypeTable { TableName = "TargetClassType", IdColumn = "TargetClassTypeID", NameColumn = "Name" });
            TypeRepository.Add("ref.ToolType", new TypeTable { TableName = "ToolType", IdColumn = "ToolTypeID", NameColumn = "Name" });
            TypeRepository.Add("ref.UserStateType", new TypeTable { TableName = "UserStateType", IdColumn = "UserStateTypeID", NameColumn = "Name" });
            TypeRepository.Add("ref.WearLocation", new TypeTable
                                                       {
                                                           TableName = "WearLocation",
                                                           IdColumn = "WearLocationID",
                                                           NameColumn = "Name",
                                                           Delegate = new Func<IList<ConstantValue>>(GetWearLocations)
                                                       });
        }

        public IRefContext RefContext { get; private set; }
        public IDboContext DboContext { get; private set; }

        public IList<ConstantsTable> Globals
        {
            get
            {
                return RefContext.GetGlobals().Select(global => new ConstantsTable
                                                       {
                                                           TableName = global.TableName,
                                                           ConstantName = global.Name,
                                                           KeyName = global.KeyName,
                                                           ValueName = global.ValueName,
                                                           AdditionalWhere = global.AdditionalWhere ?? string.Empty,
                                                           Prefix = global.Prefix,
                                                           DescriptionField = global.Description ?? string.Empty,
                                                           CommentField = global.CommentField ?? string.Empty,
                                                           Comment = global.Comment ?? string.Empty,
                                                           IsEnum = global.IsEnum.GetValueOrDefault(false),
                                                           HasFlagsAttribute = global.EnumFlagsAttribute.GetValueOrDefault(false),
                                                           SuppressCA1008 = global.EnumSuppressCA1008.GetValueOrDefault(false)
                                                       }).ToList();
            }
        }

        public IList<ConstantValue> GetConstants(String tableName, int filter)
        {
            if (String.IsNullOrEmpty(tableName))
                throw new ArgumentNullException("tableName", "Parameter is null");

            if (tableName.Equals("ref.Bit", StringComparison.OrdinalIgnoreCase))
                return GetBits(filter);

            if (TypeRepository.ContainsKey(tableName))
            {
                var typeTable = TypeRepository[tableName];
                if (typeTable.Delegate != null)
                    return (List<ConstantValue>)typeTable.Delegate.DynamicInvoke(null);
                return GetTypeData(typeTable.TableName, typeTable.IdColumn, typeTable.NameColumn);
            }

            return new List<ConstantValue>();
        }

        public int GetGameConstant(int constantId, int defaultValue)
        {
            if (!DboContext.GetGameConstants().Any()) return defaultValue;

            if (DboContext.GetGameConstants().Count(x => x.RefGameConstantID == constantId) == 0) return defaultValue;
            var obj = DboContext.GetGameConstants().Single(x => x.RefGameConstantID == constantId);
            return obj != null ? obj.IntValue.GetValueOrDefault(defaultValue) : defaultValue;
        }
        public float GetGameConstant(int constantId, float defaultValue)
        {
            if (!DboContext.GetGameConstants().Any()) return defaultValue;

            if (DboContext.GetGameConstants().Count(x => x.RefGameConstantID == constantId) == 0) return defaultValue;
            var obj = DboContext.GetGameConstants().Single(x => x.RefGameConstantID == constantId);
            return obj != null ? (float)obj.FloatValue.GetValueOrDefault(defaultValue) : defaultValue;
        }
        public string GetGameConstant(int constantId, string defaultValue)
        {
            if (!DboContext.GetGameConstants().Any()) return defaultValue;

            if (DboContext.GetGameConstants().Count(x => x.RefGameConstantID == constantId) == 0) return defaultValue;
            var obj = DboContext.GetGameConstants().Single(x => x.RefGameConstantID == constantId);
            var value = obj != null ? obj.StringValue : string.Empty;
            return string.IsNullOrEmpty(value) ? defaultValue : value;
        }
        public bool GetGameConstant(int constantId, bool defaultValue)
        {
            if (!DboContext.GetGameConstants().Any()) return defaultValue;

            if (DboContext.GetGameConstants().Count(x => x.RefGameConstantID == constantId) == 0) return defaultValue;
            var obj = DboContext.GetGameConstants().Single(x => x.RefGameConstantID == constantId);
            return obj != null ? obj.BoolValue.GetValueOrDefault(defaultValue) : defaultValue;
        }

        private IList<ConstantValue> GetTypeData(string tableName, string idColumn, string nameColumn)
        {
            var typeList = RefContext.GetTypeData(tableName, idColumn, nameColumn);
            return typeList.Select(type => new ConstantValue
                                               {
                                                   Name = type.Name,
                                                   Value = Convert.ToInt32(type.ID),
                                                   EnumString = ToEnumString(type.Name, type.ID)
                                               }).ToList();
        }
        private IList<ConstantValue> GetColorTypes()
        {
            var colorList = RefContext.GetColors();
            return colorList.Select(x => new ConstantValue
                                             {
                                                 Name = x.Name,
                                                 Value = x.ColorTypeID,
                                                 EnumString =
                                                     ToEnumString(x.Name, x.ColorTypeID, string.Empty,
                                                                  new[] {x.AsciiString, x.EscapeString})
                                             }).ToList();
        }
        private IList<ConstantValue> GetConditionTypes()
        {
            var conditionList = RefContext.GetConditions();
            return conditionList.Select(x => new ConstantValue
                                                 {
                                                     Name = x.Name,
                                                     Value = x.ConditionTypeID,
                                                     EnumString =
                                                         ToEnumString(x.Name, x.Value, string.Empty,
                                                                      new[] {x.ConditionTypeID})
                                                 }).ToList();
        }
        private IList<ConstantValue> GetDayStateTypes()
        {
            var conditionList = RefContext.GetDayStates();
            return conditionList.Select(x => new ConstantValue
            {
                Name = x.Name,
                Value = x.DayStateTypeID,
                EnumString =
                    ToEnumString(x.Name, x.Value, string.Empty,
                                 new[] { x.DayStateTypeID })
            }).ToList();
        }
        private IList<ConstantValue> GetElementTypes()
        {
            var elementList = RefContext.GetElements();
            return elementList.Select(x => new ConstantValue
                                               {
                                                   Name = x.Name,
                                                   Value = x.ElementTypeID,
                                                   EnumString = ToEnumString(x.Name, x.ElementTypeID, string.Empty,
                                                                             new[]
                                                                                 {
                                                                                     x.OppositeElementID, x.LeftElementID,
                                                                                     x.RightElementID
                                                                                 })
                                               }).ToList();
        }
        private IList<ConstantValue> GetEntityLocationTypes()
        {
            var conditionList = RefContext.GetEntityLocations();
            return conditionList.Select(x => new ConstantValue
            {
                Name = x.Name,
                Value = x.EntityLocationTypeID,
                EnumString =
                    ToEnumString(x.Name, x.Value, string.Empty,
                                 new[] { x.EntityLocationTypeID })
            }).ToList();
        }
        private IList<ConstantValue> GetEventTypes()
        {
            var eventList = RefContext.GetEvents();
            return eventList.Select(x => new ConstantValue
                                             {
                                                 Name = x.Name,
                                                 Value = x.EventTypeID,
                                                 EnumString =
                                                     ToEnumString(x.Name, x.EventTypeID, string.Empty,
                                                                  new[] {x.IsItemEvent, x.IsMobileEvent, x.IsSpaceEvent})
                                             }).ToList();
        }
        private IList<ConstantValue> GetFlagTypes()
        {
            var values = RefContext.GetFlags();
            return values.Select(x => new ConstantValue
                                          {
                                              Name = x.Name,
                                              Value = x.FlagTypeID,
                                              EnumString =
                                                  ToEnumString(x.Name, x.FlagTypeID, x.Abbrev, new[] {x.IsResettable})
                                          }).ToList();
        }
        private IList<ConstantValue> GetItemClassTypes()
        {
            var classList = RefContext.GetItemClasses();
            return classList.Select(x => new ConstantValue
                                             {
                                                 Name = x.Name,
                                                 Value = x.ItemClassTypeID,
                                                 EnumString = ToEnumString(x.Name, x.ItemClassTypeID, x.ColorTypeID.ToString())
                                             }).ToList();
        }
        private IList<ConstantValue> GetItemTypes()
        {
            var values = RefContext.GetItemTypes();
            return values.Select(x => new ConstantValue
                                            {
                                                Name = x.Name,
                                                Value = x.Value
                                            }).ToList();
        }
        private IList<ConstantValue> GetMessageScopeTypes()
        {
            var conditionList = RefContext.GetMessageScopes();
            return conditionList.Select(x => new ConstantValue
            {
                Name = x.Name,
                Value = x.MessageScopeTypeID,
                EnumString =
                    ToEnumString(x.Name, x.Value, string.Empty,
                                 new[] { x.MessageScopeTypeID })
            }).ToList();
        }
        private IList<ConstantValue> GetMovementModeTypes()
        {
            var values = RefContext.GetMovementModes();
            return values.Select(x => new ConstantValue
                                          {
                                              Name = x.Name,
                                              Value = x.Value,
                                              EnumString = ToEnumString(x.Name, x.Value, x.ShortName)
                                          }).ToList();
        }
        private IList<ConstantValue> GetPositionTypes()
        {
            var values = RefContext.GetPositions();
            return values.Select(x => new ConstantValue
                                          {
                                              Name = x.Name,
                                              Value = x.Value
                                          }).ToList();
        }
        private IList<ConstantValue> GetStatusEffectTypes()
        {
            var conditionList = RefContext.GetStatusEffects();
            return conditionList.Select(x => new ConstantValue
            {
                Name = x.Name,
                Value = x.StatusEffectTypeID,
                EnumString =
                    ToEnumString(x.Name, x.Value, string.Empty,
                                 new[] { x.StatusEffectTypeID })
            }).ToList();
        }
        private IList<ConstantValue> GetWearLocations()
        {
            var values = RefContext.GetWearLocations();
            return values.Select(x => new ConstantValue
                                          {
                                              Name = x.Name,
                                              Value = x.Value,
                                              EnumString =
                                                  ToEnumString(x.Name, x.Value, x.ShortName, new[] {x.LongName})
                                          }).ToList();
        }
        private IList<ConstantValue> GetGameConstants()
        {
            var constants = RefContext.GetGameConstants();
            return constants.Select(x => new ConstantValue
                                             {
                                                 Name = x.Name,
                                                 Value = Convert.ToInt32(x.GameConstantID),
                                                 Description = x.Description,
                                                 Comment = x.Type,
                                                 EnumString =
                                                     ToEnumString(x.Name, x.GameConstantID, x.Description,
                                                                  new[] {x.Type})
                                             }).ToList();
        }
        private IList<ConstantValue> GetBits(int filter)
        {
            var bits = RefContext.GetBits();

            return bits.Where(x => x.BitTypeID == filter).Select(bit => new ConstantValue
                                                                            {
                                                                                Name = bit.Name,
                                                                                Value = bit.Value,
                                                                                Description = bit.Description,
                                                                                Comment = bit.UniqueGroup,
                                                                                EnumString =
                                                                                    ToEnumString(bit.Name, bit.Value,
                                                                                                 bit.Description,
                                                                                                 new[]
                                                                                                     {
                                                                                                         bit.BitID,
                                                                                                         bit.BitTypeID
                                                                                                     })
                                                                            }).ToList();
        }

        /// <summary>
        /// Takes various enumeration data and builds the enum string
        /// </summary>
        private static string ToEnumString(string name, int value)
        {
            var sb = new StringBuilder();
            sb.AppendFormat("[Enum(\"{0}\", {1}", name, value);
            sb.Append(")]");
            return sb.ToString();
        }

        /// <summary>
        /// Takes various enumeration data and builds the enum string
        /// </summary>
        private static string ToEnumString(string name, int value, string shortName)
        {
            var sb = new StringBuilder();
            sb.AppendFormat("[Enum(\"{0}\", {1}", name, value);
            sb.AppendFormat(", \"{0}\"", !String.IsNullOrEmpty(shortName) ? shortName : name);
            sb.Append(")]");
            return sb.ToString();
        }

        /// <summary>
        /// Takes various enumeration data and builds the enum string, with a values parameter list 
        /// that will be populated into the extra data field using a semi-colon as a delimiter
        /// </summary>
        private static string ToEnumString<T>(string name, int value, string shortName, params T[] values)
        {
            var sb = new StringBuilder();
            sb.AppendFormat("[Enum(\"{0}\", {1}", name, value);
            sb.AppendFormat(", \"{0}\"", !String.IsNullOrEmpty(shortName) ? shortName : name);

            if (values == null) return sb.ToString();
            if (values.Count() == 1)
                sb.AppendFormat(", \"{0}\"", values[0]);
            else
            {
                var enumString = string.Empty;
                for (int i = 0; i < values.Count(); i++ )
                    enumString += values[i] + (i != (values.Count() - 1) ? ";" : string.Empty);
                sb.AppendFormat(", \"{0}\"", enumString);
            }

            sb.Append(")]");
            return sb.ToString();
        }
    }
}
