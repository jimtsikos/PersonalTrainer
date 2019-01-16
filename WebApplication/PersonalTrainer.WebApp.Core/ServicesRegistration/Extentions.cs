using Extensions.Enumarations;
using Microsoft.Extensions.DependencyInjection;

namespace PersonalTrainer.WebApp.Core.ServicesRegistration
{
    public class Extentions
    {
        public static IServiceCollection Resolve(IServiceCollection services)
        {
            services.AddScoped<IEnumService, EnumService>();

            return services;
        }
    }
}
