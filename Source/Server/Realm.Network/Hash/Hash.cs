using Realm.Library.Common.Objects;

namespace Realm.Network.Hash
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class Hash : Cell
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        public Hash(long id, string value)
        {
            ID = id;
            Name = value;
        }
    }
}