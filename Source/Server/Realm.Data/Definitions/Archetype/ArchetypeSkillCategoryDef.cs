using Realm.Data.Definitions.Common;
using Realm.Library.Common.Data;

namespace Realm.Data.Definitions.Archetype

{
    public class ArchetypeSkillCategoryDef : SubDefinition
    {
        public ArchetypeSkillCategoryDef(long id, DictionaryAtom definition)
            : base(id, definition)
        {
        }

        public int SkillCategoryID => Def.GetInt("SkillCategoryID");

        public bool IsPreferred => Def.GetBool("IsPreferred");

        public bool IsRestricted => Def.GetBool("IsRestricted");
    }
}