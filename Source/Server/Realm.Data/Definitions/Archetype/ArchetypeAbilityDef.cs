using Realm.Data.Definitions.Common;
using Realm.Library.Common.Data;

namespace Realm.Data.Definitions.Archetype

{
    public class ArchetypeAbilityDef : SubDefinition
    {
        public ArchetypeAbilityDef(long id, DictionaryAtom definition)
            : base(id, definition)
        {
        }

        public bool IsExempt => Def.GetBool("IsExempt");
    }
}