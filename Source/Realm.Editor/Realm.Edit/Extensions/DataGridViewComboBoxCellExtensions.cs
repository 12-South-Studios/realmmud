using System;
using System.Windows.Forms;
using Realm.Edit.Tags;

namespace Realm.Edit.Extensions
{
    public static class DataGridViewComboBoxCellExtensions
    {
        public static void Fill<T>(this DataGridViewComboBoxCell cell, int selectedId = 0)
        {
            var baseType = typeof(T).BaseType;
            if (baseType != null && baseType.Name != "Enum") return;

            cell.Items.Clear();

            var values = Enum.GetValues(typeof (T));
            var names = Enum.GetNames(typeof (T));

            for(int i=0; i<names.Length; i++)
            {
                var newTag = new TagInfo(names[i], (int) values.GetValue(i), (int) values.GetValue(i));
                cell.Items.Add(newTag);
                if (newTag.Id == selectedId)
                    cell.Value = newTag;
            }
        }
    }
}
