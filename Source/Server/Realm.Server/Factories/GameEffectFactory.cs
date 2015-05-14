//using System;
//using System.Collections.Generic;
//using Realm.Library.Common;
//using Realm.Library.Common.Data;
//using Realm.Library.Common.Exceptions;
//using Realm.Server.Effects;
//using Realm.Server.Effects.Instances;
//using Realm.Server.Effects.Templates;

//namespace Realm.Server.Factories
//{
//    public class GameEffectFactory : GameObjectFactory
//    {
//        private readonly Dictionary<string, Type> _templateTable = new Dictionary<string, Type>
//                                                                      {
//                                                                          { "ablative", typeof(AblativeEffectTemplate) },
//                                                                          { "changeposition", typeof(ChangePositionEffectTemplate) },
//                                                                          { "damageshield", typeof(DamageShieldEffectTemplate) },
//                                                                          { "drainstat", typeof(DrainStatEffectTemplate) },
//                                                                          { "giveability", typeof(GiveAbilityEffectTemplate) },
//                                                                          { "giveentity", typeof(GiveEntityEffectTemplate) },
//                                                                          { "giveskill", typeof(GiveSkillEffectTemplate) },
//                                                                          { "healthchange", typeof(HealthChangeEffectTemplate) },
//                                                                          { "healthchangeovertime", typeof(HealthChangeOverTimeEffectTemplate) },
//                                                                          { "spaceeffect", typeof(SpaceEffectEffectTemplate) },
//                                                                          { "statmod", typeof(StatModEffectTemplate) },
//                                                                          { "statmodchangeovertime", typeof(StatModChangeOverTimeEffectTemplate) },
//                                                                          { "statuseffect", typeof(StatusEffectEffectTemplate) },
//                                                                          { "teleport", typeof(TeleportEffectTemplate) },
//                                                                          { "temporaryentity", typeof(TemporaryEntityEffectTemplate) },
//                                                                          { "timedeffect", typeof(TimedEffectEffectTemplate) }
//                                                                      };

//        private readonly Dictionary<string, Type> _instanceTable = new Dictionary<string, Type>
//                                                                      {
//                                                                          {"ablative", typeof (AblativeEffectInstance)},
//                                                                          { "changeposition", typeof(ChangePositionEffectInstance) },
//                                                                          { "damageshield", typeof(DamageShieldEffectInstance) },
//                                                                          { "drainstat", typeof(DrainStatEffectInstance) },
//                                                                          { "giveability", typeof(GiveAbilityEffectInstance) },
//                                                                          { "giveentity", typeof(GiveEntityEffectInstance) },
//                                                                          { "giveskill", typeof(GiveSkillEffectInstance) },
//                                                                          { "healthchange", typeof(HealthChangeEffectInstance) },
//                                                                          { "healthchangeovertime", typeof(HealthChangeOverTimeEffectInstance) },
//                                                                          { "spaceeffect", typeof(SpaceEffectEffectInstance) },
//                                                                          { "statmod", typeof(StatModEffectInstance) },
//                                                                          { "statmodchangeovertime", typeof(StatModChangeOverTimeEffectInstance) },
//                                                                          { "statuseffect", typeof(StatusEffectEffectInstance) },
//                                                                          { "teleport", typeof(TeleportEffectInstance) },
//                                                                          { "temporaryentity", typeof(TemporaryEntityEffectInstance) },
//                                                                          { "timedeffect", typeof(TimedEffectEffectInstance) }
//                                                                      };

//        public override ICell CreateTemplate(string type, params object[] args)
//        {
//            if (args.Length < 3 || (int)args[0] < 1 || string.IsNullOrEmpty((string)args[1]) || args[2].IsNull())
//                throw new ArgumentException("Invalid or Insufficient Arguments");

//            var id = (int)args[0];
//            var name = (string)args[1];
//            var def = new EffectDef(id, name, (DictionaryAtom)args[2]);
//            var effectType = EnumerationExtensions.GetEnum<Globals.Globals.EffectTypes>(type);

//            var obj = _templateTable.ContainsKey(effectType.ToString().ToLower())
//                ? _templateTable[effectType.ToString().ToLower()].Instantiate<EffectTemplate>(id, name, def)
//                : null;

//            if (obj.IsNull())
//                throw new InstantiationException(string.Format("Failed to instantiate {0} with Id {1} and Name {2}",
//                    GetType(), id, name));

//            Game.Instance.SetManagerReferences(obj);
//            EntityManager.Instance.Register(obj);
//            obj.OnInitHandlers();
//            obj.OnInit();
//            return obj;
//        }

//        public override ICell CreateInstance(string type, params object[] args)
//        {
//            if (args.Length < 2 || (int)args[0] < 1 || args[2].IsNull())
//                throw new ArgumentException("Invalid or Insufficient Arguments");

//            var id = (int)args[0];
//            var parent = (EffectTemplate)args[1];
//            var effectType = EnumerationExtensions.GetEnum<Globals.Globals.EffectTypes>(type);

//            var obj = _instanceTable.ContainsKey(effectType.ToString().ToLower())
//                ? _instanceTable[effectType.ToString().ToLower()].Instantiate<EffectInstance>(id, parent)
//                : null;

//            if (obj.IsNull())
//                throw new InstantiationException(string.Format("Failed to instantiate {0} with Id {1} and Parent {2}",
//                    GetType(), id, parent.ID));

//            Game.Instance.SetManagerReferences(obj);
//            EntityManager.Instance.Register(obj);
//            obj.OnInitHandlers();
//            obj.OnInit();
//            return obj;
//        }

//        public override ICell CreateConcrete(string type, params object[] args)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
