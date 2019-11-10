using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;
using Realm.DAL.Enumerations;
using Realm.Edit.Editor;
using Realm.Library.Common;

namespace Realm.Edit.Extensions
{
    public static class LinkLabelExtensions
    {
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
        public static void Setup(this LinkLabel value, SystemTypes systemType, int key)
        {
            Validation.IsNotNull(value, "value");

            if (key > 0)
            {
                var browseInfo = EditorFactory.GetBrowseInfo(systemType, key);
                value.Tag = browseInfo;
                value.Text = browseInfo.Name;
            }
            else
            {
                value.Tag = new EditorBrowseInfo((short)systemType, string.Empty, 0, 0);
                value.Text = string.Empty;
            }
        }

        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
        public static int GetContentId(this LinkLabel value)
        {
            Validation.IsNotNull(value, "value");

            var browseInfo = value.Tag as EditorBrowseInfo;
            return browseInfo != null && browseInfo.Id > 0 ? browseInfo.Id : 0;
        }
    }
}
