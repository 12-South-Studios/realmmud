//using System;
//using Realm.Data.Definitions;
//using Realm.Library.Common;
//using Realm.Server.Abilities;

//namespace Realm.Server.Factories
//{
//    public class GameAbilityFactory : GameObjectFactory
//    {
//        public override ICell CreateTemplate(string type, params object[] args) 
//        {
//            var obj = CreateTemplate<AbilityTemplate, AbilityDef>(type, args);

//            Game.Instance.SetManagerReferences(obj);
//            EntityManager.Instance.Register(obj);
//            obj.OnInitHandlers();
//            obj.OnInit();
//            return obj;
//        }

//        public override ICell CreateInstance(string type, params object[] args)
//        {
//            var obj = CreateInstance<AbilityInstance, AbilityTemplate>(type, args);

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
