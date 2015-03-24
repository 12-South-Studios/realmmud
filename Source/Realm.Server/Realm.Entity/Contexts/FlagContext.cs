using System.Collections.Generic;
using System.Linq;
using Realm.Library.Common;

namespace Realm.Entity.Contexts
{
    /// <summary>
    ///
    /// </summary>
    public class FlagContext : BaseContext<IEntity>, IFlagContext
    {
        private readonly List<string> _flags = new List<string>();

        /// <summary>
        ///
        /// </summary>
        /// <param name="owner"></param>
        public FlagContext(IEntity owner)
            : base(owner)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="aFlag"></param>
        /// <returns></returns>
        public bool HasFlag(string aFlag)
        {
            return _flags.Contains(aFlag);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="aFlag"></param>
        /// <returns></returns>
        public bool SetFlag(string aFlag)
        {
            var returnVal = false;

            if (!HasFlag(aFlag))
            {
                _flags.Add(aFlag);
                returnVal = true;
            }

            return returnVal;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="aFlag"></param>
        /// <returns></returns>
        public bool UnsetFlag(string aFlag)
        {
            return HasFlag(aFlag) && _flags.Remove(aFlag);
        }

        /// <summary>
        ///
        /// </summary>
        public string Flags
        {
            get { return _flags.Aggregate(string.Empty, (current, flag) => current + flag); }
        }

        /// <summary>
        ///
        /// </summary>
        public IEnumerable<string> FlagList
        {
            get { return _flags; }
            set
            {
                foreach (var flag in value)
                    SetFlag(flag);
            }
        }
    }
}