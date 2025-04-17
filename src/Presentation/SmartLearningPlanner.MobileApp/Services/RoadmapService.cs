using SmartLearningPlanner.MobileApp.Models;
using System.Net.Http.Json;

namespace SmartLearningPlanner.MobileApp.Services
{
    public class RoadmapService : IRoadmapService
    {
        private readonly HttpClient _httpClient;

        public RoadmapService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> CreateRoadmap(CreateRoadmapRequest request)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/roadmaps", request);
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}
