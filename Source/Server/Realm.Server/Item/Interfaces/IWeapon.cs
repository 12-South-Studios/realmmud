
using Realm.Data;

namespace Realm.Server.Item.Interfaces

{
    public interface IWeapon
    {
        int Parry { get; }
        bool CanParry { get; }
        long Skill { get; }
        Globals.DamageTypes DamageType { get; }
        int MinDamage { get; }
        int MaxDamage { get; }
    }
}
