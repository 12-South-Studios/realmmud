//using System;
//using System.Collections.Generic;
//using System.IO;
//using Realm.Data.Definitions;
//using Realm.Entity.Entities;
//using Realm.Library.Common;
//using Realm.Library.Common.Exceptions;
//using Realm.Server.Attributes;
//using Realm.Server.Events;
//using Realm.Server.Item;
//using Realm.Server.NPC;
//using Realm.Server.Properties;
//using Realm.Server.Players;
//using Realm.Server.Time;
//using Realm.Server.Zones;
//using Realm.Server.Ai;
//using Realm.Server.Channels;

//namespace Realm.Server.Factories
//{
//    /// <summary>
//    /// Defines a factory that is used to create generic concretes
//    /// </summary>
//    public class GameConcreteFactory : GameObjectFactory
//    {
//        private readonly Dictionary<string, Tuple<Type, Type>> _typeTable = new Dictionary<string, Tuple<Type, Type>>
//            {
//                { "archetype", new Tuple<Type, Type>(typeof(Archetype), typeof(ArchetypeDef)) },
//                { "barrier", new Tuple<Type, Type>(typeof(Barrier), typeof(BarrierDef)) },
//                { "behavior", new Tuple<Type, Type>(typeof(Behavior), typeof(BarrierDef)) },
//                { "channel", new Tuple<Type, Type>(typeof(Channel), typeof(BarrierDef)) },
//                { "conversation", new Tuple<Type, Type>(typeof(ConversationTree), typeof(ConversationDef)) },
//                { "help", new Tuple<Type, Type>(typeof(HelpEntry), typeof(HelpDef)) },
//                { "faction", new Tuple<Type, Type>(typeof(Faction), typeof(FactionDef)) },
//                { "itemset", new Tuple<Type, Type>(typeof(ItemSet), typeof(FactionDef)) },
//                { "liquid", new Tuple<Type, Type>(typeof(Liquid), typeof(FactionDef)) },
//                { "month", new Tuple<Type, Type>(typeof(Month), typeof(FactionDef)) },
//                { "mudprog", new Tuple<Type, Type>(typeof(MudProg), typeof(FactionDef)) },
//                { "race", new Tuple<Type, Type>(typeof(Race), typeof(FactionDef)) },
//                { "ritual", new Tuple<Type, Type>(typeof(Ritual), typeof(FactionDef)) },
//                { "skill", new Tuple<Type, Type>(typeof(Skill), typeof(FactionDef)) },
//                { "skillcategory", new Tuple<Type, Type>(typeof(SkillCategory), typeof(FactionDef)) },
//                { "terrain", new Tuple<Type, Type>(typeof(Terrain), typeof(FactionDef)) },
//                { "treasure", new Tuple<Type, Type>(typeof(Treasure), typeof(FactionDef)) },
//                { "zone", new Tuple<Type, Type>(typeof(Zone), typeof(ZoneDef)) }
//            }; 

//        public override ICell CreateTemplate(string type, params object[] args)
//        {
//            throw new System.NotImplementedException();
//        }

//        public override ICell CreateInstance(string type, params object[] args)
//        {
//            throw new System.NotImplementedException();
//        }

//        public override ICell CreateConcrete(string type, params object[] args)
//        {
//            Validation.IsNotNullOrEmpty(type, "type");
//            Validation.Validate(_typeTable.ContainsKey(type.ToLower()), string.Format("Type {0} does not exist in the Concrete Type Table", type));
//            Validation.Validate<InvalidDataException>(_typeTable[type.ToLower()].Item1 == typeof(GameEntityConcrete), string.Format("Type {0} is not a valid type", _typeTable[type.ToLower()].Item1));
//            Validation.Validate<InvalidDataException>(_typeTable[type.ToLower()].Item2 == typeof(Definition), string.Format("Type {0} is not a valid type", _typeTable[type.ToLower()].Item2));
//            Validation.Validate(args.Length >= 3);
//            Validation.Validate(Convert.ToInt32(args[0]) >= 1);
//            Validation.IsNotNullOrEmpty(args[1].ToString(), "args1");
//            Validation.IsNotNull(args[2], "args2");

//            // Instantiate the definition file
//            var def = Activator.CreateInstance(_typeTable[type.ToLower()].Item2, args);
//            if (def.IsNull())
//                throw new InstantiationException(ErrorResources.ERR_FAIL_INSTANTIATE_TEMPLATE, Convert.ToInt32(args[0]), args[1]);

//            // Instantiate the concrete object
//            var obj = Activator.CreateInstance(_typeTable[type.ToLower()].Item1, new List<object> {Convert.ToInt32(args[0]), args[1], def}.ToArray());
//            if (obj.IsNull())
//                throw new InstantiationException(ErrorResources.ERR_FAIL_INSTANTIATE_TEMPLATE, _typeTable[type.ToLower()].Item1, Convert.ToInt32(args[0]), args[1]);

//            // Cast it cause we need to do some operations on a concrete type
//            var concrete = obj as GameEntityConcrete;
//            if (concrete.IsNull())
//                throw new InvalidCastException(string.Format("Object with Id {0} and Name {1} could not be cast to GameEntityConcrete type", Convert.ToInt32(args[0]), args[1]));

//            Game.Instance.SetManagerReferences(concrete);
//            EntityManager.Instance.Register(concrete);
//            concrete.OnInitHandlers();
//            concrete.OnInit();
//            return concrete;
//        }
//    }
//}
