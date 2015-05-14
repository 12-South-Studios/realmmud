using log4net;
using Realm.Library.Common;
using Realm.Library.Common.Data;
using Realm.Library.Database.Framework;

namespace Realm.Network.User
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class GameUserLoader : DatabaseClient, IGameUserLoader
    {
        private readonly ILog _log;
        private EventCallback<RealmEventArgs> _callback;

        /// <summary>
        ///
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="loadBalancer"></param>
        /// <param name="log"></param>
        public GameUserLoader(IEntity owner, IDatabaseLoadBalancer loadBalancer, ILog log)
            : base(owner, loadBalancer)
        {
            _log = log;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public bool Load(string username, string ipAddress, EventCallback<RealmEventArgs> callback)
        {
            Validation.IsNotNull(callback, "callback");

            _callback = callback;

            BeginTransaction();

            var args = new DictionaryAtom();
            args.Set("@Username", username);

            AddCommand("live", "game_GetUser", args);

            var userData = new DictionaryAtom();
            userData.Set("IpAddress", ipAddress);
            userData.Set("Username", username);

            PerformTransaction(OnLoadComplete, userData);

            return true;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="args"></param>
        private void OnLoadComplete(RealmEventArgs args)
        {
            Validation.IsNotNull(args, "args");
            Validation.IsNotNull(args.Data, "args.Data");

            var data = args.Data.ToDictionaryAtom();
            if (!data.GetBool("success"))
            {
                _log.ErrorFormat("Failure to load data in {0}", GetType());
                return;
            }

            var commandResult = data.GetAtom<ListAtom>("commandResult").Get(0).CastAs<DictionaryAtom>();
            if (_callback.IsNotNull())
                _callback.Invoke(
                    new RealmEventArgs(new EventTable {{"results", commandResult.GetAtom<ListAtom>("Results")}}));
        }
    }
}