using System;
using Realm.Library.Common.Entities;
using Realm.Library.Common.Events;

namespace Realm.Library.Ai.Goals
{
    public abstract class AtomicGoal : Goal
    {
        protected AtomicGoal(IEntity owner)
            : base(owner)
        {
        }

        public override void Activate()
        {
        }

        public override GoalState Process()
        {
            // TODO: fix
            return GoalState.Failed;
        }

        public override void Terminate()
        {
        }

        public override void HandleMessage(EventBase evt)
        {
        }

        public override void AddSubgoal(Goal goal)
        {
            throw new NotImplementedException();
        }
    }
}