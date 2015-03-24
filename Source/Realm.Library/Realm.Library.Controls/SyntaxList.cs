using System.Collections.Generic;
using System.Drawing;

namespace Realm.Library.Controls
{
    /// <summary>
    /// Class to store syntax objects in.
    /// </summary>
    public class SyntaxList
    {
        /// <summary>
        ///
        /// </summary>
        public ICollection<string> RgList { get; private set; }

        /// <summary>
        ///
        /// </summary>
        public Color Color { get; set; }

        /// <summary>
        ///
        /// </summary>
        public SyntaxList()
        {
            RgList = new List<string>();
        }
    }
}