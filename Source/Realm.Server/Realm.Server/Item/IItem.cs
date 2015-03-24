using System.Collections.Generic;
using Realm.Server.Attributes;
using Realm.Server.NPC.Interfaces;

namespace Realm.Server.Item
{
    public interface IItem
    {
        int MaxStackSize { get; set; }
        int Weight { get; set; }
        Material Material { get; set; }
        ItemType ItemType { get; set; }
        int Volume { get; }
        IEnumerable<WearLocation> WearLocations { get; }
        int ZoneLimit { get; set; }
        int GlobalLimit { get; set; }
        IEnumerable<Statistic> StatMods { get; }

        bool IsTakeable { get; }
        bool IsTradeable { get; }
        bool IsRepairable { get; }
        bool IsWearable { get; }
        bool IsStackable { get; }

        bool CanBeWorn(IBiota biota);
        bool IsType(string type);
        int GetStatMod(Statistic stat);
    }
}
