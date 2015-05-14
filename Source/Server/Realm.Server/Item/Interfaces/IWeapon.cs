// ReSharper disable CheckNamespace
namespace Realm.Server.Item
// ReSharper restore CheckNamespace
{
    public interface IWeapon
    {
        int Parry { get; }
        bool CanParry { get; }
        long Skill { get; }
        Globals.Globals.DamageTypes DamageType { get; }
        int MinDamage { get; }
        int MaxDamage { get; }
    }
}
