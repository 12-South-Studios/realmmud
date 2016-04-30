using Realm.Data;

namespace Realm.Server.Attributes
{
    /// <summary>
    /// 
    /// </summary>
    public class StatAttribute : GameAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="type"></param>
        public StatAttribute(long id, string name, Globals.Statistics type)
            : base(id, name)
        {
            Type = type;
        }

        /// <summary>
        /// 
        /// </summary>
        public Globals.Statistics Type { get; private set; }
    }
}
