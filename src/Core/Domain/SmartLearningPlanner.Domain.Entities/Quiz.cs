namespace SmartLearningPlanner.Domain.Entities;

/// <summary>
/// Квиз с вопросами и ответами.
/// </summary>
public class Quiz
{
    public int Id { get; set; }

    /// <summary>
    /// Название квиза.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Описание к квизу.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Вопросы, входящие в этот квиз.
    /// </summary>
    public List<QuizQuestion> Questions { get; set; } = new();
}
