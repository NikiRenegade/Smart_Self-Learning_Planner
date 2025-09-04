namespace SmartLearningPlanner.Domain.Entities;

/// <summary>
/// Вариант ответа в квизе.
/// </summary>
public class QuizQuestionAnswerOption
{
    /// <summary>
    /// Идентификатор варианта ответа.
    /// </summary>
    public int? Id { get; set; }

    /// <summary>
    /// Текст ответа.
    /// </summary>
    public string AnswerText { get; set; }

    /// <summary>
    /// Флаг, является ли этот ответ правильным.
    /// </summary>
    public bool IsCorrect { get; set; }

    /// <summary>
    /// Идентификатор вопроса, к которому относится этот вариант ответа.
    /// </summary>
    public int QuizQuestionId { get; set; }

    /// <summary>
    /// Навигация на вопрос, к которому относится этот вариант ответа.
    /// </summary>
    public QuizQuestion QuizQuestion { get; set; }

}