using SmartLearningPlanner.Domain.Entities;

namespace SmartLearningPlanner.Domain.Interfaces.Repositories
{
    public interface IRoadmapRepository
    {

        Task<IEnumerable<MindmapNode>> GetAllAsync();

        Task<MindmapNode> GetByIdAsync(int id);

        /// <summary>
        /// Создание MindmapNode
        /// </summary>
        /// <param name="roadmap">Данные Roadmap</param>
        /// <returns></returns>
        Task CreateAsync(MindmapNode roadmap);
    }
}
