// ----------------------------------------------------------------------
// <copyright file="ConversationNode.cs" company="12-South Studios">
//     Copyright (c) 2012. All right reserved.  See LICENSE.TXT.  This file 
//     subject to the Microsoft Public License.  All other rights reserved.
//     subject to the Microsoft Public License.  All other rights reserved.
// <summary>
//
// </summary>
// ------------------------------------------------------------------------
// ReSharper disable CheckNamespace
namespace Realm.Server.NPC
// ReSharper restore CheckNamespace
{
    public class ConversationNode
    {
        public ConversationNode(long number, int parent, string keywords, string txt, int type)
        {
            Text = txt;
            Keyword = keywords;
            NodeNumber = number;
            NodeParent = parent;
            OverrideType = type;
        }

        public string Text { get; private set; }
        public string Keyword { get; private set; }
        public long NodeNumber { get; private set; }
        public int NodeParent { get; private set; }
        public int OverrideType { get; private set; }
    }
}
