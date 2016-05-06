using System;
using System.Collections.Generic;

namespace Realm.Edit
{
    public class StringValueTable
    {
        readonly IDictionary<int, string> _dictionary;

        public StringValueTable()
        {
            _dictionary = new Dictionary<int, string>();
        }
        public void AddString(int key, string value)
        {
            _dictionary[key] = value;
        }
        public string GetString(int key)
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
