using System.Collections.Generic;
using System.Linq;

namespace Realm.Build.Tool
{
    public class ConstantGroup
    {
        public ConstantGroup()
        {
            Values = new List<ConstantValue>();
        }

        public string ConstantName { get; set; }
        public string Prefix { get; set; }
        public string ConstantSource { get; set; }
        public string Comment { get; set; }
        public bool IsEnum { get; set; }
        public bool HasFlagsAttribute { get; set; }
        public bool SuppressCA1008 { get; set; }
        public IList<ConstantValue> Values { get; private set; }

        public void AddValue(ConstantValue value)
        {
            if (!Values.Contains(value))
                Values.Add(value);
        }

        public void AddRange(IEnumerable<ConstantValue> values)
        {
            foreach (var value in values.Where(value => value != null))
            {
                Values.Add(value);
            }
        }
    }
}
