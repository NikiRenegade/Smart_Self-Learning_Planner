using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartLearningPlanner.Domain.Entities;

namespace SmartLearningPlanner.Infrastructure.EntityFramework.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder) 
		{

        // Указываем таблицу, в которой будет храниться сущность
        builder.ToTable("Users");

        // Указываем первичный ключ
        builder.HasKey(u => u.Id);

				builder.Property(u => u.Name)
						.IsRequired()
						.HasMaxLength(64);

				builder.Property(u => u.Email)
						.IsRequired()
						.HasMaxLength(64);

				builder.Property(u => u.ProfilePictureUrl)
						.HasMaxLength(2048);
    }
}
