using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartLearningPlanner.Domain.Entities;

namespace SmartLearningPlanner.Infrastructure.EntityFramework.Configurations;

public class QuizQuestionConfiguration : IEntityTypeConfiguration<QuizQuestion>
{
    public void Configure(EntityTypeBuilder<QuizQuestion> builder)
    {
        builder.ToTable("QuizQuestions");

				// Указываем первичный ключ
				builder.HasKey(qq => qq.Id);

				// Настройка свойств
				builder.Property(qq => qq.QuestionText)
						.IsRequired() // Обязательное поле
						.HasMaxLength(2048); // Максимальная длина

				builder.Property(qq => qq.Type)
						.IsRequired(); // Обязательное поле
				
				builder.Property(qq => qq.CorrectAnswer)
						.HasMaxLength(512);

				 builder.HasOne<Quiz>().WithMany(q => q.Questions)
						.HasForeignKey("QuizId")
						.OnDelete(DeleteBehavior.Cascade);
    }
}
