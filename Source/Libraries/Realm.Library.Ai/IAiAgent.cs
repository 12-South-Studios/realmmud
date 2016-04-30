using System;
using Realm.Library.Common.Entities;


namespace Realm.Library.Ai

{
    /// <summary>
    /// Defines the contract for an AiBrain
    /// </summary>
    public interface IAiAgent
    {
        /// <summary>
        ///
        /// </summary>
        event EventHandler<EventArgs> OnAgentWake;

        /// <summary>
        ///
        /// </summary>
        event EventHandler<EventArgs> OnAgentSleep;

        /// <summary>
        ///
        /// </summary>
        event EventHandler<EventArgs> OnStateChange;

        /// <summary>
        /// Entity object that owns this AiBrain
        /// </summary>
        IEntity Owner { get; }

        /// <summary>
        /// Message handler, which maintains and processes internal messages
        /// for the AiBrain
        /// </summary>
        IMessageContext Messages { get; }

        /// <summary>
        /// Reference to the behavior that determines what states this AiBrain
        /// uses and how they operate.
        /// </summary>
        IBehavior Behavior { get; }

        /// <summary>
        /// Event function that fires on each tick of the AiBrain.
        /// Must be implemented in derived classes.
        /// </summary>
        void OnTick();

        /// <summary>
        /// Pushes a new state onto the Ai state stack.
        /// </summary>
        /// <param name="state">Instance object that is implements the IAiState interface</param>
        /// <exception cref="ArgumentNullException"></exception>
        void PushState(IAiState state);

        /// <summary>
        /// Pops the top Ai state instance from the state stack.
        /// </summary>
        /// <returns>Reference to the freshly popped state</returns>
        IAiState PopState();

        /// <summary>
        /// Gets if the Ai state stack contains a reference to the Ai state instance
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        bool HasState(IAiState state);

        /// <summary>
        /// Gets if the Ai state stack contains a reference with a matching name
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        bool HasState(string state);

        /// <summary>
        /// Gets a reference to the current Ai state instance on the stack
        /// </summary>
        IAiState CurrentState { get; }

        /// <summary>
        /// Called to inform the AiBrain that it needs to get an Ai state.
        /// Must be implemented in derived classes.
        /// </summary>
        /// <returns></returns>
        IAiState NeedState();

        /// <summary>
        /// Wakes the AiBrain, resumes the current state
        /// </summary>
        void Wake();

        /// <summary>
        /// Puts the AiBrian to sleep, pauses the current state
        /// </summary>
        void Sleep();

        /// <summary>
        /// Gets if the AiBrain is currently asleep
        /// </summary>
        bool IsAsleep { get; }
    }
}