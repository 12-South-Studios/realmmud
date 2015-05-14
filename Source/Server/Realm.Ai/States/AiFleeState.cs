using Realm.Library.Ai;
using Realm.Library.Common.Data;

namespace Realm.Ai.States
{
    public class AiFleeState : BaseAiState
    {
        public AiFleeState(IAiAgent parent, DictionaryAtom initAtom)
            : base("Flee", parent, initAtom)
        {
        }
    }
}