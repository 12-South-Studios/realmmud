using Realm.Library.Common;
using Realm.Library.Common.Data;
using Realm.Library.Common.Entities;
using Realm.Library.Common.Events;
using Realm.Library.Common.Logging;
using Realm.Library.Common.Objects;
using Realm.Library.Database.Framework;

namespace Realm.Network.User
{
    public sealed class GameUserLoader : DatabaseClient, IGameUserLoader
    {
        private readonly ILogWrapper _log;
        private EventCallback<RealmEventArgs> _callback;

        public GameUserLoader(IEntity owner, IDatabaseLoadBalancer loadBalancer, ILogWrapper log)
            : base(owner, loadBalancer)
        {
            _log = log;
        }

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