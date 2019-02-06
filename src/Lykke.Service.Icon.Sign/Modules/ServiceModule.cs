using Autofac;
using Lykke.Service.Icon.Sign.Core.Services;
using Lykke.Service.Icon.Sign.Services;

namespace Lykke.Service.Icon.Sign.Modules
{
    public class ServiceModule : Module
    {

        public ServiceModule()
        {
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<HealthService>()
                .As<IHealthService>()
                .SingleInstance();

            builder.RegisterType<StartupManager>()
                .As<IStartupManager>();

            builder.RegisterType<ShutdownManager>()
                .As<IShutdownManager>();

            builder.RegisterType<IconSignService>()
                   .As<IIconSignService>()
                   .SingleInstance();
        }
    }
}
