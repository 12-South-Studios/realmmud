using System.Collections.Generic;
using System.IO;
using System.Linq;
using Realm.Data.Definitions;
using Realm.Entity.Events;
using Realm.Library.Common.Data;
using Realm.Library.Common.Events;
using Realm.Library.Common.Exceptions;
using Realm.Library.Common.Objects;

namespace Realm.Entity.Entities
{
    /// <summary>
    ///
    /// </summary>
    public class Space : GameEntity
    {
        private BooleanSet _loadingSet;

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="def"></param>
        public Space(long id, string name, Definition def)
            : base(id, name, def)
        {
            Portals = new List<PortalDef>();
            Barriers = new Dictionary<long, Barrier>();
        }

        /// <summary>
        ///
        /// </summary>
        public SpaceDef SpaceDef => Definition.CastAs<SpaceDef>();

        /// <summary>
        ///
        /// </summary>
        public IList<PortalDef> Portals { get; private set; }

        /// <summary>
        ///
        /// </summary>
        public Dictionary<long, Barrier> Barriers { get; private set; }

        /// <summary>
        ///
        /// </summary>
        public new void OnInit(DictionaryAtom initAtom)
        {
            base.OnInit(initAtom);

            EventManager.RegisterListener(this, typeof(OnStartupEntitiesInitiated), OnInitComplete);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="args"></param>
        private void OnInitComplete(RealmEventArgs args)
        {
            var booleanSet = args.GetValue("BooleanSet").CastAs<BooleanSet>();
            if (booleanSet.IsNull())
                throw new InvalidDataException("BooleanSet not found");

            _loadingSet = booleanSet;

            LoadPortals();
            LoadBarriers();

            _loadingSet.CompleteItem($"Space{ID}");
        }

        private void LoadPortals()
        {
            SpaceDef.Portals.OfType<DictionaryAtom>().ToList().ForEach(portal =>
                {
                    var portalId = portal.GetInt("SpacePortalMapID");
                    Portals.Add(new PortalDef(portalId, "Portal-" + portalId, portal));
                });
        }

        private void LoadBarriers()
        {
            Portals.Where(x => x.Barrier.IsNotNull()).ToList().ForEach(portal =>
                {
                    var obj = EntityManager.Create<Barrier>(portal.Barrier.ID, portal.Barrier.DisplayName, portal.Barrier);
                    if (obj.IsNull())
                        throw new InstantiationException("Barrier {0} could not be instantiated.", portal.Barrier.ID);

                    obj.OnInit(InitializationAtom);
                    Barriers.Add(portal.ID, obj);
                });
        }

        /* public Space(long id, string name)
             : base(id, name, null)
         {
         }

         public EffectsHandler Effects { get; private set; }
         public PortalHandler Portals { get; private set; }

         //public override void OnInit(DictionaryAtom definition)
         public override void OnInit()
         {
         //    base.OnInit();
             Effects = new EffectsHandler(Game, EntityManager, Log, this);
             Portals = new PortalHandler();

             var flag = DataManager.GetFlag("Space");
             Flags.SetFlag(flag.Abbrev);

             var terrain = DataManager.Get("terrains", "Grassland") as Terrain;
             if (terrain.IsNull())
             {
                 Log.ErrorFormat("Terrain {0} not found.", "Grassland");
                 return;
             }
             Terrain = terrain;
         }

         public Terrain Terrain
         {
             get { return (Terrain)DataManager.Get("Terrains", Properties.GetProperty<string>("terrain")); }
             set { Properties.SetProperty("terrain", value.IsNull() ? string.Empty : value.Name); }
         }

         public bool HasLight { get { return TimeManager.GameState.DayState != Globals.Globals.DayStateTypes.Night && IsLitBySun; } }

         public bool IsLitBySun { get { return Terrain.IsNotNull() && Terrain.IsLitBySun; } }

         public int UserCount { get { return Contents.Entities.OfType<Character>().Count(); } }

         public bool HasMonsters()
         {
             return Contents.Entities.OfType<MobInstance>().Select(entity => entity).Any(mob => !mob.Bits.HasBit(Globals.Globals.MobileBits.NoAttack));
         }

         public bool HasNpcs()
         {
             return Contents.Entities.OfType<MobInstance>().Select(entity => entity).Any(mob => mob.Bits.HasBit(Globals.Globals.MobileBits.NoAttack));
         }

         public bool HasPlayers()
         {
             return Contents.Entities.OfType<Character>().Any();
         }

         public bool HasEffects()
         {
             return Contents.Entities.OfType<EffectInstance>().Any();
         }

         public bool HasResourceNodes()
         {
             var itemType = EnumerationExtensions.GetEnum<Globals.Globals.ItemTypes>("Resource Node");
             return Contents.Entities.OfType<ItemInstance>().Select(entity => entity).Any(item => item.ItemType == itemType);
         }

         public bool HasTrainer()
         {
             return Contents.Entities.OfType<MobInstance>().Any(mob => mob.Bits.HasBit(Globals.Globals.MobileBits.IsTrainer));
         }

         public bool HasVendor()
         {
             return Contents.Entities.OfType<MobInstance>().Any(mob => mob.Bits.HasBit(Globals.Globals.MobileBits.IsMerchant));
         }

         public bool IsSafe()
         {
             return Bits.HasBit(Globals.Globals.SpaceBits.IsSafe) ||
                 Contents.Entities.OfType<EffectInstance>().Select(entity => entity).Any(effect => effect.Bits.HasBit(Globals.Globals.EffectBits.IsSafe));
         }

         public bool IsTavern()
         {
             return Bits.HasBit(Globals.Globals.SpaceBits.IsTavern) ||
                 Contents.Entities.OfType<EffectInstance>().Select(entity => entity).Any(effect => effect.Bits.HasBit(Globals.Globals.EffectBits.IsTavern));
         }*/
    }
}