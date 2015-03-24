using Realm.Network.User;

namespace Realm.Network
{
    public interface IMenuHandler
    {
        bool Execute(GameUser user, string messageToEvaluate);

        void SendMenu(GameUser user);
    }
}