using Realm.Data.Definitions;
using Realm.Library.Common;

namespace Realm.Entity.Resets
{
    public class EffectReset : Reset
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="def"></param>
        public EffectReset(long id, string name, Definition def)
            : base(id, name, def)
        {
            //// do nothing
        }

        protected override void OnZonePop(RealmEventArgs args)
        {
        }

        /*public EffectReset(string name, Zone zone)
            : base(Globals.Globals.ResetTypes.Effect, name, zone)
        {
            //// Do nothing
        }

        public override void Process()
        {
            IGameEntity entity = EntityManager.LuaGetTemplate(ObjectId);
            if (entity.IsNull())
            {
                Log.ErrorFormat("EffectTemplate[{0}] not found.", ObjectId);
                return;
            }

            var template = entity as EffectTemplate;
            if (template.IsNull()) return;
            if (SpaceId <= 0)
            {
                Log.ErrorFormat("Space[{0}] not found.", SpaceId);
                return;
            }

            Space Space = null;
            var numberNeeded = Quantity > 0 ? Quantity : 1;
            if (Limit > 0)
            {
                //// if reset.SpaceLimit > -1, validate the number in the Space
                entity = EntityManager.LuaGetConcrete(SpaceId);
                if (entity.IsNull())
                {
                    Log.ErrorFormat("Space[{0}] not found.", SpaceId);
                    return;
                }

                Space = entity as Space;
                if (Space.IsNull()) return;

                var entityList = Space.Contents.GetEntities(template);
                numberNeeded = Limit - entityList.Count;
                if (numberNeeded <= 0) return;
            }
            if (Space.IsNull()) return;

            if (template.ZoneLimit > 0)
            {
                //// if reset.zoneLimit > -1, validate the number in the zone
                var entityList = Zone.Contents.GetEntities(template);
                if (entityList.Count + numberNeeded > template.ZoneLimit) return;
            }

            if (template.GlobalLimit > 0)
            {
                //// if reset.globalLimit > -1, validate the number game-wide
                var entityList = EntityManager.GetEntitiesByTemplate(template);
                if (entityList.Count + numberNeeded > template.GlobalLimit) return;
            }

            for (int i = 0; i < numberNeeded; i++)
            {
                var factory = new GameEffectFactory();
                var instance = factory.CreateInstance(string.Empty, template) as EffectInstance;
                if (instance.IsNull())
                {
                    Log.ErrorFormat("Failed to create EffectInstance from EffectTemplate[{0}]", template.ID);
                    continue;
                }

                // TODO: Set duration of Instance

                Game.SetManagerReferences(instance);
                Zone.Contents.AddEntity(instance);
                Space.Contents.AddEntity(instance);
                Log.InfoFormat("Spawned Effect[{0}] into Space[{1}]", instance.ID, Space.ID);
            }
        }*/
    }
}