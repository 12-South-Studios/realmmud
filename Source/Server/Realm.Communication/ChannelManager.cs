using Ninject;
using Realm.Data.Interfaces;
using Realm.Entity.Interfaces;
using Realm.Event;
using Realm.Library.Common.Data;
using Realm.Library.Common.Events;
using Realm.Library.Common.Logging;
using Realm.Library.Common.Objects;

namespace Realm.Communication
{
    public sealed class ChannelManager : GameSingleton, IChannelManager
    {
        private ChannelRepository Channels { get; set; }

        private ChannelHelper Helper { get; set; }

        public ChannelManager(IChannelHelper channelHelper)
        {
            Helper = (ChannelHelper) channelHelper;
        }

        [Inject]
        public IEventManager EventManager { get; set; }

        [Inject]
        public ILogWrapper Log { get; set; }

        [Inject]
        public IDatabaseManager DatabaseManager { get; set; }

        /// <summary>
        ///
        /// </summary>
        public DictionaryAtom InitializationAtom { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="initAtom"></param>
        public void OnInit(DictionaryAtom initAtom)
        {
            InitializationAtom = initAtom;

            Channels = new ChannelRepository();
            Helper.OnInit(InitializationAtom, Channels);

            Log.DebugFormat("{0} setup.", GetType());

            EventManager.RegisterListener(this, typeof(OnGameInitialize), Instance_OnGameInitialize);
        }

        public override void Instance_OnGameInitialize(RealmEventArgs args)
        {
            Log.DebugFormat("{0} received Event OnGameInitialize", GetType());

            var loader = new ChannelLoader(InitializationAtom, Channels, Log);
            Log.Debug("ChannelLoader initialized");

            loader.LoadChannels(OnChannelsLoaded);
        }

        private void OnChannelsLoaded(RealmEventArgs args)
        {
            base.Instance_OnGameInitialize(args);
        }

        #region Channel Helper

        /// <summary>
        ///
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="name"></param>
        /// <param name="isAdminOnly"></param>
        /// <returns></returns>
        public long CreateChannel(IGameEntity owner, string name, bool isAdminOnly)
        {
            return Helper.CreateChannel(owner, name, isAdminOnly);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="newOwner"></param>
        /// <param name="channelId"></param>
        /// <returns></returns>
        public bool ChangeOwnership(IGameEntity newOwner, long channelId)
        {
            return Helper.ChangeOwnership(newOwner, channelId);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="channelId"></param>
        /// <returns></returns>
        public bool JoinChannel(IGameEntity entity, long channelId)
        {
            return Helper.JoinChannel(entity, channelId);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="channelId"></param>
        /// <returns></returns>
        public bool LeaveChannel(IGameEntity entity, long channelId)
        {
            return Helper.LeaveChannel(entity, channelId);
        }

        #endregion Channel Helper

        #region Channel Repository

        public Channel GetChannel(long id)
        {
            return Channels.Get(id);
        }

        #endregion Channel Repository
    }
}