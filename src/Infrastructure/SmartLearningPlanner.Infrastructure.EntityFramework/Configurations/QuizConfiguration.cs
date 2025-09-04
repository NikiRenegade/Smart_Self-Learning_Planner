using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartLearningPlanner.Domain.Entities;
namespace SmartLearningPlanner.Infrastructure.EntityFramework.Configurations;

public class QuizConfiguration : IEntityTypeConfiguration<Quiz>
{
  public void Configure(EntityTypeBuilder<Quiz> builder)
  {
    // Указываем таблицу, в которой будет храниться сущность
    builder.ToTable("Quizzes");

    // Указываем первичный ключ
    builder.HasKey(q => q.Id);

    // Настройка свойств
    builder.Property(q => q.Title)
        .IsRequired() // Обязательное поле
        .HasMaxLength(256); // Максимальная длина

    builder.Property(q => q.Description)
        .HasMaxLength(1024); // Максимальная длина


    builder.HasMany<QuizQuestion>(q => q.QuizQuestions)
       .WithOne(qq => qq.Quiz)
       .HasForeignKey(qq => qq.QuizId)
       .OnDelete(DeleteBehavior.Cascade);

    builder.HasOne(q => q.CreatedBy)
        .WithMany(u => u.CreatedQuizzes)
        .HasForeignKey(q => q.CreatedById)
        .OnDelete(DeleteBehavior.SetNull);

    /*
    // Установка связей		
    builder.HasOne<MindmapNode>().WithMany(r => r.Quizzes)
                    .HasForeignKey(m => m.MindmapNodeId)
                    .OnDelete(DeleteBehavior.Cascade);
    */
  }
}
