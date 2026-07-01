using System;
using System.Runtime.Serialization;

namespace Realm.Library.Common.Exceptions

{
    /// <summary>
    ///
    /// </summary>
    [Serializable]
    public class InstanceNotFoundException : BaseException
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected InstanceNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        ///
        /// </summary>
        public InstanceNotFoundException()
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="msg"></param>
        public InstanceNotFoundException(string msg)
            : base(msg)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="ex"></param>
        public InstanceNotFoundException(string msg, Exception ex)
            : base(msg, ex)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="args"></param>
        public InstanceNotFoundException(string msg, params object[] args)
            : base(string.Format(msg, args))
        {
        }
    }
}
