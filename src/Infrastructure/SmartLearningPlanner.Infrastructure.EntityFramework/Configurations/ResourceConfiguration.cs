using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartLearningPlanner.Domain.Entities;

namespace SmartLearningPlanner.Infrastructure.EntityFramework.Configurations;

public class ResourceConfiguration : IEntityTypeConfiguration<Resource>
{
    public void Configure(EntityTypeBuilder<Resource> builder)
    {
				// Указываем таблицу, в которой будет храниться сущность
        builder.ToTable("Resources");

				// Указываем первичный ключ
        builder.HasKey(r => r.Id);

				// Настройка свойств
        builder.Property(r => r.Description)
						.IsRequired() // Обязательное поле
						.HasMaxLength(512);
        builder.Property(r => r.Type)
						.IsRequired(); // Обязательное поле
        builder.Property(r => r.Url)
						.HasMaxLength(1024); // Максимальная длина
        builder.Property(r => r.LocalPath)
						.HasMaxLength(1024); // Максимальная длина
						
				// Установка связей		
        builder.HasOne<Roadmap>().WithMany(r => r.Resources)
						.HasForeignKey("RoadmapId")
						.OnDelete(DeleteBehavior.Cascade);
    }
}
