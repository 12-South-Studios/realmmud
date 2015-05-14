using Realm.Library.Common.Data;

// ReSharper disable CheckNamespace
namespace Realm.Data.Definitions
// ReSharper restore CheckNamespace
{
    public class ArchetypeSkillCategoryDef : SubDefinition
    {
        public ArchetypeSkillCategoryDef(long id, DictionaryAtom definition)
            : base(id, definition)
        {
        }

        public int SkillCategoryID { get { return Def.GetInt("SkillCategoryID"); } }

        public bool IsPreferred { get { return Def.GetBool("IsPreferred"); } }

        public bool IsRestricted { get { return Def.GetBool("IsRestricted"); } }
    }
}