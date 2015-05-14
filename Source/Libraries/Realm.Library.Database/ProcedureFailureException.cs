using System;
using System.Runtime.Serialization;

namespace Realm.Library.Database
{
    /// <summary>
    ///
    /// </summary>
    [Serializable]
    public class ProcedureFailureException : Exception
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected ProcedureFailureException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        ///
        /// </summary>
        public ProcedureFailureException()
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="msg"></param>
        public ProcedureFailureException(string msg)
            : base(msg)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="ex"></param>
        public ProcedureFailureException(string msg, Exception ex)
            : base(msg, ex)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="args"></param>
        public ProcedureFailureException(string msg, params object[] args)
            : base(string.Format(msg, args))
        {
        }
    }
}