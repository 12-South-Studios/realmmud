//using System;
//using System.Collections.Generic;
//using Realm.Library.Common;
//using Realm.Library.Common.Data;
//using Realm.Library.Common.Exceptions;
//using Realm.Server.Item;

//namespace Realm.Server.Factories
//{
//    public class GameItemFactory : GameObjectFactory
//    {
//        private readonly Dictionary<string, Type> _templateTable = new Dictionary<string, Type>
//                                                                      {
//                                                                          {"armor", typeof (ArmorItemTemplate)},
//                                                                          {"container", typeof (ContainerItemTemplate)},
//                                                                          {"corpse", typeof (CorpseItemTemplate)},
//                                                                          {"drink container", typeof (DrinkContainerItemTemplate)},
//                                                                          {"formula", typeof (FormulaItemTemplate)},
//                                                                          {"key", typeof (KeyItemTemplate)},
//                                                                          {"light", typeof (LightItemTemplate)},
//                                                                          {"machine", typeof (MachineItemTemplate)},
//                                                                          {"potion", typeof (PotionItemTemplate)},
//                                                                          {"resource", typeof (ResourceItemTemplate)},
//                                                                          {"resource node", typeof (ResourceNodeItemTemplate)},
//                                                                          {"tool", typeof (ToolItemTemplate)},
//                                                                          {"weapon", typeof (WeaponItemTemplate)}
//                                                                      };
//        private readonly Dictionary<string, Type> _instanceTable = new Dictionary<string, Type>
//                                                                      {
//                                                                          {"armor", typeof (ArmorItemInstance)},
//                                                                          {"container", typeof (ContainerItemInstance)},
//                                                                          {"corpse", typeof (CorpseItemInstance)},
//                                                                          {"drink container", typeof (DrinkContainerItemInstance)},
//                                                                          {"formula", typeof (FormulaItemInstance)},
//                                                                          {"key", typeof (KeyItemInstance)},
//                                                                          {"light", typeof (LightItemInstance)},
//                                                                          {"machine", typeof (MachineItemInstance)},
//                                                                          {"potion", typeof (PotionItemInstance)},
//                                                                          {"resource", typeof (ResourceItemInstance)},
//                                                                          {"resource node", typeof (ResourceNodeItemInstance)},
//                                                                          {"tool", typeof (ToolItemInstance)},
//                                                                          {"weapon", typeof (WeaponItemInstance)}
//                                                                      };

//        public override ICell CreateTemplate(string type, params object[] args)
//        {
//            if (args.Length < 3 || (int)args[0] < 1 || string.IsNullOrEmpty((string)args[1]) || args[2].IsNull())
//                throw new ArgumentException("Invalid or Insufficient Arguments");

//            var id = (int)args[0];
//            var name = (string)args[1];
//            var def = new ItemDef(id, name, (DictionaryAtom)args[2]);
//            var itemType = EnumerationExtensions.GetEnum<Globals.Globals.ItemTypes>(type);

//            var obj = _templateTable.ContainsKey(itemType.ToString().ToLower())
//                ? _templateTable[itemType.ToString().ToLower()].Instantiate<ItemTemplate>(id, name, def)
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
//            var parent = (ItemTemplate)args[1];
//            var itemType = EnumerationExtensions.GetEnum<Globals.Globals.ItemTypes>(type);

//            var obj = _instanceTable.ContainsKey(itemType.ToString().ToLower())
//                ? _instanceTable[itemType.ToString().ToLower()].Instantiate<ItemInstance>(id, parent)
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
