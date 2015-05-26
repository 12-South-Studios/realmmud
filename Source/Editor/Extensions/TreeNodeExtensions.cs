using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Ninject;
using Realm.DAL;
using Realm.DAL.Enumerations;
using Realm.Edit.Builders;
using Realm.Edit.Editor;
using Realm.Edit.Properties;

namespace Realm.Edit.Extensions
{
    public static class TreeNodeExtensions
    {
        public static int SetupBrowseTree(this TreeNode value, EditorBuilder builder,
            bool fillContent, string filter)
        {
            if (value == null)
                throw new ArgumentNullException("value", Resources.NullParameterErrorMessage);
            if (builder == null)
                throw new ArgumentNullException("builder", Resources.NullParameterErrorMessage);
            if (filter == null)
                throw new ArgumentNullException("filter", Resources.NullParameterErrorMessage);

            var saveNodes = new Dictionary<int, TreeNode>();
            foreach (TreeNode node in value.Nodes)
            {
                if (!node.IsExpanded) continue;
                EditorBrowseInfo saveBrowseInfo = node.Tag as EditorBrowseInfo;
                if (saveBrowseInfo == null) continue;
                saveNodes.Add(saveBrowseInfo.ClassId, node);
            }

            int elementCount = 0;
            value.Nodes.Clear();

            var browseInfo = (value.Tag as EditorBrowseInfo);
            if (browseInfo == null) return 0;

            IRealmDbContext dbContext = Program.NinjectKernel.Get<IRealmDbContext>();
            var classList = dbContext.SystemClasses.Where(x => x.ParentClassId == browseInfo.ClassId);
            foreach (var c in classList)
            {
                var node = value.Nodes.Add("class_" + c.Id, c.Name);
                node.Tag = new EditorBrowseInfo((short)builder.SystemType, c.Name, c.Id, 0);
                node.ImageKey = Resources.ClosedFolderImageKey;
                node.ContextMenuStrip = Program.MainForm.BrowseFolder;

                elementCount += SetupBrowseTree(node, builder, fillContent, filter.Trim());
                if (saveNodes.ContainsKey(c.Id))
                    node.Expand();
            }

            if (fillContent)
            {
                elementCount += builder.PopulateBrowseNode(value, browseInfo.ClassId,
                    Program.MainForm.BrowseFolder, filter);
                if (String.IsNullOrEmpty(filter) && elementCount > 0)
                    value.Expand();
            }

            return elementCount;
        }

        public static void RemoveNonFolderNodes(this TreeNode value)
        {
            if (value == null)
                throw new ArgumentNullException("value", Resources.NullParentNodeErrorMessage);

            for (var i = 0; i < value.Nodes.Count; ++i)
            {
                var editorBrowseInfo = value.Nodes[i].Tag as EditorBrowseInfo;
                if (editorBrowseInfo == null || editorBrowseInfo.Id <= 0) continue;
                value.Nodes.RemoveAt(i);
                --i;
            }
        }

        public static void DeleteBrowseNode(this TreeNode value, string filter)
        {
            if (value == null)
                throw new ArgumentNullException("value", Resources.NullNodeErrorMessage);
            if (filter == null)
                throw new ArgumentNullException("filter", Resources.NullParameterErrorMessage);

            var browseInfo = value.Tag as EditorBrowseInfo;
            if (browseInfo == null || browseInfo.Id <= 0 || browseInfo.SubId != 0) return;

            var nextIndex = value.Index;

            var builder = EditorFactory.Builders[(SystemTypes)browseInfo.SystemType];
            if (builder == null) return;
            builder.Delete(browseInfo.Id);

            var parentNode = Program.MainForm.BrowseTree.SelectedNode.Parent;
            parentNode.SetupBrowseTree(builder, true, filter.Trim());

            var page = Program.MainForm.FindTab((SystemTypes)browseInfo.SystemType, browseInfo.Id);
            if (page != null)
                Program.MainForm.CloseTab(page, false);

            if (parentNode.Nodes.Count <= 0) return;
            Program.MainForm.BrowseTree.SelectedNode = nextIndex >= parentNode.Nodes.Count
                ? parentNode.Nodes[parentNode.Nodes.Count - 1]
                : parentNode.Nodes[nextIndex];
        }

        public static TreeNode FindNodeByClass(this TreeNode value, int classId)
        {
            if (value == null)
                throw new ArgumentNullException("value", Resources.NullNodeErrorMessage);

            var browseInfo = value.Tag as EditorBrowseInfo;
            if (browseInfo != null && browseInfo.ClassId == classId)
                return value;

            return (from TreeNode subNode in value.Nodes select subNode.FindNodeByClass(classId))
                .FirstOrDefault(foundNode => foundNode != null);
        }

        public static void OpenContentNode(this TreeNode value, bool isCopy = false)
        {
            if (value == null)
                throw new ArgumentNullException("value", Resources.NullNodeErrorMessage);

            var browseInfo = (EditorBrowseInfo)value.Tag;
            if (browseInfo != null && browseInfo.Id > 0)
                Program.MainForm.OpenTab(browseInfo, isCopy, false);
        }
    }
}
