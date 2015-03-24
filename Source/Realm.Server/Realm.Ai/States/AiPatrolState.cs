using Realm.Library.Ai;
using Realm.Library.Common.Data;

namespace Realm.Ai.States
{
    public class AiPatrolState : BaseAiState
    {
        public AiPatrolState(IAiAgent parent, DictionaryAtom initAtom)
            : base("Patrol", parent, initAtom)
        {
        }
    }
}