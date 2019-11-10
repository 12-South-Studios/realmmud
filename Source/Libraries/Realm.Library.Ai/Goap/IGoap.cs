using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realm.Library.Ai.Goap
{
    public interface IGoap<T>
    {
        Dictionary<string, object> GetWorldState();
        Dictionary<string, object> CreateGoalState();
        void PlanFailed(Dictionary<string, object> failedGoal);
        void PlanFound(Dictionary<string, object> goal, Queue<GoapAction<T>> actions);
        void ActionFinished();
        void PlanAborted(GoapAction<T> aborter);
        bool MoveAgent(GoapAction<T> nextAction);
    }
}
