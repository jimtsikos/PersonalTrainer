using Base.Domain;
using Base.DomainImpl;
using DomainModel.Lesson;
using DomainModel.LessonImpl;
using DomainModel.Students;
using DomainModel.StudentsImpl;
using DomainModel.StudentWeights;
using DomainModel.StudentWeightsImpl;
using DomainModel.Trainers;
using DomainModel.TrainersImpl;
using Infrastructure.Trainers;
using Microsoft.Extensions.DependencyInjection;

namespace PersonalTrainer.WebApp.Core.ServicesRegistration
{
    public class DomainModelLayer
    {
        public static IServiceCollection Resolve(IServiceCollection services)
        {
            services.AddScoped<ITrainer, Trainer>();
            services.AddScoped<ITrainerRepository, TrainerRepository>();
            services.AddScoped<IHandles<TrainerCreated>, DomainEventHandle<TrainerCreated>>();
            services.AddScoped<IHandles<TrainerUpdated>, DomainEventHandle<TrainerUpdated>>();

            services.AddScoped<IStudent, Student>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IHandles<StudentCreated>, DomainEventHandle<StudentCreated>>();
            
            services.AddScoped<IStudentWeight, StudentWeight>();
            services.AddScoped<IStudentWeightRepository, StudentWeightRepository>();
            services.AddScoped<IHandles<StudentWeightCreated>, DomainEventHandle<StudentWeightCreated>>();

            services.AddScoped<ILesson, Lesson>();
            services.AddScoped<ILessonRepository, LessonRepository>();
            services.AddScoped<IHandles<LessonCreated>, DomainEventHandle<LessonCreated>>();

            return services;
        }
    }
}
