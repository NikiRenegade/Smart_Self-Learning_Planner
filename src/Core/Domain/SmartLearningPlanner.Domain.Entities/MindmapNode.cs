namespace SmartLearningPlanner.Domain.Entities;

/// <summary>
/// Узел Mind-Roadmap, который может быть как листом, так и веткой.
/// Может быть частью нескольких roadmap-деревьев.
/// </summary>
public class MindmapNode
{
    public int Id { get; set; }

    /// <summary>
    /// Название Mind-Roadmap.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Краткое описание о чем Roadmap
    /// </summary>
    public string? ShortDescription { get; set; }

    /// <summary>
    /// Конспект по текущей Roadmap.
    /// </summary>
    public string Notes { get; set; }
    
    /// <summary>
    /// Итоговый результат выполнения Roadmap.
    /// </summary>
    public string Result { get; set; }

    /// <summary>
    /// id создателя Roadmap.
    /// </summary>
    public string UserId { get; set; }

    
    
    /// <summary>
    /// Список связей с родительскими узлами.
    /// </summary>
    public ICollection<MindmapEdge> MindmapEdges { get; set; }

    /// <summary>
    /// Список ресурсов (книги, видео, изображения, статьи и др.).
    /// </summary>
    public IEnumerable<Resource> Resources { get; set; } = new List<Resource>();

    /// <summary>
    /// Список задач, связанных с данной Roadmap.
    /// </summary>
    public IEnumerable<Mission> Missions { get; set; } = new List<Mission>();

    /// <summary>
    /// Квизы, связанные с данной Roadmap.
    /// </summary>
    public IEnumerable<Quiz> Quizzes { get; set; } = new List<Quiz>();

    /// <summary>
    /// Теги для категоризации Roadmap.
    /// </summary>
    public IEnumerable<Tag> Tags { get; set; } = new List<Tag>();
}