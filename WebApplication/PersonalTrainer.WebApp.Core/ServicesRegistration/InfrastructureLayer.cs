using Base.Repository;
using DAL.DAL;
using Infrastructure.Base;
using Microsoft.Extensions.DependencyInjection;

namespace PersonalTrainer.WebApp.Core.ServicesRegistration
{
    public class InfrastructureLayer
    {
        public static IServiceCollection Resolve(IServiceCollection services)
        {
            services.AddScoped<ITrainersContext, TrainersContext>();
            services.AddScoped<IDomainEventRepository, DomainEventRepository>();

            return services;
        }
    }
}