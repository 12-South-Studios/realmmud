using Realm.DAL.Common;
using Realm.Library.Controls;

namespace Realm.Edit.Editor
{
    public class EditorBrowseInfo : IBrowseInfo
    {
        public SystemTypes SystemType { get; private set; }
        public string Name { get; private set; }
        public int ClassId { get; private set; }
        public int Id { get; set; }
        public int SubId { get; private set; }

        public EditorBrowseInfo(SystemTypes systemType, string name, int classId, int id)
        {
            Init(systemType, name, classId, id, 0);
        }

        public EditorBrowseInfo(SystemTypes systemType, string name, int classId, int id, int subId)
        {
            Init(systemType, name, classId, id, subId);
        }

        public override string ToString()
        {
            return Name;
        }

        private void Init(SystemTypes type, string name, int classId, int id, int subId)
        {
            SystemType = type;
            Name = name;
            ClassId = classId;
            Id = id;
            SubId = subId;
        }
    }
}
