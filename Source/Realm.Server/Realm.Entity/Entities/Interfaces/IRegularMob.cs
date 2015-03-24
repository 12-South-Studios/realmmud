using Realm.Library.Ai;

// ReSharper disable CheckNamespace
namespace Realm.Entity.Entities
// ReSharper restore CheckNamespace
{
    /// <summary>
    ///
    /// </summary>
    public interface IRegularMob : IMobile, IExperienced
    {
        /// <summary>
        ///
        /// </summary>
        IAiAgent AiBrain { get; }

        //Globals.Globals.MonsterClassTypes MonsterClass { get; }
        //Behavior Behavior { get; }
    }
}