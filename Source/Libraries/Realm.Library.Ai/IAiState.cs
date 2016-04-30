using Realm.Library.Common;
using Realm.Library.Common.Objects;


namespace Realm.Library.Ai

{
    /// <summary>
    /// Defines the contract for the AiState
    /// </summary>
    public interface IAiState : ICell
    {
        /// <summary>
        /// Reference to the AiBrain that controls this AiState
        /// </summary>
        IAiAgent Parent { get; }

        /// <summary>
        /// Gets if this AiState is paused
        /// </summary>
        bool IsPaused { get; }

        /// <summary>
        /// Called during each update of the AIState
        /// </summary>
        void Execute();

        /// <summary>
        /// Called whenever the AIState is pushed onto the stack
        /// </summary>
        void OnEnter();

        /// <summary>
        /// Called whenever the AIState is popped from the stack
        /// </summary>
        void OnLeave();

        /// <summary>
        /// Called whenever the AIState is paused
        /// </summary>
        void OnPause();

        /// <summary>
        /// Called whenever the AIState is resumed (after being paused)
        /// </summary>
        void OnResume();

        /// <summary>
        /// Can validate the Entity receiving the AIState
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        bool IsValid(Cell cell);
    }
}