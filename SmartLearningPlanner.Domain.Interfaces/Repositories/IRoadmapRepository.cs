using SmartLearningPlanner.Domain.Entities;

namespace SmartLearningPlanner.Domain.Interfaces.Repositories
{
    public interface IRoadmapRepository
    {

        Task<IEnumerable<Roadmap>> GetAllAsync();

        Task<Roadmap> GetByIdAsync(int id);

        /// <summary>
        /// Создание Roadmap
        /// </summary>
        /// <param name="roadmap">Данные Roadmap</param>
        /// <returns></returns>
        Task CreateAsync(Roadmap roadmap);
    }
}
