//using System.Linq;
//using Realm.Library.Common;
//using Realm.Library.Patterns.Repository;
//using Realm.Server.Abilities;
//using Realm.Server.Factories;

//namespace Realm.Server.Players
//{
//    public class AbilityRepository : Repository<long, AbilityInstance>
//    {
//        private readonly IGame _game;
//        private readonly IEntityManager _entityManager;

//        public AbilityRepository(IGame game, IEntityManager entityManager)
//        {
//            _game = game;
//            _entityManager = entityManager;
//        }

//        public bool AddAbility(int abilityDefId)
//        {
//            if (Values.Any(entity => entity.Parent.IsNotNull() && entity.Parent.ID == abilityDefId)) return false;
//            var template = _entityManager.LuaGetTemplate(abilityDefId) as AbilityTemplate;
//            if (template.IsNull()) return false;

//            var factory = new GameAbilityFactory();

//            // TODO: Fix this
//            //var instance = factory.Create(template, null);
//            //_game.SetManagerReferences(instance);
//            //Add(instance.ID, instance);
//            return true;
//        }

//        public bool HasAbility(long abilityDefId)
//        {
//            return Values.Any(entity => entity.Parent.ID == abilityDefId);
//        }

//        public AbilityInstance GetAbility(long abilityDefId)
//        {
//            return Values.FirstOrDefault(entity => entity.Parent.ID == abilityDefId);
//        }
//    }
//}
