namespace SmartLearningPlanner.Domain.Entities;

// TODO: Убрать, используем Identity

/// <summary>
/// Пользователь
/// </summary>
public class User
{
    public int Id { get; set; }

    /// <summary>
    /// Имя пользователя.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Email для связи или входа.
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Фото профиля (если есть).
    /// </summary>
    public string? ProfilePictureUrl { get; set; }
}
