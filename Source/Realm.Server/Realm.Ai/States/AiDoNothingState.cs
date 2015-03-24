using Realm.Library.Ai;
using Realm.Library.Common.Data;

namespace Realm.Ai.States
{
    public sealed class AiDoNothingState : BaseAiState
    {
        public AiDoNothingState(IAiAgent parent, DictionaryAtom initAtom)
            : base("DoNothing", parent, initAtom)
        {
        }
    }
}