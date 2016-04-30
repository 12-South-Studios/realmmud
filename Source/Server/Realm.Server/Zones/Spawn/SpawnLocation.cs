// ----------------------------------------------------------------------
// <copyright file="SpawnLocation.cs" company="12-South Studios">
//     Copyright (c) 2012. All right reserved.  See LICENSE.TXT.  This file 
//     subject to the Microsoft Public License.  All other rights reserved.
// </copyright>
// <summary>
//
// </summary>
// ------------------------------------------------------------------------

using System;
using Realm.Data;
using Realm.Library.Common.Extensions;
using Realm.Library.Common.Objects;

namespace Realm.Server.Zones.Spawn

{
    public class SpawnLocation : Cell
    {
        public SpawnLocation(int id, string name, Globals.SpawnTypes type, long value, int density)
        {
            ID = id;
            Name = name;
            Value = value;
            Type = type;
            Density = density;
        }

        public long Value { get; set; }
        public Globals.SpawnTypes Type { get; set; }
        public int Density { get; set; }

        public void SetType(string type)
        {
            try
            {
                Type = EnumerationExtensions.GetEnum<Globals.SpawnTypes>(type);
            }
            catch (ArgumentException)
            {
                Type = Globals.SpawnTypes.None;
            }
        }
    }
}
