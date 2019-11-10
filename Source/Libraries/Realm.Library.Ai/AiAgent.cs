using System;
using System.Collections.Generic;
using System.Linq;
using Realm.Library.Ai.Properties;
using Realm.Library.Common;
using Realm.Library.Common.Entities;
using Realm.Library.Common.Objects;

namespace Realm.Library.Ai
{
    /// <summary>
    /// Base class that defines the framework for an AiBrain, an object that handles
    /// the mechanics of the Ai state and message management.
    /// </summary>
    public abstract class AiAgent : IAiAgent
    {
        private readonly Stack<IAiState> _stateStack = new Stack<IAiState>();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="messageContext"></param>
        /// <param name="behavior"></param>
        /// <exception cref="ArgumentNullException"></exception>
        protected AiAgent(IEntity owner, IMessageContext messageContext, IBehavior behavior)
        {
            Validation.IsNotNull(owner, "owner");
            Validation.IsNotNull(messageContext, "messageContext");
            Validation.IsNotNull(behavior, "behavior");

            Owner = owner;
            Messages = messageContext;
            Behavior = behavior;
        }

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<EventArgs> OnAgentWake;

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<EventArgs> OnAgentSleep;

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<EventArgs> OnStateChange;

        /// <summary>
        /// Entity object that owns this AiBrain
        /// </summary>
        public IEntity Owner { get; }

        /// <summary>
        /// Message handler, which maintains and processes internal messages
        /// for the AiBrain
        /// </summary>
        public IMessageContext Messages { get; }

        /// <summary>
        /// Reference to the behavior that determines what states this AiBrain
        /// uses and how they operate.
        /// </summary>
        public IBehavior Behavior { get; }

        /// <summary>
        /// Event function that fires on each tick of the AiBrain.
        /// Must be implemented in derived classes.
        /// </summary>
        public abstract void OnTick();

        /// <summary>
        /// Pushes a new state onto the Ai state stack.
        /// </summary>
        /// <param name="state">Instance object that is implements the IAiState interface</param>
        public void PushState(IAiState state)
        {
            Validation.IsNotNull(state, "state");

            Messages.Add(string.Format(Resources.MSG_STATE_PUSHED, Owner.ID, Owner.Name, state.ID, state.Name));
            _stateStack.Push(state);

            OnStateChange?.Invoke(this, null);
        }

        /// <summary>
        /// Pops the top Ai state instance from the state stack.
        /// </summary>
        /// <returns>Reference to the freshly popped state</returns>
        public IAiState PopState()
        {
            Messages.Add(string.Format(Resources.MSG_STATE_PUSHED, Owner.ID, Owner.Name, CurrentState.ID, CurrentState.Name));
            var state = _stateStack.Pop();

            OnStateChange?.Invoke(this, null);

            return state;
        }

        /// <summary>
        /// Gets if the Ai state stack contains a reference to the Ai state instance
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool HasState(IAiState value)
        {
            Validation.IsNotNull(value, "value");

            var stateList = _stateStack.ToList();
            return stateList.Any(aiState => aiState == value);
        }

        /// <summary>
        /// Gets if the Ai state stack contains a reference with a matching name
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public bool HasState(string value)
        {
            Validation.IsNotNullOrEmpty(value, "value");

            return _stateStack.ToList().Any(state => state.Name.Equals(value, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Gets a reference to the current Ai state instance on the stack
        /// </summary>
        public IAiState CurrentState => _stateStack.Peek();

        /// <summary>
        /// Called to inform the AiBrain that it needs to get an Ai state.
        /// Must be implemented in derived classes.
        /// </summary>
        /// <returns></returns>
        public abstract IAiState NeedState();

        /// <summary>
        /// Gets if the AiBrain is currently asleep
        /// </summary>
        public bool IsAsleep { get; private set; }

        /// <summary>
        /// Wakes the AiBrain, resumes the current state
        /// </summary>
        public void Wake()
        {
            Messages.Add(string.Format(Resources.MSG_WAKE, Owner.ID, Owner.Name));
            if (IsAsleep)
                IsAsleep = false;

            if (CurrentState.IsNotNull())
                CurrentState.OnResume();

            OnAgentWake?.Invoke(this, null);
        }

        /// <summary>
        /// Puts the AiBrian to sleep, pauses the current state
        /// </summary>
        public void Sleep()
        {
            Messages.Add(string.Format(Resources.MSG_SLEEP, Owner.ID, Owner.Name));
            if (!IsAsleep)
                IsAsleep = true;

            if (CurrentState.IsNotNull())
                CurrentState.OnPause();

            OnAgentSleep?.Invoke(this, null);
        }
    }
}