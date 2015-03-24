using Realm.Library.Common.Data;

// ReSharper disable CheckNamespace
namespace Realm.Data.Definitions
// ReSharper restore CheckNamespace
{
    public class ArchetypeAbilityDef : SubDefinition
    {
        public ArchetypeAbilityDef(long id, DictionaryAtom definition)
            : base(id, definition)
        {
        }

        public bool IsExempt { get { return Def.GetBool("IsExempt"); } }
    }
}