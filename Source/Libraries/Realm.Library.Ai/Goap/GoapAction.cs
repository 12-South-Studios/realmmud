using System.Collections.Generic;

namespace Realm.Library.Ai.Goap
{
    public abstract class GoapAction<T>
    {
        private readonly Dictionary<string, object> _preconditions;
        private readonly Dictionary<string, object> _effects;
        private bool _inRange;

        /*
         * Cost of performing this action.
         * Cost will determine the likeliness of this behaviour being run.
         * */
        public float Cost { get; set; }

        /// <summary>
        /// An action often has to perform on an object. This is that object.
        /// </summary>
        public T Target { get; set; }


        public GoapAction()
        {
            _preconditions = new Dictionary<string, object>();
            _effects = new Dictionary<string, object>();
        }

        public void DoReset()
        {
            _inRange = false;
            Target = default(T);
            Reset();
        }

        /// <summary>
        /// Reset any variables that nee dto be reset before the planning step.
        /// </summary>
        public abstract void Reset();

        /// <summary>
        /// Is the action done?
        /// </summary>
        /// <returns></returns>
        public abstract bool IsDone();

        /// <summary>
        /// Procedurally check if this action can run. Not all actions will need this.
        /// </summary>
        /// <returns></returns>
        public abstract bool CheckProceduralPrecondition(T agent);

        /// <summary>
        /// Run the action.
        /// Returns true if the action performed successfully.
        /// Returns false if something happened and it can no longer perform.
        /// If action cannot complete, action queue should clear as the goal cannot be reached.
        /// </summary>
        /// <returns></returns>
        public abstract bool Perform(T agent);

        /// <summary>
        /// Does this action need to be in range of a target object?
        /// </summary>
        /// <returns></returns>
        public abstract bool RequiresInRange();

        /// <summary>
        /// Are we in range of the target?
        /// The MoveTo state will set this and it gets reset each time this action is performed.
        /// </summary>
        /// <returns></returns>
        public bool IsInRange()
        {
            return _inRange;
        }

        public void SetInRange(bool inRange)
        {
            _inRange = inRange;
        }

        public void AddPrecondition(string key, object value)
        {
            _preconditions.Add(key, value);
        }

        public void RemovePrecondition(string key)
        {
            if (_preconditions.ContainsKey(key))
            {
                _preconditions.Remove(key);
            }
        }

        public void AddEffect(string key, object value)
        {
            _effects.Add(key, value);
        }

        public void RemoveEffect(string key)
        {
            if (_effects.ContainsKey(key))
                _effects.Remove(key);
        }

        public Dictionary<string, object> Preconditions => _preconditions;
        public Dictionary<string, object> Effects => _effects;
    }
}
