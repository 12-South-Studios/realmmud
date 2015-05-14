using Realm.Data.Definitions;
using Realm.Entity.Entities;
using Realm.Event;
using Realm.Library.Common;
using Realm.Library.Common.Data;

namespace Realm.Entity.Resets
{
    /// <summary>
    ///
    /// </summary>
    public abstract class Reset : GameEntity
    {
        private Zone _zone;

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="def"></param>
        protected Reset(long id, string name, Definition def)
            : base(id, name, def)
        {
        }

        /// <summary>
        ///
        /// </summary>
        public ResetDef ResetDef { get { return Definition.CastAs<ResetDef>(); } }

        /// <summary>
        ///
        /// </summary>
        public void OnInit(Zone zone, DictionaryAtom initAtom)
        {
            _zone = zone;

            base.OnInit(initAtom);

            EventManager.RegisterListener(this, _zone, typeof(OnZonePop), OnZonePop);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="args"></param>
        protected abstract void OnZonePop(RealmEventArgs args);

        //{
        // ResetType.Barrier
        // Does the object already exist?
        // Yes, reset its properties
        // No, create it
        // ResetType.Container
        // Does the object already exist?
        // Yes, do what now?
        // No, create it and do what?
        // ResetType.Effect / ResetType.Item / ResetType.Mobile
        // Does the proper number of objects of this type already exist?
        // Yes, End
        // No, create sufficient number up to limit
        //}

        /*: Cell
    {
        protected Reset(Globals.Globals.ResetTypes type, string name, Zone zone)
        {
            Name = name;
            Type = type;
            Zone = zone;
        }

        public void OnInit(IGame game, IEventManager eventManager, ILuaManager luaManager, ILog log, IEntityManager entityManager)
        {
            Game = game;
            EventManager = eventManager;
            LuaManager = luaManager;
            Log = log;
            EntityManager = entityManager;
        }

        protected IGame Game { get; set; }
        protected IEventManager EventManager { get; set; }
        protected ILuaManager LuaManager { get; set; }
        protected LogWrapper Log { get; set; }
        protected IEntityManager EntityManager { get; set; }

        public Globals.Globals.ResetTypes Type { get; private set; }
        public long SpaceId { get; set; }
        public int Limit { get; set; }
        public long ObjectId { get; set; }
        public int Quantity { get; set; }
        public Zone Zone { get; private set; }
        public Globals.Globals.ResetLocTypes Location { get; set; }

        public abstract void Process();

        protected void ThrowOnSpawnEntityEvent(IGameInstance entity)
        {
            if (entity.IsNotNull())
                EventManager.ThrowEvent(this, new OnSpawnEntity("OnSpawnEntity"), new EventTable {{"entity", entity}});
        }*/
    }
}