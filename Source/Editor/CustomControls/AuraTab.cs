using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Realm.Edit.Properties;

namespace Realm.Edit.CustomControls
{
    public class AuraTab : TabControl
    {
        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (e == null)
                throw new ArgumentNullException("e", Resources.NullParameterErrorMessage);

            if (e.Button != MouseButtons.Right) return;
            var p = e.Location;
            for (var i = 0; i < TabCount; i++)
            {
                var r = GetTabRect(i);
                if (r.Contains(p))
                    CloseTab(i);
            }
        }

        private void CloseTab( int tabIndex )
        {
            var pageList = new List<TabPage>();
            
            // If shift is down, delete all but i
            // Otherwise, just delete i
            if (ModifierKeys == Keys.Shift)
            {
                for ( var i=0; i < TabCount; ++i )
                {
                    if (i != tabIndex)
                        pageList.Add(TabPages[i]);
                }
            }
            else
                pageList.Add(TabPages[tabIndex]);

            Program.MainForm.CloseTabs(pageList, true);
        }
    }
}
