using Realm.DAL.Common;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Realm.Library.Controls.DataGridViewControls
{
    /// <summary>
    ///
    /// </summary>
    /// <param name="browseInfo"></param>
    /// <param name="linkCell"></param>
    /// <returns></returns>
    public delegate bool ValidateDragDelegate(IBrowseInfo browseInfo, DataGridViewTypedLinkCell linkCell);

    /// <summary>
    ///
    /// </summary>
    public class DataGridViewTypedLinkCell : DataGridViewLinkCell
    {
        private Icon _icon;
        private short _systemType;
        private readonly ValidateDragDelegate _dragValidateDelegate = DefaultDragValidate;

        /// <summary>
        ///
        /// </summary>
        public DataGridViewTypedLinkCell()
        {
            _systemType = 0;
            _icon = null;

            Style.Padding = new Padding(20, 0, 0, 0);   // <-- This kicks the text over so that the icon can be left aligned
        }

        /// <summary>
        ///
        /// </summary>
        public Icon Icon => _icon;

        /// <summary>
        ///
        /// </summary>
        public SystemTypes SystemType
        {
            get { return (SystemTypes)Enum.Parse(typeof(SystemTypes), _systemType.ToString()); }
            set
            {
                _systemType = (short)value;

                DataGridView?.Refresh();

                // We changed system types, clear out any Value we might have had
                Value = null;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="browseInfo"></param>
        /// <param name="linkCell"></param>
        /// <returns></returns>
        public static bool DefaultDragValidate(IBrowseInfo aBrowseInfo, DataGridViewTypedLinkCell aLinkCell)
        {
            return aBrowseInfo != null && aBrowseInfo.SystemType == aLinkCell.SystemType && aBrowseInfo.Id > 0;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="e"></param>
        /// <param name="setValue"></param>
        // TODO: Override in derived class and call ValidateRow
        public virtual void HandleGridDrag(DragEventArgs e, bool aSetValue)
        {
            var treeNode = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode", true);
            if (treeNode == null) return;
            var browseInfo = treeNode.Tag as IBrowseInfo;
            if (!_dragValidateDelegate(browseInfo, this)) return;
            e.Effect = DragDropEffects.Link;

            if (!aSetValue || Value == browseInfo) return;
            var row = DataGridView.Rows[RowIndex];
            row.Selected = true;
            DataGridView.CurrentCell = this;

            Value = browseInfo;

            // Grrr!  This is the only way I could find (after WAY too much time) to make a drag in the NewRow
            // turn into a real row and have a "new" NewRow added
            DataGridView.NotifyCurrentCellDirty(false);
            DataGridView.NotifyCurrentCellDirty(true);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override object Clone()
        {
            var clone = (DataGridViewTypedLinkCell)base.Clone();
            clone._icon = Icon;
            clone._systemType = (short)SystemType;
            return clone;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="clipBounds"></param>
        /// <param name="cellBounds"></param>
        /// <param name="rowIndex"></param>
        /// <param name="cellState"></param>
        /// <param name="value"></param>
        /// <param name="formattedValue"></param>
        /// <param name="errorText"></param>
        /// <param name="cellStyle"></param>
        /// <param name="advancedBorderStyle"></param>
        /// <param name="paintParts"></param>
        protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds,
            int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue,
            string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle,
            DataGridViewPaintParts paintParts)
        {
            base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue,
                errorText, cellStyle, advancedBorderStyle, paintParts);

            if (Icon == null) return;
            const int iconDrawSize = 16;
            graphics.DrawIcon(Icon, new Rectangle(cellBounds.Left + 2,
                cellBounds.Y + (cellBounds.Height - iconDrawSize) / 2,
                iconDrawSize, iconDrawSize));
        }

        // TODO: Override this in derived class
        /*protected override void OnContentClick(DataGridViewCellEventArgs e)
        {
            base.OnContentClick(e);

            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                var browseInfo = Value as IBrowseInfo;
                if (browseInfo != null)
                    Program.MainForm.openTab(browseInfo, false, false);
            }
        }*/

        // TODO: Override this in derived class
        /*protected override void OnDoubleClick(DataGridViewCellEventArgs e)
        {
            base.OnDoubleClick(e);

            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                var browseInfo = Value as EditorBrowseInfo;
                if (browseInfo != null)
                    Value = null;
            }
        }*/
    }
}