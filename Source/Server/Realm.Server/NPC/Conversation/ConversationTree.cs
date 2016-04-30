// ----------------------------------------------------------------------
// <copyright file="ConversationTree.cs" company="12-South Studios">
//     Copyright (c) 2012. All right reserved.  See LICENSE.TXT.  This file 
//     subject to the Microsoft Public License.  All other rights reserved.
//     subject to the Microsoft Public License.  All other rights reserved.
// <summary>
//
// </summary>
// ------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using Realm.Library.Common.Objects;

namespace Realm.Server.NPC.Conversation

{
    public class ConversationTree : Cell
    {
        private readonly IList<ConversationNode> _nodes = new List<ConversationNode>();

        public ConversationTree(long id, string name)
        {
            ID = id;
            Name = name;
        }

        public IEnumerable<ConversationNode> Nodes => _nodes;

        public int NodeCount => _nodes.Count;

        public bool AddNode(long number, int parent, string keywords, string txt, int type)
        {
            var node = new ConversationNode(number, parent, keywords, txt, type);
            if (_nodes.Contains(node)) return false;
            _nodes.Add(node);
            return true;
        }

        public bool AddNode(ConversationNode node)
        {
            if (node.IsNull() || _nodes.Contains(node)) return false;
            _nodes.Add(node);
            return true;
        }

        public ConversationNode GetNode(string str)
        {
            return Nodes.FirstOrDefault(node => node.Keyword.Contains(str));
        }

        public ConversationNode GetNode(int nbr)
        {
            if (_nodes.Count == 0) return null;
            if (nbr < 1 || nbr > _nodes.Count) return null;
            return _nodes[nbr - 1];
        }
    }
}
