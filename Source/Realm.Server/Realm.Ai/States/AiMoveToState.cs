using Realm.Ai.Properties;
using Realm.Entity.Entities;
using Realm.Library.Ai;
using Realm.Library.Common;
using System.Linq;
using Realm.Library.Common.Data;

namespace Realm.Ai.States
{
    public class AiMoveToState : BaseAiState
    {
        public AiMoveToState(IAiAgent parent, DictionaryAtom initAtom)
            : base("MoveTo", parent, initAtom)
        {
        }

        private Space MoveTo { get; set; }

        private Space Location { get; set; }

        public override void Execute()
        {
            if (MoveTo.IsNull())
            {
                Parent.Messages.Add(Resources.MSG_AI_INVALID_DESTINATION);
                Parent.PopState();
                return;
            }

            //// Arrived at my location
            if (MoveTo.Equals(Location))
            {
                Parent.Messages.Add(Resources.MSG_AI_ALREADY_AT_DESTINATION);
                Parent.PopState();
                return;
            }

            var exit = Location.Portals.Single(x => x.TargetSpace == MoveTo.SpaceDef);
            if (exit.IsNull())
            {
                Parent.Messages.Add(Resources.MSG_AI_NO_PORTAL_TO_DESTINATION);
                Parent.PopState();
                return;
            }

            // TODO: Execute the move command
            //var moveCmd = CommandManager.Instance.GetCommand("playermove");
            //moveCmd.Execute(CommandManager.Instance.PopulateCommandArgs(Parent.Owner as IBiota, null, null, exit.Keywords));
        }

        public override void OnResume()
        {
            base.OnResume();

            var owner = Parent.Owner.CastAs<IBiota>();
            Validation.Validate(owner.IsNotNull(), Resources.ERR_AISTATE_NO_OWNER, ID, Name);

            Location = owner.Location.CastAs<Space>();
            Validation.Validate(Location.IsNotNull(), Resources.ERR_MOBILE_NO_LOCATION, owner.ID, owner.Name);

            if (Location.Equals(MoveTo))
            {
                Parent.Messages.Add(Resources.MSG_AI_ALREADY_AT_DESTINATION);
                Parent.PopState();
                return;
            }

            var exit = Location.Portals.Single(x => x.TargetSpace == MoveTo.SpaceDef);
            if (exit.IsNull())
            {
                Parent.Messages.Add(Resources.MSG_AI_NO_PORTAL_TO_DESTINATION);
                Parent.PopState();
                return;
            }

            // TODO: Execute the move command
            //var moveCmd = CommandManager.Instance.GetCommand("playermove");
            //moveCmd.Execute(CommandManager.Instance.PopulateCommandArgs(Parent.Owner as IBiota, null, null, exit.Keywords));
        }
    }
}