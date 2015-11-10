using System;

namespace Realm.Library.Common.Exceptions
{
    public class NoCustomAttributeFoundException : Exception
    {
        public NoCustomAttributeFoundException(string message, params object[] args)
            : base(string.Format(message, args))
        {
        }
    }
}
