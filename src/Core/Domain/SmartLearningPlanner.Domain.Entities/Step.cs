namespace SmartLearningPlanner.Domain.Entities;

/// <summary>
/// Шаг в рамках Roadmap, который сам является Roadmap и имеет порядок.
/// </summary>
public class Step
{
    public int Id { get; set; }

    /// <summary>
    /// Порядок выполнения в рамках родительской Roadmap.
    /// </summary>
    public int Order { get; set; }

    /// <summary>
    /// Вложенная Roadmap, являющаяся шагом текущей Roadmap.
    /// </summary>
    public Roadmap? SubRoadmap { get; set; }
}