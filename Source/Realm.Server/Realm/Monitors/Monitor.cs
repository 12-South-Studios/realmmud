using System.Timers;
using System.Windows.Controls;
using Realm.Library.Common.Logging;

namespace Realm.Monitors
{
    public abstract class Monitor<T> : IMonitor
    {
        public delegate void OnMonitorEvent(MonitorEventArgs<T> args);

        public Control Control { get; private set; }
        public ILogWrapper LogWrapper { get; private set; }

        public Monitor(Control control, ILogWrapper logger)
        {
            Control = control;
            LogWrapper = logger;
        }

        public abstract void OnTimerElapsed(object sender, ElapsedEventArgs e);
    }
}
