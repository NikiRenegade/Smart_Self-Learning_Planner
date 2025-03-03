
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartLearningPlanner.Domain.Entities;

namespace SmartLearningPlanner.Infrastructure.EntityFramework.Configurations;

public class AnswerOptionConfiguration : IEntityTypeConfiguration<AnswerOption>
{
    public void Configure(EntityTypeBuilder<AnswerOption> builder)
    {
				// Указываем таблицу, в которой будет храниться сущность
        builder.ToTable("AnswerOptions");

				// Указываем первичный ключ
        builder.HasKey(a => a.Id);

				// Настройка свойств
        builder.Property(a => a.AnswerText)
						.IsRequired() // Обязательное поле
						.HasMaxLength(512); // Максимальная длина

        builder.Property(a => a.IsCorrect)
						.IsRequired(); // Обязательное поле

				builder.HasOne<QuizQuestion>().WithMany(qq => qq.Options)
						.HasForeignKey("QuizQuestionId")
						.OnDelete(DeleteBehavior.Cascade);

				
    }
}
