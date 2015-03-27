using System;

using Autofac;

using BATSExchangeApi.Library.DataProvider;
using BATSExchangeApi.Library.Logging;

namespace BATSExchangeApi.WebService.Resolver
{
    public static class DependencyContainer
    {
        private static volatile IContainer _instance;
        private static readonly object SyncRoot = new Object();

        public static IContainer Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (SyncRoot)
                    {
                        if (_instance == null)
                        {
                            var builder = new ContainerBuilder();
                            builder.RegisterType<LogWrapper>().As<ILogWrapper>().SingleInstance();
                            builder.RegisterType<BATSProvider>().As<IBATSProvider>().SingleInstance();
                            _instance = builder.Build();
                        }
                    }
                }

                return _instance;
            }
        }
    }
}
