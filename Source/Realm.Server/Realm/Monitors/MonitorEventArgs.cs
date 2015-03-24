using System;

namespace Realm.Monitors
{
    public class MonitorEventArgs<T> : EventArgs
    {
        public T Package { get; set; }
    }
}
