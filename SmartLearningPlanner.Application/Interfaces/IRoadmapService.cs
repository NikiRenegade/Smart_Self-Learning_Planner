using SmartLearningPlanner.Application.DTOs;

namespace SmartLearningPlanner.Application.Interfaces
{
    public interface IRoadmapService
    {
        Task<RoadmapDto> GetByIdAsync(int id);

        Task<IEnumerable<RoadmapDto>> GetAllAsync();

        Task CreateAsync(RoadmapCreateDto roadmapCreateDto);
    }
}
