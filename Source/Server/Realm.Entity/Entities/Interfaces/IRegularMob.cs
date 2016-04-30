using Realm.Library.Ai;

namespace Realm.Entity.Entities.Interfaces

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