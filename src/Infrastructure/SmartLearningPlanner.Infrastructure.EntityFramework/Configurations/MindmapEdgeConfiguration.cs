using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartLearningPlanner.Domain.Entities;

namespace SmartLearningPlanner.Infrastructure.EntityFramework.Configurations
{
    public class MindmapEdgeConfiguration : IEntityTypeConfiguration<MindmapEdge>
    {
        public void Configure(EntityTypeBuilder<MindmapEdge> builder)
        {
            builder.ToTable("MindmapEdges");

            builder.HasKey(me => me.Id);

            builder.Property(me => me.Order)
                .IsRequired();

            builder.HasOne(me => me.Parent)
                .WithMany() // Можно настроить связь с родительским узлом в зависимости от модели MindmapNode
                .HasForeignKey(me => me.ParentId)
                .OnDelete(DeleteBehavior.Cascade); // Если родительский узел удаляется, связь с ним тоже будет удалена.

            builder.HasOne(me => me.Child)
                .WithMany() // Можно настроить связь с дочерним узлом в зависимости от модели MindmapNode
                .HasForeignKey(me => me.ChildId)
                .OnDelete(DeleteBehavior.Cascade); // Если дочерний узел удаляется, связь с ним тоже будет удалена.
        }
    }
}
