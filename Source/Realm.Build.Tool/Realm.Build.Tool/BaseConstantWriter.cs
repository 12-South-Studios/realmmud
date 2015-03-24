using System.IO;

namespace Realm.Build.Tool
{
    public abstract class BaseConstantWriter 
    {
        protected StreamWriter Stream { get; private set; }

        protected BaseConstantWriter(string value)
        {
            Stream = new StreamWriter(value, false) { AutoFlush = true };
        }

        public void Close()
        {
            if (Stream != null)
                Stream.Dispose();
        }
    }
}
