using Microsoft.AspNetCore.Mvc;
using ZymLabs.NSwag.FluentValidation;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static void AddWebUIServices(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();

        services.AddControllers();
        
        services.AddRazorPages();
       
        // Customise default API behaviour
        services.Configure<ApiBehaviorOptions>(options =>
            options.SuppressModelStateInvalidFilter = true);
    }
}
