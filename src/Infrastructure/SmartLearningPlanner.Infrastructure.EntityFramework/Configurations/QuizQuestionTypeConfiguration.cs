using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartLearningPlanner.Domain.Entities;
namespace SmartLearningPlanner.Infrastructure.EntityFramework.Configurations;

public class QuizQuestionTypeConfiguration : IEntityTypeConfiguration<QuizQuestionType>
{
	public void Configure(EntityTypeBuilder<QuizQuestionType> builder)
	{
		builder.ToTable("QuizQuestionTypes");

		// Указываем первичный ключ
		builder.HasKey(qq => qq.Id);

		// Настройка свойств
		builder.Property(qq => qq.TypeCode)
				.IsRequired(); // Обязательное поле

		builder.Property(qq => qq.Name)
				.IsRequired() // Обязательное поле
				.HasMaxLength(100); // Максимальная длина имени
		builder.Property(qq => qq.AllowsMultipleAnswers)
				.IsRequired(); // Обязательное поле

		builder.Property(qq => qq.RequiresTextAnswer)
				.IsRequired(); // Обязательное поле

		builder.HasMany<QuizQuestion>(qq => qq.QuizQuestions)
				.WithOne(q => q.QuestionType)
				.HasForeignKey(q => q.QuestionTypeId)
				.OnDelete(DeleteBehavior.Cascade); // Удаление вопросов при удалении типа вопроса
	}
}
