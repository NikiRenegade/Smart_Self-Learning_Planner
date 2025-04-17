using Microsoft.EntityFrameworkCore;
using SmartLearningPlanner.Domain.Entities;
using SmartLearningPlanner.Domain.Interfaces.Repositories;
using SmartLearningPlanner.Infrastructure.EntityFramework;

namespace SmartLearningPlanner.Infrastructure.Repositories
{
    public class RoadmapRepository : IRoadmapRepository
    {
        private readonly ApplicationDbContext _context;

        public RoadmapRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Roadmap> GetByIdAsync(int id)
        {
            return await _context.Roadmaps.FindAsync(id);
        }

        public async Task<IEnumerable<Roadmap>> GetAllAsync()
        {
            return await _context.Roadmaps.ToListAsync();
        }

        public async Task CreateAsync(Roadmap roadmap)
        {
            await _context.Roadmaps.AddAsync(roadmap);
            await _context.SaveChangesAsync();
        }
    }
}
