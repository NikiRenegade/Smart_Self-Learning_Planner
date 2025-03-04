namespace SmartLearningPlanner.Domain.Entities;

/// <summary>
/// Тег для категоризации элементов Roadmap.
/// </summary>
public class Tag
{
    public int Id { get; set; }

    /// <summary>
    /// Название тега, например "programming", "cooking".
    /// </summary>
    public string Code { get; set; }
    
    /// <summary>
    /// Название тега, например "Программирование", "Кулинария".
    /// </summary>
    public string Name { get; set; }
}