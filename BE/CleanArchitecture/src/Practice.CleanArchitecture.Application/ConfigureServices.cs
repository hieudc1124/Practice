using System.Reflection;
using FluentValidation;
using MediatR;
using Practice.CleanArchitecture.Application.Common.Behaviours;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        var aseemblies = Assembly.GetExecutingAssembly();

        services.AddAutoMapper(aseemblies);
        services.AddValidatorsFromAssembly(aseemblies);
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(aseemblies);
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        });

    }
}
