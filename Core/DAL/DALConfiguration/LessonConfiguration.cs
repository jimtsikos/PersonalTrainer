using DomainModel.LessonImpl;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.DALConfiguration
{
    public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
    {
        public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.DateTime).IsRequired();
            builder.Property(x => x.Hour).IsRequired();
            builder.Property(x => x.Minutes).IsRequired();
            builder.Property(x => x.IsPaid).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.CreatedAt).IsRequired();
            builder.Property(x => x.UpdatedAt).IsRequired();

            builder.HasOne(x => x.Trainer)
                   .WithMany(x => x.Lessons)
                   .HasForeignKey(x => x.TrainerId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Student)
                    .WithMany(x => x.Lessons)
                    .HasForeignKey(x => x.StudentId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
