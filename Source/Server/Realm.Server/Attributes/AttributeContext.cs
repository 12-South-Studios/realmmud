using System.Collections.Generic;
using System.Linq;
using Realm.Entity;
using Realm.Library.Common;

namespace Realm.Server.Attributes
{
    /// <summary>
    /// 
    /// </summary>
    public class AttributeContext : BaseContext<IGameEntity>, IAttributeContext
    {
        private readonly List<GameAttribute> _attributes = new List<GameAttribute>();
 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="owner"></param>
        public AttributeContext(IGameEntity owner) : base(owner)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="attrib"></param>
        /// <returns></returns>
        public bool Add(GameAttribute attrib)
        {
            if (Contains(attrib.ID))
                return false;

            _attributes.Add(attrib);
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public GameAttribute Get(long id)
        {
            return _attributes.FirstOrDefault(x => x.ID == id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Contains(long id)
        {
            return _attributes.Any(x => x.ID == id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Remove(long id)
        {
            var attrib = Get(id);
            return attrib.IsNotNull() && _attributes.Remove(attrib);
        }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<GameAttribute> Attributes { get { return _attributes.AsEnumerable(); } } 
    }
}
