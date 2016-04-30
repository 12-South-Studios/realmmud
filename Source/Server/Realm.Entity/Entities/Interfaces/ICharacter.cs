
namespace Realm.Entity.Entities.Interfaces

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