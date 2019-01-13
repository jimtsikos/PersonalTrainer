using DAL.DALConfiguration;
using DomainModel.TrainersImpl;
using Microsoft.EntityFrameworkCore;

namespace DAL.DAL
{
    public class TrainersContext : DbContext, ITrainersContext
    {
        public DbSet<Trainer> Trainers { get; set; }
        //TODO: public DbSet<Student> Students { get; set; }
        //TODO: public DbSet<StudentWeight> StudentWeights { get; set; }
        //TODO: public DbSet<Lesson> Lessons { get; set; }

        public TrainersContext(DbContextOptions<TrainersContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TrainerConfiguration());
            //TODO: modelBuilder.ApplyConfiguration(new StudentConfiguration());
            //TODO: modelBuilder.ApplyConfiguration(new StudentWeightConfiguration());
            //TODO: modelBuilder.ApplyConfiguration(new LessonConfiguration());
        }
    }
}
