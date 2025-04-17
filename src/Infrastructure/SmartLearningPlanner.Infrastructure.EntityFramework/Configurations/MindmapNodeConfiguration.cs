using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartLearningPlanner.Domain.Entities;

namespace SmartLearningPlanner.Infrastructure.EntityFramework.Configurations;

public class MindmapNodeConfiguration : IEntityTypeConfiguration<MindmapNode>
{
    public void Configure(EntityTypeBuilder<MindmapNode> builder)
    {
        builder.ToTable("MindmapNodes");

        builder.HasKey(mn => mn.Id);

        builder.Property(mn => mn.Title)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(mn => mn.ShortDescription)
            .HasMaxLength(500);

        builder.Property(mn => mn.Notes)
            .IsRequired()
            .HasMaxLength(2000);

        builder.Property(mn => mn.Result)
            .IsRequired()
            .HasMaxLength(1000);

        builder.Property(mn => mn.UserId)
            .IsRequired()
            .HasMaxLength(50);

        builder.HasMany(n => n.MindmapEdges)
              .WithOne(e => e.Parent)
              .HasForeignKey(e => e.ParentId);
    }
}
