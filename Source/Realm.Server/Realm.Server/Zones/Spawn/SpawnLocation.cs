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
using Realm.Library.Common;

// ReSharper disable CheckNamespace
namespace Realm.Server.Zones
// ReSharper restore CheckNamespace
{
    public class SpawnLocation : Cell
    {
        public SpawnLocation(int id, string name, Globals.Globals.SpawnTypes type, long value, int density)
        {
            ID = id;
            Name = name;
            Value = value;
            Type = type;
            Density = density;
        }

        public long Value { get; set; }
        public Globals.Globals.SpawnTypes Type { get; set; }
        public int Density { get; set; }

        public void SetType(string type)
        {
            try
            {
                Type = EnumerationExtensions.GetEnum<Globals.Globals.SpawnTypes>(type);
            }
            catch (ArgumentException)
            {
                Type = Globals.Globals.SpawnTypes.None;
            }
        }
    }
}
