using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Practice.CleanArchitecture.Application.Common.Interfaces;
using Practice.CleanArchitecture.Application.Common.Services;
using Practice.CleanArchitecture.Infrastructure;
using Practice.CleanArchitecture.Infrastructure.BackgroundServices;
using Practice.CleanArchitecture.Infrastructure.Services;
using Practice.CleanArchitecture.Infrastructure.Settings;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.ConfigureDBContext();

        services.ConfigureEmailService(configuration);

        services.ConfigureHostedService();
    }

    private static void ConfigureDBContext(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(opptions =>
            opptions.UseInMemoryDatabase("CleanArchitectureDb"));

        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
    }

    private static void ConfigureEmailService(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<MailConfiguration>(configuration.GetSection(nameof(MailConfiguration)));

        services.AddTransient<ISendMailService, SendMailService>();
    }

    private static void ConfigureHostedService(this IServiceCollection services)
    {
        services.AddHostedService<TimedHostedService>();
    }
}