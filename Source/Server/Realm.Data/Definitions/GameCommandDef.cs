using System.Collections.Generic;
using System.Linq;
using Realm.Library.Common.Data;
using Realm.Library.Common.Extensions;

namespace Realm.Data.Definitions
{
    /// <summary>
    /// Definition of an Command
    /// </summary>
    public class GameCommandDef : Definition
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public GameCommandDef(long id, string name, DictionaryAtom definition)
            : base(id, name, definition)
        {
        }

        public Globals.LogActionTypes LogAction => EnumerationExtensions.GetEnum<Globals.LogActionTypes>(Def.GetInt("LogActionTypeID"));

        public int TagSetID => Def.GetInt("TagSetID");

        public bool AdminOnly => Globals.GameCommandBits.AdminOnly.HasBit(Def.GetInt("Bits"));

        public bool WizardOnly => Globals.GameCommandBits.WizardOnly.HasBit(Def.GetInt("Bits"));

        public IEnumerable<string> Keywords => Def.GetString("Keywords").Split(':').ToList();

        public IEnumerable<Atom> Positions => Def.GetAtom<ListAtom>("Positions");

        public IEnumerable<Atom> UserStates => Def.GetAtom<ListAtom>("UserStates");
    }
}