using Realm.Library.Common.Data;

// ReSharper disable CheckNamespace
namespace Realm.Data.Definitions
// ReSharper restore CheckNamespace
{
    public class AbilityReagantDef : SubDefinition
    {
        public AbilityReagantDef(long id, DictionaryAtom definition)
            : base(id, definition)
        {
        }

        public int ItemID { get { return Def.GetInt("ItemID"); } }

        public int Quantity { get { return Def.GetInt("Quantity"); } }
    }
}