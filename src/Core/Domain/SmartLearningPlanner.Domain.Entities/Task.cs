namespace SmartLearningPlanner.Domain.Entities;

/// <summary>
/// Отдельная задача в рамках Roadmap.
/// </summary>
public class Task
{
    public int Id { get; set; }

    /// <summary>
    /// Название задачи.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Описание, что нужно сделать в рамках задачи.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Флаг, выполнена ли задача.
    /// </summary>
    public bool IsCompleted { get; set; }
    
    // порядок DragAndDrop
    // привязка к тесту
    // дата начала
    // дата сдачи
}