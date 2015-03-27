using Funq;

using ServiceStack.Api.Swagger;
using ServiceStack.CacheAccess;
using ServiceStack.CacheAccess.Providers;
using ServiceStack.Common;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface.Admin;
using ServiceStack.WebHost.Endpoints;

namespace BATSExchangeApi.WebService
{
    public sealed class AppHost : AppHostBase
    {
        public AppHost()
            : base("BATS Exchange Service", typeof (BATSExchangeService).Assembly)
        {
            SetConfig(new EndpointHostConfig
            {
                EnableFeatures = Feature.All.Remove(Feature.Soap11 | Feature.Soap12),
                DebugMode = true,
                ReturnsInnerException = true,
                AdminAuthSecret = "batz"
            });
        }

        public override void Configure(Container container)
        {
            //requestlogs?authsecret=batz
            Plugins.Add(new RequestLogsFeature());

            //swagger-ui/index.html
            Plugins.Add(new SwaggerFeature());

            container.Register<ICacheClient>(new MemoryCacheClient());
        }
    }
}
