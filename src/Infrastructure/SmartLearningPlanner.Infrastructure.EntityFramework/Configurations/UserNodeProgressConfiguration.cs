using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartLearningPlanner.Domain.Entities;
using SmartLearningPlanner.Domain.Entities.Types;

namespace SmartLearningPlanner.Infrastructure.EntityFramework.Configurations
{
    public class UserNodeProgressConfiguration : IEntityTypeConfiguration<UserNodeProgress>
    {
        public void Configure(EntityTypeBuilder<UserNodeProgress> builder)
        {
            builder.ToTable("UserNodeProgress");

            builder.HasKey(unp => new { unp.UserId, unp.NodeId });

            builder.Property(unp => unp.UserId)
                .IsRequired()
                .HasMaxLength(50); // Максимальная длина для UserId, если это строка

            builder.Property(unp => unp.NodeId)
                .IsRequired();

            builder.Property(unp => unp.Status)
                .IsRequired(); // Преобразование для статуса изучения

            /*
            // Связь с таблицей MindmapNode
            builder.HasOne(unp => unp.Node) // Связь с узлом
                .WithMany() // Здесь не предполагается коллекции в модели MindmapNode
                .HasForeignKey(unp => unp.NodeId)
                .OnDelete(DeleteBehavior.Cascade); // Если узел удаляется, прогресс удаляется
            */
        }
    }
}
