using SmartLearningPlanner.Domain.Entities;

namespace SmartLearningPlanner.Application.DTOs
{
    public class RoadmapDto
    {
        public int Id { get; set; }

        /// <summary>
        /// Название Roadmap.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Краткое описание
        /// </summary>
        public string ShortDescription { get; set; }

        /// <summary>
        /// Потомки
        /// </summary>
        public ICollection<RoadmapDto> Children { get; set; }
    }
}
