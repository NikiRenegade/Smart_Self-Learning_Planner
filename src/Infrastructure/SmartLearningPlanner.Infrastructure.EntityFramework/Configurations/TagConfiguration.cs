using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartLearningPlanner.Domain.Entities;

namespace SmartLearningPlanner.Infrastructure.EntityFramework.Configurations;

public class TagConfiguration : IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        // Указываем таблицу, в которой будет храниться сущность
        builder.ToTable("Tags");

        // Указываем первичный ключ
        builder.HasKey(t => t.Id);

        // Настройка свойств
        builder.Property(t => t.Name)
            .IsRequired() // Обязательное поле
            .HasMaxLength(256); // Максимальная длина

        builder.Property(t => t.Code)
            .HasMaxLength(128); // Максимальная длина

        // Установка связей	
        builder.HasOne<Roadmap>().WithMany(r => r.Tags)
			.HasForeignKey("RoadmapId")
			.OnDelete(DeleteBehavior.Cascade);
    }
}