//using Realm.Entity.Entities;
//using Realm.Library.Common;
//using Realm.Server.Zones;

//namespace Realm.Server.Factories
//{
//    public class GameSpaceFactory : GameObjectFactory
//    {
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
//            var obj = CreateConcrete<Space, SpaceDef>(type, args);

//            Game.Instance.SetManagerReferences(obj);
//            EntityManager.Instance.Register(obj);
//            obj.OnInitHandlers();
//            obj.OnInit();
//            return obj;
//        }
//    }
//}
