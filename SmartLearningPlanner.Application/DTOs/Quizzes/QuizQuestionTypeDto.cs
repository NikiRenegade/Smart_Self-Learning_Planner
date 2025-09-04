using SmartLearningPlanner.Domain.Entities;
namespace SmartLearningPlanner.Application.DTOs;

public class QuizQuestionTypeDto
{
	/// <summary>
	/// Идентификатор типа вопроса.
	/// </summary>
	public int Id { get; set; }
	/// <summary>
	/// Код типа вопроса (одиночный выбор, множественный выбор, текстовый ответ).
	/// </summary>
	public QuizQuestionTypeCode TypeCode { get; set; }
	/// <summary>
	/// Название типа вопроса.
	/// </summary>
	public string Name { get; set; }
	/// <summary>
	/// Флаг, позволяет ли тип вопроса множественный выбор ответов.
	/// </summary>
	public bool AllowsMultipleAnswers { get; set; }
	/// <summary>
	/// Флаг, требует ли тип вопроса текстового ответа.
	/// </summary>
	public bool RequiresTextAnswer { get; set; }
}
