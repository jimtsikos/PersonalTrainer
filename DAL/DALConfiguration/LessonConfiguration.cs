using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.DALConfiguration
{
    public class LessonConfiguration //: IEntityTypeConfiguration<Lesson>
    {
        //public void Configure(EntityTypeBuilder<Lesson> builder)
        //{
        //    builder.HasKey(x => x.Id);
        //    builder.Property(x => x.DateTime).IsRequired();
        //    builder.Property(x => x.Hour).IsRequired().HasColumnType("integer");
        //    builder.Property(x => x.Minutes).IsRequired().HasColumnType("integer");
        //    builder.Property(x => x.IsPaid).IsRequired();
        //    builder.Property(x => x.IsActive).IsRequired();
        //    builder.Property(x => x.CreatedAt).IsRequired();
        //    builder.Property(x => x.UpdatedAt).IsRequired();

        //    builder.HasOne(x => x.Student).WithMany().IsRequired().HasForeignKey(x => x.StudentForeignKey);
        //    builder.HasOne(x => x.Trainer).WithMany().IsRequired().HasForeignKey(x => x.TrainerForeignKey);

        //    builder.HasIndex(x => new { x.StudentForeignKey, x.DateTime, x.Hour, x.Minutes }).IsUnique();
        //}
    }
}
