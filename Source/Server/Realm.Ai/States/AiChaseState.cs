using Realm.Library.Ai;
using Realm.Library.Common.Data;

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