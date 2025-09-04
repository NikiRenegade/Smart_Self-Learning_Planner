namespace SmartLearningPlanner.Domain.Entities;

/// <summary>
/// Вопрос в квизе.
/// </summary>
public class QuizQuestion
{
    /// <summary>
    /// Идентификатор вопроса.
    /// </summary>
    public int? Id { get; set; }

    /// <summary>
    /// Текст вопроса.
    /// </summary>
    public string QuestionText { get; set; }

    /// <summary>
    /// Идентификатор типа вопроса (одиночный выбор, множественный выбор, текстовый ответ).
    /// </summary>
    public int QuestionTypeId { get; set; }

    /// <summary>
    /// Тип вопроса (одиночный выбор, множественный выбор, текстовый ответ).
    /// </summary>
    public QuizQuestionType QuestionType { get; set; }

    /// <summary>
    /// Варианты ответа (если применимо).
    /// </summary>
    public List<QuizQuestionAnswerOption> QuizQuestionAnswerOptions { get; set; }

    /// <summary>
    /// Правильный ответ (если это текстовый вопрос).
    /// </summary>
    public string? CorrectAnswer { get; set; }

    /// <summary>
    /// Идентификатор квиза, к которому относится этот вопрос.
    /// </summary>
    public int QuizId { get; set; }

    /// <summary>
    /// Квиз, к которому относится этот вопрос.
    /// </summary>
    public Quiz Quiz { get; set; }
}
