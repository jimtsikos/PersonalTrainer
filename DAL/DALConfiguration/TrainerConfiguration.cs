using DomainModel.TrainersImpl;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.DALConfiguration
{
    public class TrainerConfiguration : IEntityTypeConfiguration<Trainer>
    {
        public void Configure(EntityTypeBuilder<Trainer> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(500);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(500);
            builder.Property(x => x.PayRate).IsRequired();
            builder.Property(x => x.CreatedAt).IsRequired();
            builder.Property(x => x.UpdatedAt).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();

            //TODO: builder.HasMany(x => x.Lessons).WithOne();
        }
    }
}
