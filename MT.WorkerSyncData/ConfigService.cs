using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace MT.WorkerSyncData
{
    class ConfigService
    {
        internal static void Configure()
        {
            HostFactory.Run(configure =>
            {
                string serviceName = MT.Library.Utility.GetAppSettings<string>("ServiceName");
                string serviceDisplayName = MT.Library.Utility.GetAppSettings<string>("ServiceDisplayName");
                string serviceDescription = MT.Library.Utility.GetAppSettings<string>("ServiceDescription");
                configure.Service<MTJob>(service =>
                {
                    service.ConstructUsing(s => new MTJob());
                    service.WhenStarted(s => s.Start());
                    service.WhenStopped(s => s.Stop());
                });
                configure.RunAsLocalSystem();
                configure.SetServiceName(serviceName);
                configure.SetDisplayName(serviceDisplayName);
                configure.SetDescription(serviceDescription);
            });
        }
    }
}
