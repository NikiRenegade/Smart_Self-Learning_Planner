using SmartLearningPlanner.MobileApp.Models.Responses;
using System.Net.Http.Json;

namespace SmartLearningPlanner.MobileApp.Services
{
    public class RoadmapService : IRoadmapService
    {
        private readonly HttpClient _httpClient;

        public RoadmapService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://10.0.2.2:5188/api/");
        }

        public async Task<List<RoadmapResponse>> GetRoadmapsAsync()
        {
            var response = await _httpClient.GetAsync("roadmaps");

            return await response.Content.ReadFromJsonAsync<List<RoadmapResponse>>();
        }

        public async Task<RoadmapDetailResponse> GetRoadmapDetailsAsync(int id)
        {
            // var response = await _httpClient.GetAsync($"{BaseUrl}/{id}");
            return null;
           // return await response.Content.ReadFromJsonAsync<RoadmapDetailResponse>();
        }
    }
}
