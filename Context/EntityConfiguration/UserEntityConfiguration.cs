using StudentsRM.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StudentsRM.Context.EntityConfiguration
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
			builder.ToTable("Users");

			builder.HasKey(u => u.Id);

			builder.Property(u => u.Email)
				.IsRequired();

			builder.Property(u => u.RoleId)
				.IsRequired();

			builder.HasOne(u => u.Role)
				.WithMany(r => r.Users)
				.HasForeignKey(u => u.RoleId);
		}
    }
}