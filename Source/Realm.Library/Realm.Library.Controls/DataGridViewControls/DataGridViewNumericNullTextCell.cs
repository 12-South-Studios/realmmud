// ReSharper disable CheckNamespace
namespace Realm.Library.Controls
// ReSharper restore CheckNamespace
{
    /// <summary>
    ///
    /// </summary>
    public class DataGridViewNumericNullTextCell : DataGridViewNumericTextCell
    {
        /// <summary>
        ///
        /// </summary>
        public override object DefaultNewRowValue { get { return null; } }
    }
}