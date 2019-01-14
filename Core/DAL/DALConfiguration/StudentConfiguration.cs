using DomainModel.StudentsImpl;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.DALConfiguration
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(500);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(500);
            builder.Property(x => x.Height).IsRequired();
            builder.Property(x => x.PayRate).IsRequired();
            builder.Property(x => x.PrepaidMoney).IsRequired();
            builder.Property(x => x.CreatedAt).IsRequired();
            builder.Property(x => x.UpdatedAt).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();

            builder.HasMany(x => x.StudentWeights).WithOne();
            //builder.HasMany(x => x.Lessons);
        }
    }
}
