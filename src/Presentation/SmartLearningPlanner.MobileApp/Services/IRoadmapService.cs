using SmartLearningPlanner.MobileApp.Models.Responses;

namespace SmartLearningPlanner.MobileApp.Services
{
    public interface IRoadmapService
    {
        Task<List<RoadmapResponse>> GetRoadmapsAsync();

        Task<RoadmapDetailResponse> GetRoadmapDetailsAsync(int id);

    }
}
