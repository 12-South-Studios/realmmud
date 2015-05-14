using Realm.Library.Common;

// ReSharper disable CheckNamespace
namespace Realm.Library.Ai
// ReSharper restore CheckNamespace
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