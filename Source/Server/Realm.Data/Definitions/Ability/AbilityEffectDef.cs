using Realm.Data.Definitions.Common;
using Realm.Library.Common.Data;
using Realm.Library.Common.Extensions;

namespace Realm.Data.Definitions.Ability

{
    public class AbilityEffectDef : SubDefinition
    {
        public AbilityEffectDef(long id, DictionaryAtom definition)
            : base(id, definition)
        {
        }

        public int EffectID => Def.GetInt("EffectID");

        public Globals.TargetClassTypes TargetClass => EnumerationExtensions.GetEnum<Globals.TargetClassTypes>(
            Def.GetInt("TargetClassTypeID"));

        public int MaxNumber => Def.GetInt("MaxNumber");
    }
}