namespace SmartLearningPlanner.Domain.Entities;

/// <summary>
/// Полезный ресурс (видео, книга, изображение, статья и др.).
/// </summary>
public class Resource 
{
    public int Id { get; set; }

    /// <summary>
    /// Описание ресурса.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Тип ресурса (статья, видео, книга, изображение и др.).
    /// </summary>
    public ResourceType Type { get; set; }
    
    /// <summary>
    /// URL, если ресурс находится в сети.
    /// </summary>
    public string? Url { get; set; }

    /// <summary>
    /// Локальный путь к файлу, если ресурс хранится на устройстве.
    /// </summary>
    public string? LocalPath { get; set; }
}

/// <summary>
/// Тип ресурса.
/// </summary>
public enum ResourceType
{
    /// <summary>
    /// Ссылка (например, на видео или статью).
    /// </summary>
    Link,

    /// <summary>
    /// Файл (например, PDF, изображение, видео и т.д.).
    /// </summary>
    File
}