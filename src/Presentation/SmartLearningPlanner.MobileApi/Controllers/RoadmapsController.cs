using Microsoft.AspNetCore.Mvc;
using SmartLearningPlanner.Application.DTOs;
using SmartLearningPlanner.Application.Interfaces;

namespace SmartLearningPlanner.MobileApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoadmapsController : ControllerBase
    {
        private readonly IRoadmapService _roadmapService;

        public RoadmapsController(IRoadmapService roadmapService)
        {
            _roadmapService = roadmapService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RoadmapDto>> GetById(int id)
        {
            var tag = await _roadmapService.GetByIdAsync(id);
            if (tag == null) return NotFound();

            return Ok(tag);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoadmapDto>>> GetAllTags()
        {
            var roadmaps = await _roadmapService.GetAllAsync();

            return Ok(roadmaps);
        }

        [HttpPost]
        public async Task<ActionResult> CreateTag(RoadmapCreateDto roadmapCreateDto)
        {
            await _roadmapService.CreateAsync(roadmapCreateDto);

            return Ok();
        }
    }
}
