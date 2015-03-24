using Realm.Library.Common;

namespace Realm.Library.Ai.Goals
{
    public abstract class Goal
    {
        protected Goal(IEntity owner)
        {
            Owner = owner;
            Status = GoalState.Active;
        }

        public IEntity Owner { get; private set; }

        public GoalState Status { get; set; }

        public bool IsActive { get { return Status == GoalState.Active; } }

        public bool IsInactive { get { return Status == GoalState.Inactive; } }

        public bool IsCompleted { get { return Status == GoalState.Completed; } }

        public bool HasFailed { get { return Status == GoalState.Failed; } }

        public abstract void Activate();

        public abstract GoalState Process();

        public abstract void Terminate();

        public abstract void HandleMessage(EventBase evt);

        public abstract void AddSubgoal(Goal goal);
    }
}