using Autofac;
using DomainModel.Lesson;
using DomainModel.LessonImpl;
using DomainModel.Students;
using DomainModel.StudentsImpl;
using DomainModel.StudentWeights;
using DomainModel.StudentWeightsImpl;
using DomainModel.Trainers;
using DomainModel.TrainersImpl;

namespace Application.Registrer
{
    public class DomainModelLayerModule : Autofac.Module
    {
        public DomainModelLayerModule()
        {
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Trainer>().As<ITrainer>().InstancePerLifetimeScope();
            builder.RegisterType<Student>().As<IStudent>().InstancePerLifetimeScope();
            builder.RegisterType<StudentWeight>().As<IStudentWeight>().InstancePerLifetimeScope();
            builder.RegisterType<Lesson>().As<ILesson>().InstancePerLifetimeScope();
        }
    }
}
