using Realm.DAL.Enumerations;
using Realm.Library.Common.Extensions;
using Realm.Library.Controls;

namespace Realm.Edit.Editor
{
    public class EditorBrowseInfo : IBrowseInfo
    {
        public short SystemType { get; private set; }
        public string Name { get; private set; }
        public int ClassId { get; private set; }
        public int Id { get; set; }
        public int SubId { get; private set; }

        public SystemTypes GetSystemType()
        {
            return EnumerationExtensions.GetEnum<SystemTypes>(SystemType);
        }

        public EditorBrowseInfo(SystemTypes aType, string aName, int aClassId, int aId)
        {
            Init((short)aType, aName, aClassId, aId, 0);
        }

        public EditorBrowseInfo(short aType, string aName, int aClassId, int aId)
        {
            Init(aType, aName, aClassId, aId, 0);
        }

        public EditorBrowseInfo(SystemTypes aType, string aName, int aClassId, int aId, int aSubId)
        {
            Init((short)aType, aName, aClassId, aId, aSubId);
        }

        public EditorBrowseInfo(short aType, string aName, int aClassId, int aId, int aSubId)
        {
            Init(aType, aName, aClassId, aId, aSubId);
        }

        public override string ToString()
        {
            return Name;
        }

        private void Init(short aType, string aName, int aClassId, int aId, int aSubId)
        {
            SystemType = aType;
            Name = aName;
            ClassId = aClassId;
            Id = aId;
            SubId = aSubId;
        }
    }
}
