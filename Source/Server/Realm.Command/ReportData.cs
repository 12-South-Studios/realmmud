using Realm.Library.Common.Entities;

namespace Realm.Command
{
    public class ReportData
    {
        public IEntity Actor { get; set; }
        public IEntity Victim { get; set; }
        public object DirectObject { get; set; }
        public object IndirectObject { get; set; }
        public object Space { get; set; }
        public object Extra { get; set; }
    }
}