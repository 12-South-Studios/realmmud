//using System;
//using System.Collections.Generic;
//using Realm.Library.Common;
//using Realm.Library.Common.Data;
//using Realm.Library.Common.Exceptions;
//using Realm.Server.NPC;

//namespace Realm.Server.Factories
//{
//    public class GameMobileFactory : GameObjectFactory
//    {
//        private readonly Dictionary<string, Type> _templateTable = new Dictionary<string,Type>
//                                                                      {
//                                                                          { "vendor", typeof(VendorNpcTemplate)},
//                                                                          { "resource", typeof(ResourceMobTemplate)},
//                                                                          { "static", typeof(StaticNpcTemplate)}
//                                                                      };
//        private readonly Dictionary<string, Type> _instanceTable = new Dictionary<string, Type>
//                                                                      {
//                                                                          { "vendor", typeof(VendorNpcInstance)},
//                                                                          { "resource", typeof(ResourceMobInstance)},
//                                                                          { "static", typeof(StaticNpcInstance)}
//                                                                      };

//        public override ICell CreateTemplate(string type, params object[] args)
//        {
//            if (args.Length < 3 || (int)args[0] < 1 || string.IsNullOrEmpty((string)args[1]) || args[2].IsNull())
//                throw new ArgumentException("Invalid or Insufficient Arguments");

//            var id = (int)args[0];
//            var name = (string)args[1];
//            var def = new MobileDef(id, name, (DictionaryAtom)args[2]);

//            var obj = _templateTable.ContainsKey(type.ToLower())
//                ? _templateTable[type.ToLower()].Instantiate<MobTemplate>(id, name, def)
//                : typeof(RegularMobTemplate).Instantiate<RegularMobTemplate>(id, name, def);

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
//            if (args.Length < 2 || (long)args[0] < 1 || args[2].IsNull())
//                throw new ArgumentException("Invalid or Insufficient Arguments");

//            var id = (int)args[0];
//            var parent = (MobTemplate) args[1];
//            var itemType = EnumerationExtensions.GetEnum<Globals.Globals.ItemTypes>(type);

//            var obj = _instanceTable.ContainsKey(type.ToLower())
//                ? _instanceTable[type.ToLower()].Instantiate<MobInstance>(id, parent)
//                : typeof(RegularMobInstance).Instantiate<RegularMobInstance>(id, parent);

//            if (obj.IsNull())
//                throw new InstantiationException(string.Format("Failed to instantiate {0} with Id {1} and parent {2}",
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
