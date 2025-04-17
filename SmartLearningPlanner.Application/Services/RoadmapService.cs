using SmartLearningPlanner.Application.DTOs;
using SmartLearningPlanner.Application.Interfaces;
using SmartLearningPlanner.Domain.Entities;
using SmartLearningPlanner.Domain.Interfaces.Repositories;

namespace SmartLearningPlanner.Application.Services
{
    public class RoadmapService : IRoadmapService
    {
        private readonly IRoadmapRepository _roadmapRepository;

        public RoadmapService(IRoadmapRepository roadmapRepository)
        {
            _roadmapRepository = roadmapRepository;
        }

        public async Task<RoadmapDto> GetByIdAsync(int id)
        {
            var roadmap = await _roadmapRepository.GetByIdAsync(id);

            return new RoadmapDto { Id = roadmap.Id, Title = roadmap.Title, ShortDescription = roadmap.ShortDescription };
        }

        public async Task<IEnumerable<RoadmapDto>> GetAllAsync()
        {
            var roadmaps = await _roadmapRepository.GetAllAsync();

            return roadmaps.Select(t => new RoadmapDto { Id = t.Id, Title = t.Title, ShortDescription = t.ShortDescription });
        }

        public async Task CreateAsync(RoadmapCreateDto roadmapCreateDto)
        {
            var tag = new Roadmap { Title = roadmapCreateDto.Title, ShortDescription = roadmapCreateDto.ShortDescription };
            await _roadmapRepository.CreateAsync(tag);
        }
    }
}
