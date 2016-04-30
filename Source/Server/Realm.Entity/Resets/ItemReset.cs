using Realm.Data.Definitions;
using Realm.Library.Common.Events;

namespace Realm.Entity.Resets
{
    /// <summary>
    ///
    /// </summary>
    public class ItemReset : Reset
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="def"></param>
        public ItemReset(long id, string name, Definition def)
            : base(id, name, def)
        {
            //// do nothing
        }

        protected override void OnZonePop(RealmEventArgs args)
        {
        }

        /* public override void Process()
        {
            var entity = EntityManager.LuaGetTemplate(ObjectId);
            if (entity.IsNull())
            {
                Log.ErrorFormat("ItemTemplate[{0}] not found.", ObjectId);
                return;
            }
            var template = entity as ItemTemplate;
            if (template.IsNull()) return;

            if (SpaceId <= 0)
            {
                Log.ErrorFormat("Space[{0}] not found.", SpaceId);
                return;
            }

            Space Space = null;
            var numberNeeded = Quantity > 0 ? Quantity : 1;
            if (numberNeeded > template.MaxStackSize)
            {
                numberNeeded = template.MaxStackSize;
            }

            if (Limit > 0)
            {
                //// if reset.SpaceLimit > -1, validate the number in the Space
                var concrete = EntityManager.LuaGetConcrete(SpaceId);
                if (concrete.IsNull())
                {
                    Log.ErrorFormat("Space[{0}] not found.", SpaceId);
                    return;
                }

                Space = concrete as Space;
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

            if (template.IsStackable)
            {
                var factory = new GameItemFactory();
                var instance = factory.CreateInstance(string.Empty, template) as ItemInstance;
                if (instance.IsNull())
                {
                    Log.ErrorFormat("Failed to create ItemInstance from ItemTemplate[{0}]", template.ID);
                    return;
                }

                Game.SetManagerReferences(instance);
                instance.StackSize = numberNeeded;
                Zone.Contents.AddEntity(instance);
                Space.Contents.AddEntity(instance);
                Log.InfoFormat("Spawned Item[{0}] with Quantity {1} into Space[{2}]", instance.ID, numberNeeded, Space.ID);
            }
            else
            {
                for (int i = 0; i < numberNeeded; i++)
                {
                    var factory = new GameItemFactory();
                    var instance = factory.CreateInstance(string.Empty, template) as ItemInstance;
                    if (instance.IsNull())
                    {
                        Log.ErrorFormat("Failed to create ItemInstance from ItemTemplate[{0}]", template.ID);
                        continue;
                    }

                    Game.SetManagerReferences(instance);
                    Zone.Contents.AddEntity(instance);
                    Space.Contents.AddEntity(instance);
                    Log.InfoFormat("Spawned Item[{0}] into Space[{1}]", instance.ID, Space.ID);
                }
            }
        }*/
    }
}