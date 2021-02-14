using Alpaca.Interfaces.Dispatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpaca.Plugins.Dispatch.OwnIntegration
{
    public class OwnIntegrationDispatchService : IDispatchService
    {
        public void ReloadConfig()
        {
            System.Diagnostics.Trace.WriteLine($"**{nameof(OwnIntegrationDispatchService)}**: ReloadConfig");
        }
    }
}
