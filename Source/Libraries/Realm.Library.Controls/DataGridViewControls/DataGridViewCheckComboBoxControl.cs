using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Realm.Library.Controls.DataGridViewControls

{
    /// <summary>
    ///
    /// </summary>
    public class DataGridViewCheckComboBoxControl : DataGridViewComboBoxEditingControl
    {
        /// <summary>
        ///
        /// </summary>
        public DataGridViewCheckComboBoxControl()
        {
            DrawMode = DrawMode.OwnerDrawFixed;
            DrawItem += CheckComboBoxDrawItem;
            SelectedIndexChanged += CheckComboBoxSelectedIndexChanged;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckComboBoxDrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index == -1) return;

            if (!(Items[e.Index] is CheckComboBoxItem))
            {
                e.Graphics.DrawString(Items[e.Index].ToString(), Font, Brushes.Black,
                    new Point(e.Bounds.X, e.Bounds.Y));
                return;
            }

            var box = (CheckComboBoxItem) Items[e.Index];

            CheckBoxRenderer.RenderMatchingApplicationState = true;
            CheckBoxRenderer.DrawCheckBox(
                e.Graphics,
                new Point(e.Bounds.X, e.Bounds.Y),
                e.Bounds,
                box.Text,
                Font,
                (e.State & DrawItemState.Focus) == 0,
                box.CheckState ? CheckBoxState.CheckedNormal :
                    CheckBoxState.UncheckedNormal);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            var item = SelectedItem as CheckComboBoxItem;
            item.CheckState = !item.CheckState;
        }

        /// <summary>
        ///
        /// </summary>
        internal class CheckComboBoxItem
        {
            /// <summary>
            ///
            /// </summary>
            /// <param name="text"></param>
            /// <param name="id"></param>
            /// <param name="initialCheckState"></param>
            public CheckComboBoxItem(string text, int id, bool initialCheckState)
            {
                Key = 0;
                CheckState = initialCheckState;
                Text = text;
                ID = id;
            }

            /// <summary>
            ///
            /// </summary>
            public int Key { get; set; }

            /// <summary>
            ///
            /// </summary>
            public int ID { get; set; }

            /// <summary>
            ///
            /// </summary>
            public bool CheckState { get; set; }

            /// <summary>
            ///
            /// </summary>
            public string Text { get; set; }

            /// <summary>
            ///
            /// </summary>
            /// <returns></returns>
            public override string ToString()
            {
                return "Select Options";
            }
        }
    }
}