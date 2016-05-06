using System;
using System.Drawing;
using System.Windows.Forms;
using Realm.DAL.Common;
using Realm.Edit.Builders;
using Realm.Edit.Editor;
using Realm.Edit.Extensions;
using Realm.Edit.Properties;

namespace Realm.Edit.CustomControls
{
    public sealed class AuraLinkLabel : LinkLabel
    {
        private SystemTypes _systemType = SystemTypes.None;

        public AuraLinkLabel()
        {
            Padding = new Padding(20, 1, 0, 0);   // <-- This kicks the text over so that the icon can be left aligned
            AllowDrop = true;
            Text = string.Empty;
            Tag = new EditorBrowseInfo(SystemTypes.None, string.Empty, 0, 0);
        }

        public Icon Icon { get; private set; }

        public SystemTypes SystemType
        {
            get { return _systemType; }
            set
            {
                if (_systemType == value) return;
                _systemType = value;

                EditorBuilder value1;
                if (DesignMode == false && _systemType != SystemTypes.None
                    && EditorFactory.Builders.TryGetValue(_systemType, out value1))
                    Icon = value1.Icon;
                else
                    Icon = null;

                Tag = new EditorBrowseInfo(_systemType, string.Empty, 0, 0);
                Text = string.Empty;
            }
        }

        public void Clear()
        {
            Text = string.Empty;
            Tag = new EditorBrowseInfo(_systemType, string.Empty, 0, 0);
        }

        protected override void OnLinkClicked(LinkLabelLinkClickedEventArgs e)
        {
            if (e == null)
                throw new ArgumentNullException(nameof(e), Resources.NullParameterErrorMessage);

            base.OnLinkClicked(e);

            var browseInfo = Tag as EditorBrowseInfo;
            if (browseInfo != null && browseInfo.Id > 0)
                Program.MainForm.OpenTab(browseInfo, false, false);
        }

        protected override void OnDoubleClick(EventArgs e)
        {
            if (e == null)
                throw new ArgumentNullException(nameof(e), Resources.NullParameterErrorMessage);

            Tag = new EditorBrowseInfo(_systemType, string.Empty, 0, 0);
            Text = string.Empty;
            base.OnDoubleClick(e);
        }

        protected override void OnDragOver(DragEventArgs e)
        {
            if (e == null)
                throw new ArgumentNullException(nameof(e), Resources.NullParameterErrorMessage);

            this.ProcessLinkDrag(e, false);
            base.OnDragOver(e);
        }

        protected override void OnDragDrop(DragEventArgs e)
        {
            if (e == null)
                throw new ArgumentNullException(nameof(e), Resources.NullParameterErrorMessage);

            this.ProcessLinkDrag(e, true);
            base.OnDragDrop(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (e == null)
                throw new ArgumentNullException(nameof(e), Resources.NullParameterErrorMessage);

            base.OnPaint(e);

            if (Icon == null) return;
            const int iconDrawSize = 16;
            e.Graphics.DrawIcon(Icon, new Rectangle(e.ClipRectangle.Left + 2,
                e.ClipRectangle.Top + (e.ClipRectangle.Height - iconDrawSize) / 2, iconDrawSize, iconDrawSize));
        }
    }
}
