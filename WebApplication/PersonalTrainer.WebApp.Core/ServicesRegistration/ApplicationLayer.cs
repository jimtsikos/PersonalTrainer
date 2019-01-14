using Application.Lessons.Service;
using Application.Students.Service;
using Application.StudentWeights.Service;
using Application.Trainers.Service;
using Microsoft.Extensions.DependencyInjection;

namespace PersonalTrainer.WebApp.Core.ServicesRegistration
{
    public class ApplicationLayer
    {
        public static IServiceCollection Resolve(IServiceCollection services)
        {
            services.AddScoped<ITrainerService, TrainerService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IStudentWeightsService, StudentWeightsService>();
            services.AddScoped<ILessonService, LessonService>();

            return services;
        }
    }
}
