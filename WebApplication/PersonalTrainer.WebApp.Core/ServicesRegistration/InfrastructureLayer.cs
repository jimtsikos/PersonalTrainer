﻿using DAL.DAL;
using Microsoft.Extensions.DependencyInjection;

namespace PersonalTrainer.WebApp.Core.ServicesRegistration
{
    public class InfrastructureLayer
    {
        public static IServiceCollection Resolve(IServiceCollection services)
        {
            services.AddScoped<ITrainersContext, TrainersContext>();

            return services;
        }
    }
}