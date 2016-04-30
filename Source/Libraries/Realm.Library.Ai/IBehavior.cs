using Realm.Library.Common.Contexts;


namespace Realm.Library.Ai

{
    /// <summary>
    /// Declares the contract for a behavior
    /// </summary>
    public interface IBehavior
    {
        /// <summary>
        /// Gets the bit handler
        /// </summary>
        IBitContext Bits { get; }

        /// <summary>
        /// Gets the property handler
        /// </summary>
        IPropertyContext Properties { get; }

        /// <summary>
        /// Gets a new state from the behavior
        /// </summary>
        /// <returns></returns>
        IAiState NeedState();
    }
}