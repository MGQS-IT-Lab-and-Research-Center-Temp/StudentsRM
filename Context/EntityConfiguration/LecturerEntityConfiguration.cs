using StudentsRM.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StudentsRM.Context.EntityConfiguration
{
    public class LecturerEntityConfiguration : IEntityTypeConfiguration<Lecturer>
    {
        public void Configure(EntityTypeBuilder<Lecturer> builder)
        {
            builder.ToTable("Lecturers");

			builder.HasKey(l => l.Id);

			builder.Property(l => l.FirstName)
				.IsRequired()
				.HasMaxLength(15);
            
            builder.Property(l => l.MiddleName)
				.IsRequired()
				.HasMaxLength(15);
            
            builder.Property(l => l.LastName)
				.IsRequired()
				.HasMaxLength(15);

			builder.Property(l => l.Email)
				.IsRequired();
            
            builder.Property(l => l.HomeAddress)
				.IsRequired();

			builder.HasOne(l => l.Course)
                .WithOne(c => c.Lecturer);
        }
    }
}