using Realm.Command.Interfaces;
using Realm.Entity;
using Realm.Library.Ai;
using Realm.Library.Common.Data;
using Realm.Library.Common.Logging;

namespace Realm.Ai.States
{
    public class AiChaseState : BaseAiState
    {
        public AiChaseState(IAiAgent parent, DictionaryAtom initAtom)
            : base("Chase", parent, initAtom)
        {
        }
    }
}