using Realm.Data;
using Realm.Data.Interfaces;
using Realm.Entity.Interfaces;
using Realm.Library.Common.Data;
using Realm.Library.Common.Logging;
using Realm.Library.Database.Framework;

namespace Realm.Communication
{
    /// <summary>
    ///
    /// </summary>
    public class ChannelHelper : DatabaseClient, IChannelHelper
    {
        private IDatabaseManager _dbManager;
        private ILogWrapper _log;
        private IEntityManager _entityManager;
        private ChannelRepository _repository;

        /// <summary>
        ///
        /// </summary>
        /// <param name="loadBalancer"></param>
        public ChannelHelper(IDatabaseLoadBalancer loadBalancer, IEntityManager entityManager, ILogWrapper logger)
            : base(null, loadBalancer)
        {
            _dbManager = (DatabaseManager) loadBalancer;
            _entityManager = entityManager;
            _log = logger;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="initAtom"></param>
        /// <param name="repository"></param>
        public void OnInit(DictionaryAtom initAtom, ChannelRepository repository)
        {
            _repository = repository;

            _log.Debug("ChannelHelper initialized");
        }

        public long CreateChannel(IGameEntity owner, string name, bool isAdminOnly)
        {
            // TODO: game_CreateChannel
            return 0;
        }

        public bool ChangeOwnership(IGameEntity newOwner, long channelId)
        {
            return false;
        }

        public bool JoinChannel(IGameEntity entity, long channelId)
        {
            return false;
        }

        public bool LeaveChannel(IGameEntity entity, long channelId)
        {
            return false;
        }
    }
}