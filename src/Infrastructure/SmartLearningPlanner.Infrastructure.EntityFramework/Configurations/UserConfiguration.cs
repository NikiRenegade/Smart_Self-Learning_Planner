using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartLearningPlanner.Domain.Entities;

namespace SmartLearningPlanner.Infrastructure.EntityFramework.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
	public void Configure(EntityTypeBuilder<ApplicationUser> builder)
	{

		// Указываем таблицу, в которой будет храниться сущность
		builder.ToTable("Users");

		// Указываем первичный ключ
		builder.HasKey(u => u.Id);

		builder.Property(u => u.FirstName)
				.IsRequired()
				.HasMaxLength(64);

		builder.Property(u => u.LastName)
								.IsRequired()
								.HasMaxLength(64);

		builder.Property(u => u.Email)
				.IsRequired()
				.HasMaxLength(64);

		builder.Property(u => u.RefreshToken)
				.IsRequired(false)
				.HasMaxLength(256);

		builder.Property(u => u.RefreshTokenExpiryTime)
				.IsRequired(false);

		builder.HasMany(u => u.CreatedQuizzes)
				.WithOne(q => q.CreatedBy)
				.HasForeignKey(q => q.CreatedById)
				.OnDelete(DeleteBehavior.SetNull); // Удаление квиза не приводит к удалению пользователя
	}
}
