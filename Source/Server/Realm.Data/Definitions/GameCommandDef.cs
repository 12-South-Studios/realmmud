using System.Collections.Generic;
using System.Linq;
using Realm.Library.Common;
using Realm.Library.Common.Data;

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

        public Globals.Globals.LogActionTypes LogAction
        {
            get { return EnumerationExtensions.GetEnum<Globals.Globals.LogActionTypes>(Def.GetInt("LogActionTypeID")); }
        }

        public int TagSetID
        {
            get { return Def.GetInt("TagSetID"); }
        }

        public bool AdminOnly
        {
            get { return Globals.Globals.GameCommandBits.AdminOnly.HasBit(Def.GetInt("Bits")); }
        }

        public bool WizardOnly
        {
            get { return Globals.Globals.GameCommandBits.WizardOnly.HasBit(Def.GetInt("Bits")); }
        }

        public IEnumerable<string> Keywords
        {
            get { return Def.GetString("Keywords").Split(':').ToList(); }
        }

        public IEnumerable<Atom> Positions
        {
            get { return Def.GetAtom<ListAtom>("Positions"); }
        }

        public IEnumerable<Atom> UserStates
        {
            get { return Def.GetAtom<ListAtom>("UserStates"); }
        }
    }
}