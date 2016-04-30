using System;
using Realm.Library.Common.Exceptions;

namespace Realm.Pathing
{
    public class InvalidPathException : BaseException
    {
        public InvalidPathException(string message) : base(message) { }

        public InvalidPathException(string message, Exception innerException) : base(message, innerException) { }
    }
}
