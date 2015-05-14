// ----------------------------------------------------------------------
// <copyright file="ResourceToolType.cs" company="12-South Studios">
//     Copyright (c) 2012. All right reserved.  See LICENSE.TXT.  This file 
//     subject to the Microsoft Public License.  All other rights reserved.
//     subject to the Microsoft Public License.  All other rights reserved.
// <summary>
//
// </summary>
// ------------------------------------------------------------------------

namespace Realm.Server.Item
{
    public class ResourceToolType
    {
        public long ResourceId { get; set; }
        public Globals.Globals.ToolTypes ToolType { get; set; }
        public int GatherAmount { get; set; }
        public int MinimumSkill { get; set; }
    }
}
