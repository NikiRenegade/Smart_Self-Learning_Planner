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

		builder.Property(qq => qq.CorrectAnswer)
				.HasMaxLength(512);

		builder.HasOne<QuizQuestionType>(q => q.QuestionType)
				.WithMany(q => q.QuizQuestions)
				.HasForeignKey(q => q.QuestionTypeId)
				.OnDelete(DeleteBehavior.Cascade);

		builder.HasMany<QuizQuestionAnswerOption>(q => q.QuizQuestionAnswerOptions)
				.WithOne(a => a.QuizQuestion)
				.HasForeignKey(a => a.QuizQuestionId)
				.OnDelete(DeleteBehavior.Cascade);

		builder.HasOne<Quiz>(q => q.Quiz)
				.WithMany(q => q.QuizQuestions)
				.HasForeignKey(qq => qq.QuizId)
			 	.OnDelete(DeleteBehavior.Cascade);
	}
}
