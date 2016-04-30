using Realm.Data;
using Realm.Data.Definitions;
using Realm.Library.Common.Events;

namespace Realm.Entity.Resets
{
    /// <summary>
    ///
    /// </summary>
    public class MobileReset : Reset
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="def"></param>
        public MobileReset(long id, string name, Definition def)
            : base(id, name, def)
        {
            //// do nothing
        }

        protected override void OnZonePop(RealmEventArgs args)
        {
            var mobileId = ResetDef.ObjectID;

            // TODO:
            // Reset Limit in Room, Zone, by Access?
            // Get current quantity for each
            var currentQty = 0;
            if (currentQty >= ResetDef.Limit)
                return;

            var numberNeeded = ResetDef.Quantity > 0 ? ResetDef.Quantity : 1;
            if (ResetDef.Limit - currentQty > numberNeeded)
                numberNeeded = ResetDef.Limit - currentQty;

            switch (ResetDef.ResetLocationType)
            {
                case Globals.ResetLocTypes.Space:
                    break;

                case Globals.ResetLocTypes.Access:
                    break;
            }
        }

        /*private void PopulateSpaceWithEntity(int number, int location)
        {
            var mobileDef = null;   // TODO: Get the MobileDef here
            for (int i = 0; i < number; i++)
            {
                EntityManager.Instance.Create(new MobileFactoryHelper(), mobileDef.GetType(), args);
            }
        }*/
    }
}

/*public override void Process()
{
    var entity = EntityManager.LuaGetTemplate(ObjectId);
    if (entity.IsNull())
    {
        Log.ErrorFormat("MobTemplate[{0}] not found.", ObjectId);
        return;
    }
    var template = entity as MobTemplate;
    if (template.IsNull()) return;

    Space Space = null;
    var numberNeeded = Quantity > 0 ? Quantity : 1;
    if (Limit > 0)
    {
        var entityList = new List<GameEntityTemplate>();

        //// if reset.SpaceLimit > -1, validate the number in the Space
        switch (Location)
        {
            case Globals.Globals.ResetLocTypes.Space:
                Space = Zone.Contents.GetEntity(SpaceId) as Space;
                if (Space.IsNull())
                {
                    Log.ErrorFormat("Space[{0}] not found.", SpaceId);
                    return;
                }
                entityList.AddRange(Space.Contents.GetEntities(template).Cast<GameEntityTemplate>());
                break;

            case Globals.Globals.ResetLocTypes.Access:
                {
                    // TODO: Fix this to get Spaces by access, not SpaceId
                    //var SpaceList = Zone.GetSpacesByAccess(SpaceId);
                    //foreach (var SpaceObj in SpaceList)
                    //    entityList.AddRange(SpaceObj.Contents.GetEntities(template).Cast<GameEntityTemplate>());
                }
                break;
        }

        numberNeeded = Limit - entityList.Count;
        if (numberNeeded <= 0) return;
    }

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
        var factory = new GameMobileFactory();
        var instance = factory.CreateInstance(string.Empty, template) as MobInstance;
        if (instance.IsNull())
        {
            Log.ErrorFormat("Failed to create MobInstance from MobTemplate[{0}]", template.ID);
            continue;
        }

        Game.SetManagerReferences(instance);
        Zone.Contents.AddEntity(instance);

        // Static mobs arent' registered with the Ai handler
        if (!instance.Bits.HasBit(Globals.Globals.MobileBits.IsStatic))
            Zone.AiContext.Register(instance.CastAs<IRegularMob>().AiBrain);

        if (Location == Globals.Globals.ResetLocTypes.Access)
        {
            // TODO: Fix this to get Spaces by access, not SpaceId
            //var SpaceList = Zone.GetSpacesByAccess(SpaceId);
            //Space = SpaceList[die.Between(0, SpaceList.Count - 1)];
        }
        if (Space.IsNull()) continue;

        Space.Contents.AddEntity(instance);
        Log.InfoFormat("Spawned Mob[{0}] into Space[{1}]", instance.ID, Space.ID);
        ThrowOnSpawnEntityEvent(instance);
    }
}
}
}*/