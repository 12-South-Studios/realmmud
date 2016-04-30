using System.Collections.Generic;
using Realm.Library.Common.Data;
using Realm.Library.Common.Extensions;

namespace Realm.Data.Definitions
{
    /// <summary>
    /// Definition of a Zone
    /// </summary>
    public class ZoneDef : Definition
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ZoneDef(long id, string name, DictionaryAtom definition)
            : base(id, name, definition)
        {
        }

        /// <summary>
        ///
        /// </summary>
        public string DisplayName => Def.GetString("DisplayName");

        /// <summary>
        ///
        /// </summary>
        public string DisplayDescription => Def.GetString("DisplayDescription");

        /// <summary>
        /// Gets the recycle time
        /// </summary>
        public int RecycleTime => Def.GetInt("RecycleTime");

        /// <summary>
        /// Gets if the zone is dynamic
        /// </summary>
        public bool IsDynamic => Globals.ZoneBits.IsDynamic.HasBit(Def.GetInt("Bits"));

        /// <summary>
        /// Gets if spells can close the zone (if dynamic)
        /// </summary>
        public bool SpellCanClose => Globals.ZoneBits.SpellCanClose.HasBit(Def.GetInt("Bits"));

        /// <summary>
        /// Gets if boss death can close the zone (if dynamic)
        /// </summary>
        public bool BossDeathCanClose => Globals.ZoneBits.BossDeathCanClose.HasBit(Def.GetInt("Bits"));

        /// <summary>
        /// Gets if the portals refresh
        /// </summary>
        public bool RefreshPortals => Globals.ZoneBits.RefreshPortals.HasBit(Def.GetInt("Bits"));

        /// <summary>
        /// Gets the maximum number of dynamic zones this zone can have connections to
        /// </summary>
        public int MaxDynamicZones => Def.GetInt("MaxDynamicZones");

        /// <summary>
        /// Gets the minimum frequency that dynamic zones can be opened in this zone
        /// </summary>
        public int MinDynamicZoneFrequency => Def.GetInt("MinDynamicZoneFrequency");

        /// <summary>
        /// Gets the ID of the tag set
        /// </summary>
        public int TagSet => Def.GetInt("TagSetID");

        /// <summary>
        /// Gets a list of resets in this zone
        /// </summary>
        public IEnumerable<Atom> Resets => Def.GetAtom<ListAtom>("Resets");

        /// <summary>
        /// Gets a list of spawns in this zone
        /// </summary>
        public IEnumerable<Atom> Spawns => Def.GetAtom<ListAtom>("Spawns");

        /// <summary>
        /// Gets a list of access levels in this zone
        /// </summary>
        public IEnumerable<Atom> AccessLevels => Def.GetAtom<ListAtom>("Accesses");

        /// <summary>
        /// Gets a list of spaces in this zone
        /// </summary>
        public IEnumerable<Atom> Spaces => Def.GetAtom<ListAtom>("Spaces");

        /// <summary>
        ///
        /// </summary>
        public IEnumerable<Atom> Dynamics => Def.GetAtom<ListAtom>("Dynamics");
    }
}