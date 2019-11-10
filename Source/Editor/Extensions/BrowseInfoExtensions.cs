using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;
using Realm.Edit.Editor;
using Realm.Edit.Properties;

namespace Realm.Edit.Extensions
{
    public delegate bool LinkDragCompareDelegate(EditorBrowseInfo value, EditorBrowseInfo dragInfo);

    public static class BrowseInfoExtensions
    {
        public static bool DefaultDragCompare(this EditorBrowseInfo value, EditorBrowseInfo dragInfo)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value), Resources.NullParameterErrorMessage);
            if (dragInfo == null)
                throw new ArgumentNullException(nameof(dragInfo), Resources.NullParameterErrorMessage);

            return dragInfo.SystemType == value.SystemType && dragInfo.Id > 0;
        }

        public static bool ProcessLinkDrag(this LinkLabel value, DragEventArgs eventArgs, bool setValue)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value), Resources.NullParameterErrorMessage);
            if (eventArgs == null)
                throw new ArgumentNullException(nameof(eventArgs), Resources.NullParameterErrorMessage);

            return ProcessLinkDrag(value, eventArgs, setValue, DefaultDragCompare);
        }

        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
        public static bool ProcessLinkDrag(this LinkLabel value, DragEventArgs eventArgs, 
            bool setValue, LinkDragCompareDelegate customPredicate)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value), Resources.NullParameterErrorMessage);
            if (eventArgs == null)
                throw new ArgumentNullException(nameof(eventArgs), Resources.NullParameterErrorMessage);
            if (customPredicate == null)
                throw new ArgumentNullException(nameof(customPredicate), Resources.NullParameterErrorMessage);

            var treeNode = eventArgs.Data.GetData("System.Windows.Forms.TreeNode", true) as TreeNode;

            var browseInfo = treeNode?.Tag as EditorBrowseInfo;
            if (browseInfo == null) return false;

            var existingInfo = value.Tag as EditorBrowseInfo;
            if (existingInfo == null) return false;

            if (!customPredicate(existingInfo, browseInfo)) return false;

            eventArgs.Effect = DragDropEffects.Link;
            if (!setValue || existingInfo.Id == browseInfo.Id) return false;

            value.Tag = browseInfo;
            value.Text = browseInfo.ToString();

            var tt = new ToolTip();
            tt.SetToolTip(value, browseInfo.ToString());
            return true;
        }
    }
}
