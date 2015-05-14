// ----------------------------------------------------------------------
// <copyright file="Damage.cs" company="12-South Studios">
//     Copyright (c) 2012. All right reserved.  See LICENSE.TXT.  This file 
//     subject to the Microsoft Public License.  All other rights reserved.
//  </copyright>
// <summary>
//
// </summary>
// ------------------------------------------------------------------------
// ReSharper disable CheckNamespace
namespace Realm.Server.NPC
// ReSharper restore CheckNamespace
{
    public class Damage
    {
        public Damage()
        {
            DamageAmount = 0;
            DamageType = Globals.Globals.DamageTypes.Crush;
            DamageLocation = Globals.Globals.WearLocations.none;
        }

        public Globals.Globals.DamageTypes DamageType { get; set; }
        public int DamageAmount { get; set; }
        public Globals.Globals.WearLocations DamageLocation { get; set; }
    }
}
