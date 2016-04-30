using System;
using System.Collections;
using System.Windows.Forms;
using Realm.Edit.Editor;
using Realm.Edit.Properties;

namespace Realm.Edit.Extensions
{
    public static class TreeViewExtensions
    {
        public static TreeNode FindTreeNode(this TreeView value, EditorBrowseInfo browseInfo)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value), Resources.NullParameterErrorMessage);

            return FindTreeNodeImpl(value.Nodes, browseInfo);
        }

        private static TreeNode FindTreeNodeImpl(IEnumerable aNodeCollection, EditorBrowseInfo browseInfo)
        {
            foreach (TreeNode node in aNodeCollection)
            {
                if (CompareNodeToBrowse(node, browseInfo))
                    return node;

                TreeNode foundNode = FindTreeNodeImpl(node.Nodes, browseInfo);
                if (foundNode != null)
                    return foundNode;
            }

            return null;
        }

        private static bool CompareNodeToBrowse(TreeNode aNode, EditorBrowseInfo browseInfo)
        {
            var nodeInfo = aNode.Tag as EditorBrowseInfo;
            if (nodeInfo == null) return false;

            return nodeInfo.SystemType == browseInfo.SystemType &&
                   nodeInfo.ClassId == browseInfo.ClassId &&
                   nodeInfo.Id == browseInfo.Id;
        }
    }

}
