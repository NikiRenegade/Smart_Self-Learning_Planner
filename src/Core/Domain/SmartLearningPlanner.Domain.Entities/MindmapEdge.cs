namespace SmartLearningPlanner.Domain.Entities
{
    /// <summary>
    /// Связь между узлами: parent → child (деревья, графы).
    /// Позволяет строить иерархии и переиспользовать узлы.
    /// </summary>
    public class MindmapEdge
    {
        /// <summary>
        /// Уникальный идентификатор связи.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Родительский узел.
        /// </summary>
        public int ParentId { get; set; }
        public MindmapNode Parent { get; set; } = null!;

        /// <summary>
        /// Дочерний узел.
        /// </summary>
        public int ChildId { get; set; }
        public MindmapNode Child { get; set; } = null!;

        /// <summary>
        /// Порядковый номер (сортировка дочерних).
        /// </summary>
        public int Order { get; set; }
    }
}
