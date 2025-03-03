namespace SmartLearningPlanner.Domain.Entities;

/// <summary>
/// Вопрос в квизе.
/// </summary>
public class QuizQuestion
{
    public int Id { get; set; }

    /// <summary>
    /// Текст вопроса.
    /// </summary>
    public string QuestionText { get; set; }

    /// <summary>
    /// Тип вопроса (один вариант, несколько, текстовый ответ).
    /// </summary>
    public QuestionType Type { get; set; }

    /// <summary>
    /// Варианты ответа (если применимо).
    /// </summary>
    public List<AnswerOption> Options { get; set; }

    /// <summary>
    /// Правильный ответ (если это текстовый вопрос).
    /// </summary>
    public string? CorrectAnswer { get; set; }
}

/// <summary>
/// Типы вопросов.
/// </summary>
public enum QuestionType
{
    SingleChoice,  // Один правильный вариант
    MultipleChoice, // Несколько правильных вариантов
    TextAnswer     // Открытый вопрос
}