using System.ServiceProcess;
using System.Timers;
using System.Windows.Controls;
using Realm.Library.Common.Logging;

namespace Realm.Monitors
{
    public class ServerServiceStatusMonitor : Monitor<ServiceControllerStatus>
    {
        private readonly ServiceController _controller;
        
        public ServerServiceStatusMonitor(Control control, ILogWrapper logger, ServiceController controller) 
            : base(control, logger)
        {
            _controller = controller;
        }

        private void UpdateServerServiceStatus(MonitorEventArgs<ServiceControllerStatus> args)
        {
            LogWrapper.ErrorFormat("ServerService {0} has status {1}", _controller.ServiceName, args.Package.ToString());

            // TODO: Update a label on the main form

            if (args.Package == ServiceControllerStatus.Stopped)
                _controller.Start();
        }

        public override void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            var del = new OnMonitorEvent(UpdateServerServiceStatus);
            del.DynamicInvoke(_controller.Status);
        }
    }
}
