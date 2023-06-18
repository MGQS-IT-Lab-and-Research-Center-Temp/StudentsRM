using StudentsRM.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StudentsRM.Context.EntityConfiguration
{
    public class StudentEntityConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students");

			builder.HasKey(s => s.Id);

			builder.Property(s => s.FirstName)
				.IsRequired()
				.HasMaxLength(15);
            
            builder.Property(s => s.MiddleName)
				.IsRequired()
				.HasMaxLength(15);
            
            builder.Property(s => s.LastName)
				.IsRequired()
				.HasMaxLength(15);

			builder.Property(s => s.Email)
				.IsRequired();
            
            builder.Property(s => s.HomeAddress)
				.IsRequired();

			builder.HasOne(s => s.Course)
                 .WithMany(c => c.Student)
                 .HasForeignKey(s => s.CourseId);
                 
        }
    }
}