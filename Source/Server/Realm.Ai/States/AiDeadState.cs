using Realm.Library.Ai;
using Realm.Library.Common.Data;

namespace Realm.Ai.States
{
    public sealed class AiDeadState : BaseAiState
    {
        public AiDeadState(IAiAgent parent, DictionaryAtom initAtom)
            : base("Dead", parent, initAtom)
        {
        }
    }
}