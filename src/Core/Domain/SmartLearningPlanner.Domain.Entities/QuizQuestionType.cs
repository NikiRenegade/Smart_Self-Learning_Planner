

namespace SmartLearningPlanner.Domain.Entities;

public class QuizQuestionType
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
	/// <summary>
	/// Навигация на вопросы, использующие этот тип вопроса.
	/// </summary>
	public List<QuizQuestion> QuizQuestions { get; set; }
}

/// <summary>
/// Коды типов вопросов.
/// </summary>
public enum QuizQuestionTypeCode
{
	SingleChoice,  // Один правильный вариант
	MultipleChoice, // Несколько правильных вариантов
	TextAnswer     // Открытый вопрос
}
