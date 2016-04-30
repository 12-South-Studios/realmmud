using Realm.Data;
using Realm.Data.Definitions;
using Realm.Entity.Interfaces;

namespace Realm.Entity.Entities.Interfaces

{
    public interface IBiota : IGameEntity
    {
        Globals.PositionTypes Position { get; set; }

        Globals.GenderTypes Gender { get; }

        RaceDef Race { get; }

        Globals.MovementModeTypes Movement { get; set; }

        string LastAttack { get; set; }

        IBiota Fighting { get; set; }

        bool IsFighting { get; }

        bool IsDead { get; }

        /*
         * Inventory Inventory { get; }
        AbilityTemplate AutoAttackAbility { get; set; }
        string LastAttack { get; set; }
        IBiota Fighting { get; set; }
        bool IsFighting { get; }
        bool IsDead { get; }

        bool CanMove(string aDirection, bool isIgnoringCombat, bool aSendMessage);
        bool CanSee(GameEntityTemplate entity);

        IStatisticHandler StatisticHandler { get; }
        EffectsHandler EffectsHandler { get; }

        int Level { get; set; }
        int CurrentHealth { get; set; }
        int CurrentMana { get; set; }
        int CurrentStamina { get; set; }*/
    }
}