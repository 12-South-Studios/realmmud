// ReSharper disable CheckNamespace
namespace Realm.Entity.Entities
// ReSharper restore CheckNamespace
{
    /// <summary>
    ///
    /// </summary>
    public interface ICharacter : IBiota
    {
        /// <summary>
        ///
        /// </summary>
        IGameUser User { get; }
    }
}