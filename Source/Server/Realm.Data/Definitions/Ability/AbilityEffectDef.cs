using Realm.Library.Common;
using Realm.Library.Common.Data;

// ReSharper disable CheckNamespace
namespace Realm.Data.Definitions
// ReSharper restore CheckNamespace
{
    public class AbilityEffectDef : SubDefinition
    {
        public AbilityEffectDef(long id, DictionaryAtom definition)
            : base(id, definition)
        {
        }

        public int EffectID { get { return Def.GetInt("EffectID"); } }

        public Globals.Globals.TargetClassTypes TargetClass
        {
            get
            {
                return
                    EnumerationExtensions.GetEnum<Globals.Globals.TargetClassTypes>(
                        Def.GetInt("TargetClassTypeID"));
            }
        }

        public int MaxNumber { get { return Def.GetInt("MaxNumber"); } }
    }
}