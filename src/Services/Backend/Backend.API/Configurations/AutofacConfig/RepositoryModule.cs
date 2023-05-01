using Backend.Infrastructure.Repositories;
using Module = Autofac.Module;
using Shared.Domain.Interfaces.Repositories;
using Backend.Infrastructure.Services;
using Shared.Domain.Interfaces.Services;
using Backend.Domain.Interfaces.Services;
using backend.Infrastructure.Services;

namespace Backend.API.Configurations.AutofacConfig;

public class RepositoryModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterGeneric(typeof(EfRepository<>))
            .As(typeof(IRepository<>));

        builder.RegisterGeneric(typeof(EfRepository<>))
            .As(typeof(IReadRepository<>));

        builder.RegisterType<NotificationService>()
            .As<INotificationService>()
            .InstancePerLifetimeScope();
        
        builder.RegisterType<ExportExcelService>()
            .As<IExportExcelService>()
            .InstancePerLifetimeScope();
    }
}