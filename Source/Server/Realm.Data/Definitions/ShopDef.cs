using System.Collections.Generic;
using Realm.Library.Common;
using Realm.Library.Common.Data;

namespace Realm.Data.Definitions
{
    /// <summary>
    ///
    /// </summary>
    public class ShopDef : Definition
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="definition"></param>
        public ShopDef(long id, string name, DictionaryAtom definition)
            : base(id, name, definition)
        {
        }

        public int BuyMarkup
        {
            get { return Def.GetInt("BuyMarkup"); }
        }

        public int SellMarkup
        {
            get { return Def.GetInt("SellMarkup"); }
        }

        public Globals.Globals.ShopTypes ShopType
        {
            get { return EnumerationExtensions.GetEnum<Globals.Globals.ShopTypes>(Def.GetInt("ShopTypeID")); }
        }

        public int Bits { get { return Def.GetInt("Bits"); } }

        public IEnumerable<Atom> BuyTypes
        {
            get { return Def.GetAtom<ListAtom>("BuyTypes"); }
        }

        public IEnumerable<Atom> Primitives
        {
            get { return Def.GetAtom<ListAtom>("Primitives"); }
        }
    }
}