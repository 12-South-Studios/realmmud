using System;
using System.Windows.Forms;

namespace Realm.Edit.Extensions
{
    public static class DataGridViewExtensions
    {
        public static T CreateDataGridControls<T, TK>(this DataGridView gridView, string name, string headerText,
            int fillWeight = 10)
            where T : DataGridViewColumn
            where TK : DataGridViewCell
        {
            try
            {
                DataGridViewColumn column = Activator.CreateInstance<T>();
                column.Name = name;
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                column.FillWeight = fillWeight;
                column.HeaderText = headerText;
                column.CellTemplate = Activator.CreateInstance<TK>();
                column.ReadOnly = false;

                gridView.Columns.Add(column);
                return (T) column;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
