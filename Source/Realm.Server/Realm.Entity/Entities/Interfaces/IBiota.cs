using Realm.Data.Definitions;

// ReSharper disable CheckNamespace
namespace Realm.Entity.Entities
// ReSharper restore CheckNamespace
{
    public interface IBiota : IGameEntity
    {
        Globals.Globals.PositionTypes Position { get; set; }

        Globals.Globals.GenderTypes Gender { get; }

        RaceDef Race { get; }

        Globals.Globals.MovementModeTypes Movement { get; set; }

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