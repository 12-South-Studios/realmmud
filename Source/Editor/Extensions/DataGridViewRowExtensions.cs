using System;
using System.Windows.Forms;
using Realm.Edit.Properties;

namespace Realm.Edit.Extensions
{
    public static class DataGridViewRowExtensions
    {
        public static bool CanDelete(this DataGridViewRow value)
        {
            if (value == null)
                throw new ArgumentNullException("value", Resources.NullParameterErrorMessage);

            if (!(value.Tag is int)) return CanDeleteIfTagged(value);
            return (value.Tag != null && (int)value.Tag >= 0 && !value.IsNewRow);
        }

        public static bool CanDeleteIfTagged(this DataGridViewRow value)
        {
            if (value == null)
                throw new ArgumentNullException("value", Resources.NullParameterErrorMessage);

            return (value.Tag != null && !value.IsNewRow);
        }
    }
}
