using SmartLearningPlanner.MobileApp.Models;

namespace SmartLearningPlanner.MobileApp.Services
{
    public interface IRoadmapService
    {
        Task<bool> CreateRoadmap(CreateRoadmapRequest request);
    }
}
