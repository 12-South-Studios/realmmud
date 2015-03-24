//using System;
//using Realm.Library.Common;
//using Realm.Server.NPC;

//namespace Realm.Server.Factories
//{
//    public class GameShopFactory : GameObjectFactory
//    {
//        public override ICell CreateTemplate(string type, params object[] args)
//        {
//            var obj = CreateTemplate<ShopTemplate, ShopDef>(type, args);

//            Game.Instance.SetManagerReferences(obj);
//            EntityManager.Instance.Register(obj);
//            obj.OnInitHandlers();
//            obj.OnInit();
//            return obj;
//        }

//        public override ICell CreateInstance(string type, params object[] args)
//        {
//            var obj = CreateInstance<ShopInstance, ShopTemplate>(type, args);

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
