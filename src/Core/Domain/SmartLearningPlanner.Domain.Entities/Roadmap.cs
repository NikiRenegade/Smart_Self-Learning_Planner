namespace SmartLearningPlanner.Domain.Entities;

/// <summary>
/// Roadmap - сущность, представляющая путь достижения цели.
/// Может включать в себя другие Roadmap (Step).
/// </summary>
public class Roadmap
{
    public int Id { get; set; }

    /// <summary>
    /// Название Roadmap.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Конспект по текущей Roadmap.
    /// </summary>
    public string Notes { get; set; }
    
    /// <summary>
    /// Итоговый результат выполнения Roadmap.
    /// </summary>
    public string Result { get; set; }

    
    
    /// <summary>
    /// Список ресурсов (книги, видео, изображения, статьи и др.).
    /// </summary>
    public List<Resource> Resources { get; set; } = new();

    /// <summary>
    /// Список задач, связанных с данной Roadmap.
    /// </summary>
    public List<Mission> Missions { get; set; } = new();

    /// <summary>
    /// Квизы, связанные с данной Roadmap.
    /// </summary>
    public List<Quiz> Quizzes { get; set; } = new();

    /// <summary>
    /// Вложенные Roadmap (если есть), представляющие шаги текущей Roadmap.
    /// </summary>
    public List<Roadmap> SubRoadmaps { get; set; } = new();
    public int? ParentRoadmapId;

    /// <summary>
    /// Теги для категоризации Roadmap.
    /// </summary>
    public List<Tag> Tags { get; set; } = new();

    /// <summary>
    /// id создателя Roadmap.
    /// </summary>
    public string UserId {get; set;}
}