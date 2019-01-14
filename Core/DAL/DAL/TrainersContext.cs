using DAL.DALConfiguration;
using DomainModel.LessonImpl;
using DomainModel.StudentsImpl;
using DomainModel.StudentWeightsImpl;
using DomainModel.TrainersImpl;
using Microsoft.EntityFrameworkCore;

namespace DAL.DAL
{
    public class TrainersContext : DbContext, ITrainersContext
    {
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentWeight> StudentWeights { get; set; }
        public DbSet<Lesson> Lessons { get; set; }

        public TrainersContext(DbContextOptions<TrainersContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TrainerConfiguration());
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new StudentWeightConfiguration());
            modelBuilder.ApplyConfiguration(new LessonConfiguration());
        }
    }
}
