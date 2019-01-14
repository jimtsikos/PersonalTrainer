using DomainModel.LessonImpl;
using DomainModel.StudentsImpl;
using DomainModel.StudentWeightsImpl;
using DomainModel.TrainersImpl;
using Microsoft.EntityFrameworkCore;

namespace DAL.DAL
{
    public interface ITrainersContext
    {
        DbSet<Lesson> Lessons { get; set; }
        DbSet<Student> Students { get; set; }
        DbSet<StudentWeight> StudentWeights { get; set; }
        DbSet<Trainer> Trainers { get; set; }
    }
}
