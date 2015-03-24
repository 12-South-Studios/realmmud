using System.Linq;
using Realm.Ai.Properties;
using Realm.Entity;
using Realm.Entity.Entities;
using Realm.Library.Ai;
using Realm.Library.Common;
using Realm.Library.Common.Data;
using Realm.Data.Definitions;

namespace Realm.Ai.States
{
    public class AiWanderState : BaseAiState
    {
        public AiWanderState(IAiAgent parent, DictionaryAtom initAtom)
            : base("Wander", parent, initAtom)
        {
        }

        public override void Execute()
        {
            var owner = Parent.Owner.CastAs<IRegularMob>();
            Validation.Validate(owner.IsNotNull(), Resources.ERR_AISTATE_NO_OWNER, ID, Name);

            if (owner.AiBrain.Behavior.Bits.HasBit(Globals.Globals.BehaviorBits.Sentinel))
            {
                Parent.Messages.Add(Resources.MSG_AI_STATIONARY_CANNOT_WANDER);
                Parent.PopState();
                return;
            }

            if (owner.IsFighting)
            {
                Parent.Messages.Add(Resources.MSG_AI_COMBAT_CANNOT_WANDER);
                Parent.PopState();
                return;
            }

            if (Random.D100(1) > Game.GetPropertyContext().GetProperty<int>("DefaultWanderChance"))
            {
                Parent.Messages.Add(Resources.MSG_AI_CHOSE_NOT_TO_MOVE);
                return;
            }

            var moveDir = GetRandomSpace();
            if (string.IsNullOrEmpty(moveDir))
            {
                Parent.Messages.Add(Resources.MSG_AI_INVALID_DESTINATION);
                return;
            }

            Parent.Messages.Add(string.Format(Resources.MSG_AI_MOVING_TO, moveDir));

            // TODO: Move Command
            //var moveCmd = CommandManager.Instance.GetCommand("playermove");
            //moveCmd.Execute(CommandManager.Instance.PopulateCommandArgs(Parent.Owner as IRegularMob, null, null, moveDir));
        }

        private string GetRandomSpace()
        {
            var owner = Parent.Owner.CastAs<IRegularMob>();
            Validation.Validate(owner.IsNotNull(), Resources.ERR_AISTATE_NO_OWNER, ID, Name);

            var currentSpace = owner.Location.CastAs<Space>();
            if (currentSpace.IsNull())
            {
                Log.ErrorFormat(Resources.ERR_MOBILE_NO_LOCATION, owner.ID, owner.Name);
                return string.Empty;
            }

            var result = Random.Roll(currentSpace.Count(), 1);
            var count = 1;

            foreach (PortalDef portalDef in currentSpace.Portals)
            {
                var portal = currentSpace.Portals.Single(x => x.Direction == portalDef.Direction);
                if (count == result)
                    return portal.Barrier.IsNotNull() ? string.Empty : portalDef.Direction.ToString().ToLower();
                count++;
            }
            return string.Empty;
        }
    }
}