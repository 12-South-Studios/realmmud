using Realm.Ai.Properties;
using Realm.Entity.Entities.Interfaces;
using Realm.Library.Ai;
using Realm.Library.Common;
using Realm.Library.Common.Data;
using Realm.Library.Common.Objects;

namespace Realm.Ai.States
{
    public class AiFightState : BaseAiState
    {
        public AiFightState(IAiAgent parent, DictionaryAtom initAtom)
            : base("Fight", parent, initAtom)
        {
        }

        public IBiota Target { get; set; }

        public override void Execute()
        {
            var biote = Parent.Owner.CastAs<IBiota>();
            Validation.Validate(biote.IsNotNull(), Resources.ERR_AISTATE_NO_OWNER, Name);

            if (!biote.IsFighting || Target == biote)
                return;

            // TODO: : Get the current weapon or attack
            //// COMBAT.hitCheck(parent, target, null);
        }
    }
}