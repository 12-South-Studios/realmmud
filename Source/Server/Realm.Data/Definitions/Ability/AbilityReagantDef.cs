using Realm.Data.Definitions.Common;
using Realm.Library.Common.Data;

namespace Realm.Data.Definitions.Ability

{
    public class AbilityReagantDef : SubDefinition
    {
        public AbilityReagantDef(long id, DictionaryAtom definition)
            : base(id, definition)
        {
        }

        public int ItemID => Def.GetInt("ItemID");

        public int Quantity => Def.GetInt("Quantity");
    }
}