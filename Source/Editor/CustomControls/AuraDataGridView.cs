using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Realm.Edit.Extensions;
using Realm.Edit.Properties;
using Realm.Library.Controls.DataGridViewControls;

namespace Realm.Edit.CustomControls
{
    public delegate string ValidateRowDelegate(DataGridViewRow row);

    public sealed class AuraDataGridView : DataGridView
    {
        private Rectangle _dragDropRectangle;
        private int _dragDropSourceIndex;
        private int _dragDropTargetIndex;
        private int _dragDropCurrentIndex = -1;
        private bool _draggingRow;

        public AuraDataGridView()
        {
            AllowRowDeletion = true;
            AllowUserToResizeRows = false;
            ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            EditMode = DataGridViewEditMode.EditOnEnter;
            RowHeadersWidth = 20;
            SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            UserDeletedRow += OnUserDeletedRow;
            UserDeletingRow += OnUserDeletingRow;
            ValidateRow += DefaultRowValidate;

            DeletedRows = new List<DataGridViewRow>();
        }

        public ValidateRowDelegate ValidateRow { get; set; }

        public DataGridViewRow SelectedRow => SelectedRows.Count == 0 ? null : SelectedRows[0];

        public bool AllowRowDeletion { get; set; }

        public ICollection<DataGridViewRow> DeletedRows { get; }
        #endregion

        public static string DefaultRowValidate(DataGridViewRow row)
        {
            return string.Empty;
        }

        public void SelectFirstVisible()
        {
            foreach (DataGridViewRow gridRow in Rows)
            {
                gridRow.Selected = false;
            }
            foreach (var gridRow in Rows.Cast<DataGridViewRow>().Where(gridRow => gridRow.Visible))
            {
                gridRow.Selected = true;
                break;
            }
        }

        public void SelectLastVisible()
        {
            DataGridViewRow theLast = null;
            foreach (DataGridViewRow gridRow in Rows)
            {
                gridRow.Selected = false;
            }
            foreach (var gridRow in Rows.Cast<DataGridViewRow>().Where(gridRow => gridRow.Visible))
            {
                theLast = gridRow;
            }
            if (theLast != null)
                theLast.Selected = true;
        }

        public bool ValidateRows()
        {
            EndEdit();
            return Rows.Cast<DataGridViewRow>().All(OnValidateRow);
        }

        public bool OnValidateRow(DataGridViewRow row)
        {
            if (row == null)
                throw new ArgumentNullException(nameof(row), Resources.NullParameterErrorMessage);

            var invalidCol = string.Empty;
            if (!row.IsNewRow)
                invalidCol = ValidateRow(row);

            if (invalidCol.Length > 0)
            {
                var errorColor = Color.DarkRed;
                row.DefaultCellStyle.SelectionBackColor = errorColor;
                row.DefaultCellStyle.BackColor = errorColor;
                return false;
            }
            row.DefaultCellStyle.SelectionBackColor = DefaultCellStyle.SelectionBackColor;
            row.DefaultCellStyle.BackColor = DefaultCellStyle.BackColor;
            return true;
        }

        public void DeleteAll()
        {
            foreach (var row in Rows.OfType<DataGridViewRow>().Where(row => !row.IsNewRow))
                DeleteRow(row);
        }

        public bool IsDeleted(DataGridViewRow value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value), Resources.NullParameterErrorMessage);

            return DeletedRows.ToList().Find(r => r.Tag == value.Tag) != null;
        }

        public void SetVisible(DataGridViewRow value, bool visible)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value), Resources.NullParameterErrorMessage);

            if (IsDeleted(value)) return;
            value.Visible = visible;
        }

        public void DeleteRowObjectTagged(DataGridViewRow value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value), Resources.NullParameterErrorMessage);

            if (!value.CanDeleteIfTagged()) return;
            value.Visible = false;
            DeletedRows.Add(value);
        }

        public void DeleteRow(DataGridViewRow value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value), Resources.NullParameterErrorMessage);

            if (value.IsNewRow) return;
            value.Visible = false;
            if (Rows.Contains(value))
                Rows.Remove(value);
            DeletedRows.Add(value);
        }

        public void CommitDeletedRows(DataView value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value), Resources.NullParameterErrorMessage);

            foreach (var row in DeletedRows.Where(x => !x.CanDelete()))
            {
                var rowIndex = value.Find((int)row.Tag);
                if (rowIndex < 0) continue;

                var dataRow = value[rowIndex];

                dataRow?.Delete();
            }

            DeletedRows.Clear();
        }

        public void FlushDeletedRows()
        {
            DeletedRows.Clear();
        }

        protected override void OnCellValueChanged(DataGridViewCellEventArgs e)
        {
            if (e == null)
                throw new ArgumentNullException(nameof(e), Resources.NullParameterErrorMessage);

            base.OnCellValueChanged(e);
            ValidateRow(Rows[e.RowIndex]);
        }

        protected override void OnRowValidating(DataGridViewCellCancelEventArgs e)
        {
            if (e == null)
                throw new ArgumentNullException(nameof(e), Resources.NullParameterErrorMessage);

            base.OnRowValidating(e);
            var gridRow = Rows[e.RowIndex];
            if (!gridRow.IsNewRow)
                ValidateRow(gridRow);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e == null)
                throw new ArgumentNullException(nameof(e), Resources.NullParameterErrorMessage);

            if (AllowDrop)
            {
                if (HitTest(e.X, e.Y).ColumnIndex == -1 && HitTest(e.X, e.Y).RowIndex > -1)
                {
                    if (Rows[HitTest(e.X, e.Y).RowIndex].Selected)
                    {
                        _draggingRow = true;
                        var dragSize = SystemInformation.DragSize;
                        _dragDropRectangle = new Rectangle(new Point(e.X - dragSize.Width / 2,
                            e.Y - dragSize.Height / 2), dragSize);
                        _dragDropSourceIndex = HitTest(e.X, e.Y).RowIndex;
                    }
                    else
                    {
                        _draggingRow = false;
                        _dragDropRectangle = Rectangle.Empty;
                    }
                }
                else
                {
                    _draggingRow = false;
                    _dragDropRectangle = Rectangle.Empty;
                }
            }
            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (e == null)
                throw new ArgumentNullException(nameof(e), Resources.NullParameterErrorMessage);

            if (AllowDrop)
            {
                if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
                {
                    if (_dragDropRectangle != Rectangle.Empty && !_dragDropRectangle.Contains(e.X, e.Y))
                        DoDragDrop(Rows[_dragDropSourceIndex], DragDropEffects.Move);
                }
            }
            base.OnMouseMove(e);
        }

        protected override void OnDragDrop(DragEventArgs drgevent)
        {
            if (drgevent == null)
                throw new ArgumentNullException(nameof(drgevent), Resources.NullParameterErrorMessage);

            if (AllowDrop && _draggingRow)
            {
                if (drgevent.Effect == DragDropEffects.Move)
                {
                    var clientPoint = PointToClient(new Point(drgevent.X, drgevent.Y));

                    _dragDropTargetIndex = HitTest(clientPoint.X, clientPoint.Y).RowIndex;
                    if (_dragDropTargetIndex > -1 && _dragDropCurrentIndex < RowCount - 1)
                    {
                        _dragDropCurrentIndex = -1;
                        var sourceRow = drgevent.Data.GetData(typeof(DataGridViewRow)) as DataGridViewRow;
                        Rows.RemoveAt(_dragDropSourceIndex);
                        if (sourceRow != null)
                            Rows.Insert(_dragDropTargetIndex, sourceRow);
                        Rows[_dragDropTargetIndex].Selected = true;
                        CurrentCell = this[0, _dragDropTargetIndex];
                    }
                    _draggingRow = false;
                }
            }
            base.OnDragDrop(drgevent);
            ProcessBrowseDrag(this, drgevent, true);
        }

        protected override void OnDragOver(DragEventArgs e)
        {
            if (e == null)
                throw new ArgumentNullException(nameof(e), Resources.NullParameterErrorMessage);

            e.Effect = DragDropEffects.Move;

            if (FirstDisplayedScrollingRowIndex != 0)
            {
                if (e.Y <= PointToScreen(new Point(Location.X, Location.Y)).Y + 10)
                    FirstDisplayedScrollingRowIndex -= 1;
            }
            if (e.Y >= PointToScreen(new Point(Location.X, Location.Y + Height)).Y - 90)
                FirstDisplayedScrollingRowIndex += 1;


            if (AllowDrop && _draggingRow)
            {
                e.Effect = DragDropEffects.Move;
                var curRow = HitTest(PointToClient(new Point(e.X, e.Y)).X, PointToClient(new Point(e.X, e.Y)).Y).RowIndex;
                if (_dragDropCurrentIndex != curRow)
                {
                    _dragDropCurrentIndex = curRow;
                    Invalidate();
                }
            }
            // drgevent.Effect = DragDropEffects.None;    // Assume nothing will happen
            ProcessBrowseDrag(this, e, false);

            base.OnDragOver(e);
        }

        protected override void OnCellPainting(DataGridViewCellPaintingEventArgs e)
        {
            if (e == null)
                throw new ArgumentNullException(nameof(e), Resources.NullParameterErrorMessage);

            if (_dragDropCurrentIndex > -1 && _draggingRow)
            {
                if (e.RowIndex == _dragDropCurrentIndex && _dragDropCurrentIndex < RowCount - 1)
                {
                    //if this cell is in the same row as the mouse cursor
                    using (var p = new Pen(Color.Red, 1))
                        e.Graphics.DrawLine(p, e.CellBounds.Left, e.CellBounds.Top - 1, e.CellBounds.Right,
                            e.CellBounds.Top - 1);
                }
            }
            base.OnCellPainting(e);
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData != Keys.Delete) return base.ProcessDialogKey(keyData);

            foreach (DataGridViewRow row in SelectedRows)
                DeleteRow(row);

            return base.ProcessDialogKey(keyData);
        }

        private static void ProcessBrowseDrag(DataGridView aGrid, DragEventArgs e, bool aSetValue)
        {
            // If the drag is over this cell, try getting the browse info that matches this sytem type
            // Otherwise, return null
            var clientPt = aGrid.PointToClient(new Point(e.X, e.Y));  //screen coordinates
            var hitInfo = aGrid.HitTest(clientPt.X, clientPt.Y); //x, y);

            if (hitInfo.Type != DataGridViewHitTestType.Cell) return;

            var typedCell = aGrid[hitInfo.ColumnIndex, hitInfo.RowIndex] as DataGridViewTypedLinkCell;
            typedCell?.HandleGridDrag(e, aSetValue);
        }

        private void OnUserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            DeleteRow(e.Row);
        }

        private void OnUserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (!AllowRowDeletion)
                e.Cancel = true;
        }
    }
}
