// ----------------------------------------------------------------------
// <copyright file="Damage.cs" company="12-South Studios">
//     Copyright (c) 2012. All right reserved.  See LICENSE.TXT.  This file 
//     subject to the Microsoft Public License.  All other rights reserved.
//  </copyright>
// <summary>
//
// </summary>
// ------------------------------------------------------------------------

using Realm.Data;

namespace Realm.Server.NPC.Combat

{
    public class Damage
    {
        public Damage()
        {
            DamageAmount = 0;
            DamageType = Globals.DamageTypes.Crush;
            DamageLocation = Globals.WearLocations.none;
        }

        public Globals.DamageTypes DamageType { get; set; }
        public int DamageAmount { get; set; }
        public Globals.WearLocations DamageLocation { get; set; }
    }
}
