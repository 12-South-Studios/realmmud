using System;
using System.Timers;
using System.Windows.Controls;
using Realm.Library.Common.Logging;

namespace Realm.Monitors
{
    public class ServerTimeMonitor : Monitor<TimeSpan>
    {
        private readonly DateTime _startTime;

        public ServerTimeMonitor(Control control, ILogWrapper logger) 
            : base(control, logger)
        {
            _startTime = DateTime.Now;
        }

        private void UpdateServerTimer(MonitorEventArgs<TimeSpan> args)
        {
            ((Label) Control).Content = string.Format(Properties.Resources.MSG_TIME_DISPLAY,
                                                       Convert.ToInt32(args.Package.TotalHours),
                                                       Convert.ToInt32(args.Package.TotalMinutes),
                                                       Convert.ToInt32(args.Package.TotalSeconds));
        }

        public override void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            var del = new OnMonitorEvent(UpdateServerTimer);
            del.DynamicInvoke(DateTime.Now.Subtract(_startTime));
        }
    }
}
