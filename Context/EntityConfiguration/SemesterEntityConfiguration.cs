using StudentsRM.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace StudentsRM.Context.EntityConfiguration
{
    public class SemesterEntityConfiguration : IEntityTypeConfiguration<Semester>
    {
        public void Configure(EntityTypeBuilder<Semester> builder)
        {
            builder.ToTable("Semesters");

			builder.HasKey(s => s.Id);

			builder.Property(s => s.SemesterName)
				.IsRequired()
				.HasMaxLength(15);
            
            builder.Property(s => s.StartDate)
				.IsRequired();
            
            builder.Property(s => s.EndDate)
				.IsRequired();
        }
    }
}