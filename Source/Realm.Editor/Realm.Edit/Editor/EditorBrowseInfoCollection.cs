using System;
using System.Collections.ObjectModel;
using Realm.Library.Common;
using Realm.Library.Controls;

namespace Realm.Edit.Editor
{
    public class EditorBrowseInfoCollection : KeyedCollection<Int64, IBrowseInfo>
    {
        protected override Int64 GetKeyForItem(IBrowseInfo value)
        {
            Validation.IsNotNull(value, "value");

            return value.Id;
        }
    }
}
