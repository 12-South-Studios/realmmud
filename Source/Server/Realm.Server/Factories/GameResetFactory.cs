//using System;
//using System.Collections.Generic;
//using Realm.Entity.Entities;
//using Realm.Entity.Resets;
//using Realm.Library.Common;
//using Realm.Library.Common.Data;
//using Realm.Library.Common.Exceptions;
//using Realm.Server.Resets;

//namespace Realm.Server.Factories
//{
//    public class GameResetFactory : GameObjectFactory
//    {
//        private readonly Dictionary<string, Type> _templateTable = new Dictionary<string, Type>
//                                                                       {
//                                                                           {"barrier", typeof (BarrierReset)},
//                                                                           {"container item", typeof (ContainerItemReset)},
//                                                                           {"effect", typeof (EffectReset)},
//                                                                           {"item", typeof (ItemReset)},
//                                                                           {"mobile", typeof (MobReset)}
//                                                                       };

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
//            if (args.Length < 3 || (int) args[0] < 1 || string.IsNullOrEmpty((string) args[1]) || args[2].IsNull())
//                throw new ArgumentException("Invalid or Insufficient Arguments");

//            var id = (int) args[0];
//            var name = (string) args[1];
//            var def = new EffectDef(id, name, (DictionaryAtom) args[2]);
//            var resetType = EnumerationExtensions.GetEnum<Globals.Globals.ResetTypes>(type);

//            var obj = _templateTable.ContainsKey(resetType.ToString().ToLower())
//                          ? _templateTable[resetType.ToString().ToLower()].Instantiate<Reset>(id, name, def)
//                          : null;

//            if (obj.IsNull())
//                throw new InstantiationException(string.Format("Failed to instantiate {0} with Id {1} and Name {2}",
//                                                               GetType(), id, name));

//            Game.Instance.SetManagerReferences(obj);

//            // TODO: Register with what?
//            //EntityManager.Instance.Register(obj);

//            // TODO: Fix oninit
//            //obj.OnInitHandlers();
//            //obj.OnInit();

//            return obj;
//        }
//    }
//}
