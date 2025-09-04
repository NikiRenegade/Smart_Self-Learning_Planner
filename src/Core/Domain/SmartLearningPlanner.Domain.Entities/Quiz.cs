namespace SmartLearningPlanner.Domain.Entities;

/// <summary>
/// Квиз с вопросами и ответами.
/// </summary>
public class Quiz
{
    /// <summary>
    /// Идентификатор квиза.
    /// </summary>
    public int? Id { get; set; }

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
    public List<QuizQuestion> QuizQuestions { get; set; } = new();

    /// <summary>
    /// Идентификатор узла (MindmapNode), к которому относится прогресс.
    /// </summary>
    public int? MindmapNodeId { get; set; }

    /// <summary>
    /// Навигация на узел, к которому относится прогресс квиза.
    /// </summary>
    public MindmapNode? MindmapNode { get; set; } = null!;

    /// <summary>
    /// Идентификатор пользователя, создавшего квиз.
    /// </summary>
    public string? CreatedById { get; set; }

    /// <summary>
    /// Пользователь, создавший квиз.
    /// </summary>
    public ApplicationUser? CreatedBy { get; set; }
}
