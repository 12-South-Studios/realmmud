using Ninject.Modules;
using Realm.Library.Ai;

namespace Realm.Ai
{
    public class AiModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IMessageContext>().To<MessageContext>();
        }
    }
}
