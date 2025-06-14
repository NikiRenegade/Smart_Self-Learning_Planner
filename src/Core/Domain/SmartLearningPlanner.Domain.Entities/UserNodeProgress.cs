using SmartLearningPlanner.Domain.Entities.Types;

namespace SmartLearningPlanner.Domain.Entities
{
    /// <summary>
    /// Прогресс изучения конкретного узла пользователем.
    /// </summary>
    public class UserNodeProgress
    {
        /// <summary>
        /// Идентификатор пользователя.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Идентификатор узла.
        /// </summary>
        public int NodeId { get; set; }

        /// <summary>
        /// Связанный узел.
        /// </summary>
        public MindmapNode Node { get; set; } = null!;

        /// <summary>
        /// Текущий статус изучения.
        /// </summary>
        public StudyStatus Status { get; set; }
    }
}
