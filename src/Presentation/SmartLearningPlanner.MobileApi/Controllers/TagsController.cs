using Microsoft.AspNetCore.Mvc;
using SmartLearningPlanner.Application.DTOs;
using SmartLearningPlanner.Application.Interfaces;

namespace SmartLearningPlanner.MobileApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TagsController : ControllerBase
{
    private readonly ITagService _tagService;

    public TagsController(ITagService tagService)
    {
        _tagService = tagService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TagDto>> GetTag(int id)
    {
        var tag = await _tagService.GetTagByIdAsync(id);
        if (tag == null) return NotFound();
        
        return Ok(tag);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TagDto>>> GetAllTags()
    {
        var tags = await _tagService.GetAllTagsAsync();
        
        return Ok(tags);
    }

    [HttpPost]
    public async Task<ActionResult> CreateTag(TagDto tagDto)
    {
        await _tagService.CreateTagAsync(tagDto);
        
        return CreatedAtAction(nameof(GetTag), new { id = tagDto.Id }, tagDto);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateTag(int id, TagDto tagDto)
    {
        if (id != tagDto.Id) return BadRequest();
        await _tagService.UpdateTagAsync(tagDto);
        
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteTag(int id)
    {
        await _tagService.DeleteTagAsync(id);
        
        return NoContent();
    }
}