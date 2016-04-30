using System.Collections.Generic;
using Realm.Library.Common.Data;
using Realm.Library.Common.Extensions;

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

        public int BuyMarkup => Def.GetInt("BuyMarkup");

        public int SellMarkup => Def.GetInt("SellMarkup");

        public Globals.ShopTypes ShopType => EnumerationExtensions.GetEnum<Globals.ShopTypes>(Def.GetInt("ShopTypeID"));

        public int Bits => Def.GetInt("Bits");

        public IEnumerable<Atom> BuyTypes => Def.GetAtom<ListAtom>("BuyTypes");

        public IEnumerable<Atom> Primitives => Def.GetAtom<ListAtom>("Primitives");
    }
}