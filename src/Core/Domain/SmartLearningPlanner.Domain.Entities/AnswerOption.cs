namespace SmartLearningPlanner.Domain.Entities;

/// <summary>
/// Вариант ответа в квизе.
/// </summary>
public class AnswerOption
{
    public int Id { get; set; }

    /// <summary>
    /// Текст ответа.
    /// </summary>
    public string AnswerText { get; set; }

    /// <summary>
    /// Флаг, является ли этот ответ правильным.
    /// </summary>
    public bool IsCorrect { get; set; }
}