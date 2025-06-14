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

        public async Task<MindmapNode> GetByIdAsync(int rootId)
        {
            var roadmap = await _context.MindmapNodes
                .Include(x => x.MindmapEdges)
                    .ThenInclude(x => x.Child)
               .SingleOrDefaultAsync(m => m.Id == rootId);

            return roadmap;
        }

        public async Task<IEnumerable<MindmapNode>> GetAllAsync()
        {
            return await _context.MindmapNodes
                .Include(x => x.MindmapEdges)
                    .ThenInclude(x => x.Child)
                .Where(p => p.MindmapEdges.Count != 0).ToListAsync();
        }

        public async Task CreateAsync(MindmapNode roadmap)
        {
            // await _context.MindmapNodes.AddAsync(roadmap);
            // await _context.SaveChangesAsync();
        }
    }
}
