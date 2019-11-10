using Realm.Library.Common.Entities;
using Realm.Library.Common.Events;

namespace Realm.Library.Ai.Goals
{
    public abstract class Goal
    {
        protected Goal(IEntity owner)
        {
            Owner = owner;
            Status = GoalState.Active;
        }

        public IEntity Owner { get; }

        public GoalState Status { get; set; }

        public bool IsActive => Status == GoalState.Active;

        public bool IsInactive => Status == GoalState.Inactive;

        public bool IsCompleted => Status == GoalState.Completed;

        public bool HasFailed => Status == GoalState.Failed;

        public abstract void Activate();

        public abstract GoalState Process();

        public abstract void Terminate();

        public abstract void HandleMessage(EventBase evt);

        public abstract void AddSubgoal(Goal goal);
    }
}