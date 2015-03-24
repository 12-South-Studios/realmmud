//using System;
//using System.Collections.Generic;
//using System.Linq;
//using log4net;
//using Realm.Library.Common;
//using Realm.Server.Factories;

//namespace Realm.Server.Effects
//{
//    public class EffectsHandler : EntityContext<IGameEntity>
//    {
//        private readonly IGame _game;
//        private readonly IEntityManager _entityManager;
//        private readonly ILog _log;

//        public EffectsHandler(IGame game, IEntityManager entityManager, ILog log, IGameEntity parent)
//            : base(parent)
//        {
//            _game = game;
//            _entityManager = entityManager;
//            _log = log;
//        }

//        public void AddEffect(EffectInstance effect)
//        {
//            if (HasEffect(effect.ID))
//                return;
//            Entities.Add(effect);
//        }

//        public long AddEffect(long templateId, int duration)
//        {
//            if (HasEffect(templateId)) return 0;

//            var template = _entityManager.LuaGetTemplate(templateId) as EffectTemplate;
//            if (template.IsNull()) return 0;

//            var factory = new GameEffectFactory();
//            var instance = factory.CreateInstance(string.Empty, template) as EffectInstance;
//            if (instance.IsNull()) return 0;

//            // TODO: Set duration of instance

//            _game.SetManagerReferences(instance);
//            Entities.Add(instance);
//            _log.InfoFormat("Duration[{0}]", instance.TimeLeft);
//            //instance.Owner = Parent as Biota;
//            instance.Owner = Owner;

//            // TODO : check if null
//            //Parent.MyZone.Effects.AddEffect(instance);
//            return instance.ID;
//        }


//        public bool HasEffect(Globals.Globals.EffectTypes type)
//        {
//            return Entities.OfType<EffectInstance>().Select(entity => entity).Any(effect => effect.EffectType == type);
//        }

//        public bool HasEffect(long id, bool isTemplate = false)
//        {
//            return isTemplate
//                ? Entities.OfType<EffectInstance>().Select(entity => entity).Any(effect => effect.Parent.ID == id)
//                : Entities.OfType<EffectInstance>().Select(entity => entity).Any(effect => effect.ID == id);
//        }

//        public bool RemoveEffect(long id)
//        {
//            return (from entity in Entities.OfType<EffectInstance>() select entity into effect where effect.ID == id select Entities.Remove(effect)).FirstOrDefault();
//        }

//        /// <summary>
//        /// Generates a list of effects that have the same type as the passed 
//        /// parameter.
//        /// </summary>
//        public IList<EffectInstance> GetEffects(string type)
//        {
//            return Entities.OfType<EffectInstance>().Select(entity => entity)
//                .Where(effect => effect.EffectType.GetName().Equals(type, StringComparison.OrdinalIgnoreCase)).ToList();
//        }
//    }
//}
