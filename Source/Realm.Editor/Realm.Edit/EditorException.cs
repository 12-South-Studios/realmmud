using System;
using System.Runtime.Serialization;

namespace Realm.Edit
{
    [Serializable]
    public class EditorException : Exception
    {
        protected EditorException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public EditorException()
        {
        }

        public EditorException(string message)
            : base(message)
        {
        }

        public EditorException(string message, Exception ex)
            : base(message, ex)
        {
        }
    }
}
