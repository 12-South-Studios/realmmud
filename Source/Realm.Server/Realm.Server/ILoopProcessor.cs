using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realm.Server
{
    public interface ILoopProcessor
    {
        void Start();
        void Stop();
        bool IsRunning { get; }

    }
}
