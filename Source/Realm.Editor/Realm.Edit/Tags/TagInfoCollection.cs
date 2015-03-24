using System;
using System.Collections.ObjectModel;
using Realm.Edit.Properties;

namespace Realm.Edit.Tags
{
    public class TagInfoCollection : KeyedCollection<int, TagInfo>
    {
        protected override int GetKeyForItem(TagInfo value)
        {
            if (value == null)
                throw new ArgumentNullException("value", Resources.NullParameterErrorMessage);

            return value.Id;
        }
    }
}
