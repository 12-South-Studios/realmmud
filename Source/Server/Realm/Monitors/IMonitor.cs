using System.Timers;
using System.Windows.Controls;
using Realm.Library.Common.Logging;

namespace Realm.Monitors
{
    public interface IMonitor
    {
        Control Control { get; }
        ILogWrapper LogWrapper { get; }
        void OnTimerElapsed(object sender, ElapsedEventArgs e);
    }
}
