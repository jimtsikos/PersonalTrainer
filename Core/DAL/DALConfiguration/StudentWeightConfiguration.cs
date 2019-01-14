using DomainModel.StudentWeightsImpl;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.DALConfiguration
{
    public class StudentWeightConfiguration : IEntityTypeConfiguration<StudentWeight>
    {
        public void Configure(EntityTypeBuilder<StudentWeight> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Weight).IsRequired();
            builder.Property(x => x.CreatedAt).IsRequired();
            builder.Property(x => x.UpdatedAt).IsRequired();
            builder.HasOne(x => x.Student).WithMany();
        }
    }
}
