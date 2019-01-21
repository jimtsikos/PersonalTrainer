using Autofac;
using DAL.DAL;
using DomainModel.Lesson;
using DomainModel.Students;
using DomainModel.StudentWeights;
using DomainModel.Trainers;
using Infrastructure.Trainers;

namespace Application.Registrer
{
    public class InfrastructureLayerModule : Autofac.Module
    {
        public InfrastructureLayerModule()
        {

        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TrainersContext>().As<ITrainersContext>().InstancePerLifetimeScope();
            builder.RegisterType<TrainerRepository>().As<ITrainerRepository>().InstancePerLifetimeScope();
            builder.RegisterType<StudentRepository>().As<IStudentRepository>().InstancePerLifetimeScope();
            builder.RegisterType<StudentWeightRepository>().As<IStudentWeightRepository>().InstancePerLifetimeScope();
            builder.RegisterType<LessonRepository>().As<ILessonRepository>().InstancePerLifetimeScope();
        }
    }
}
