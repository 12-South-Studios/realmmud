using System;
using System.Collections.Generic;

namespace Realm.Edit
{
    public class StringValueTable
    {
        readonly IDictionary<int, String> _dictionary;

        public StringValueTable()
        {
            _dictionary = new Dictionary<int, String>();
        }
        public void AddString(int key, String value)
        {
            _dictionary[key] = value;
        }
        public String GetString(int key)
        {
            return _dictionary.ContainsKey(key) ? _dictionary[key] : null;
        }
        public IEnumerable<int> GetKeys()
        {
            return _dictionary.Keys;
        }
        public void Clear()
        {
            _dictionary.Clear();
        }
    }
}
