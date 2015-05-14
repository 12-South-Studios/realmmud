using System;
using System.Diagnostics.CodeAnalysis;
using Realm.Library.Common;

namespace Realm.Library.Ai
{
    /// <summary>
    /// Abstract class from which all AiStates are derived
    /// </summary>
    public abstract class AiState : Cell, IAiState
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="parent"></param>
        protected AiState(string name, IAiAgent parent)
        {
            Validation.IsNotNullOrEmpty(name, "name");
            Validation.IsNotNull(parent, "parent");

            Name = name;
            Parent = parent;
        }

        /// <summary>
        /// Reference to the AiBrain that controls this AiState
        /// </summary>
        public IAiAgent Parent { get; private set; }

        /// <summary>
        /// Gets if this AiState is paused
        /// </summary>
        public bool IsPaused { get; private set; }

        /// <summary>
        /// Called during each update of the AIState
        /// </summary>
        [ExcludeFromCodeCoverage]
        public virtual void Execute()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Called whenever the AIState is pushed onto the stack
        /// </summary>
        [ExcludeFromCodeCoverage]
        public virtual void OnEnter()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Called whenever the AIState is popped from the stack
        /// </summary>
        [ExcludeFromCodeCoverage]
        public virtual void OnLeave()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Called whenever the AIState is paused
        /// </summary>
        public virtual void OnPause()
        {
            IsPaused = true;
        }

        /// <summary>
        /// Called whenever the AIState is resumed (after being paused)
        /// </summary>
        public virtual void OnResume()
        {
            IsPaused = false;
        }

        /// <summary>
        /// Can validate the Entity receiving the AIState
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        public virtual bool IsValid(Cell cell)
        {
            Validation.IsNotNull(cell, "cell");

            return true;
        }
    }
}