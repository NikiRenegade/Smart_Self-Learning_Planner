
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartLearningPlanner.Domain.Entities;

namespace SmartLearningPlanner.Infrastructure.EntityFramework.Configurations;

public class QuizQuestionAnswerOptionConfiguration : IEntityTypeConfiguration<QuizQuestionAnswerOption>
{
	public void Configure(EntityTypeBuilder<QuizQuestionAnswerOption> builder)
	{
		// Указываем таблицу, в которой будет храниться сущность
		builder.ToTable("QuizQuestionAnswerOptions");

		// Указываем первичный ключ
		builder.HasKey(a => a.Id);

		// Настройка свойств
		builder.Property(a => a.AnswerText)
				.IsRequired() // Обязательное поле
				.HasMaxLength(512); // Максимальная длина

		builder.Property(a => a.IsCorrect)
				.IsRequired(); // Обязательное поле

		builder.HasOne<QuizQuestion>()
				.WithMany(qq => qq.QuizQuestionAnswerOptions)
				.HasForeignKey(o => o.QuizQuestionId)
				.OnDelete(DeleteBehavior.Cascade);


	}
}
