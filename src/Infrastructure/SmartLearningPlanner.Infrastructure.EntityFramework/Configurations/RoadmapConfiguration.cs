using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartLearningPlanner.Domain.Entities;

namespace SmartLearningPlanner.Infrastructure.EntityFramework.Configurations;

public class RoadmapConfiguration : IEntityTypeConfiguration<Roadmap>
{
    public void Configure(EntityTypeBuilder<Roadmap> builder)
    {
				// Указываем таблицу, в которой будет храниться сущность
        builder.ToTable("Roadmaps");

				// Указываем первичный ключ
        builder.HasKey(r => r.Id);

				// Настройка свойств
        builder.Property(r => r.Title)
						.IsRequired()
						.HasMaxLength(256);

        builder.Property(r => r.Notes)
						.HasMaxLength(1024);

        builder.Property(r => r.Result)
						.HasMaxLength(1024);

        builder.HasMany(r => r.Missions).WithOne()
						.HasForeignKey("RoadmapId")
						.OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(r => r.Quizzes).WithOne()
						.HasForeignKey("RoadmapId")
						.OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(r => r.Resources).WithOne()
						.HasForeignKey("RoadmapId")
						.OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(r => r.SubRoadmaps).WithOne()
						.HasForeignKey(s => s.ParentRoadmapId)
						.OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(r => r.Tags).WithOne()
						.HasForeignKey("RoadmapId")
						.OnDelete(DeleteBehavior.Cascade);
    }
}
