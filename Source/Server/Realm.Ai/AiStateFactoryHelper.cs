using System;
using System.Collections.Generic;
using Realm.Ai.States;
using Realm.Library.Common.Entities;

namespace Realm.Ai
{
    /// <summary>
    ///
    /// </summary>
    public class AiStateFactoryHelper : IHelper<Type>
    {
        private readonly Dictionary<string, Type> _table = new Dictionary<string, Type>
                                                                       {
                                                                          {"chase", typeof (AiChaseState)},
                                                                          {"dead", typeof (AiDeadState)},
                                                                          {"donothing", typeof (AiDoNothingState)},
                                                                          {"fight", typeof (AiFightState)},
                                                                          {"flee", typeof (AiFleeState)},
                                                                          {"moveto", typeof (AiMoveToState)},
                                                                          {"patrol", typeof (AiPatrolState)},
                                                                          {"wander", typeof (AiWanderState)}
                                                                       };

        /// <summary>
        ///
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Type Get(string key)
        {
            return _table.ContainsKey(key) ? _table[key] : null;
        }
    }
}