using Application.Lessons.Service;
using Application.Students.Service;
using Application.StudentWeights.Service;
using Application.Trainers.Service;
using Autofac;

namespace Application.Registrer
{
    public class ApplicationLayerModule : Autofac.Module
    {
        public ApplicationLayerModule()
        {
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TrainerService>().As<ITrainerService>().InstancePerLifetimeScope();
            builder.RegisterType<StudentService>().As<IStudentService>().InstancePerLifetimeScope();
            builder.RegisterType<StudentWeightsService>().As<IStudentWeightsService>().InstancePerLifetimeScope();
            builder.RegisterType<LessonService>().As<ILessonService>().InstancePerLifetimeScope();
        }
    }
}