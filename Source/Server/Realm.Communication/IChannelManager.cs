using Realm.Library.Common.Data;

namespace Realm.Communication
{
    public interface IChannelManager
    {
        void OnInit(DictionaryAtom initAtom);

        DictionaryAtom InitializationAtom { get; }
    }
}