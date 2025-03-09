using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartLearningPlanner.Domain.Entities;
namespace SmartLearningPlanner.Infrastructure.EntityFramework.Configurations;

public class MissionConfiguration : IEntityTypeConfiguration<Mission>
{
    public void Configure(EntityTypeBuilder<Mission> builder)
    {
				// Указываем таблицу, в которой будет храниться сущность
        builder.ToTable("Missions");

				// Указываем первичный ключ
				builder.HasKey(m => m.Id);

				// Настройка свойств
				builder.Property(m => m.Title)
						.IsRequired() // Обязательное поле
						.HasMaxLength(512); // Максимальная длина

				builder.Property(m => m.Description)
						.HasMaxLength(1024); // Максимальная длина
				
				builder.Property(m => m.IsCompleted)
						.IsRequired();
						
				// Установка связей		
				 builder.HasOne<Roadmap>().WithMany(r => r.Missions)
						.HasForeignKey("RoadmapId")
						.OnDelete(DeleteBehavior.Cascade);
    }
}
