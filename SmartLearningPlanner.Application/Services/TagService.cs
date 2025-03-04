using SmartLearningPlanner.Application.DTOs;
using SmartLearningPlanner.Application.Interfaces;
using SmartLearningPlanner.Domain.Entities;
using SmartLearningPlanner.Domain.Interfaces.Repositories;
using Task = System.Threading.Tasks.Task;

namespace SmartLearningPlanner.Application.Services;

public class TagService : ITagService
{
    private readonly ITagRepository _tagRepository;

    public TagService(ITagRepository tagRepository)
    {
        _tagRepository = tagRepository;
    }

    public async Task<TagDto> GetTagByIdAsync(int id)
    {
        var tag = await _tagRepository.GetByIdAsync(id);
        
        return new TagDto { Id = tag.Id, Name = tag.Name, Code = tag.Code };
    }

    public async Task<IEnumerable<TagDto>> GetAllTagsAsync()
    {
        var tags = await _tagRepository.GetAllAsync();
        
        return tags.Select(t => new TagDto { Id = t.Id, Name = t.Name, Code = t.Code });
    }

    public async Task CreateTagAsync(TagDto tagDto)
    {
        var tag = new Tag { Name = tagDto.Name, Code = tagDto.Code };
        await _tagRepository.AddAsync(tag);
    }

    public async Task UpdateTagAsync(TagDto tagDto)
    {
        var tag = await _tagRepository.GetByIdAsync(tagDto.Id);
        if (tag == null) throw new Exception("Tag not found");

        tag.Name = tagDto.Name;
        tag.Code = tagDto.Code;
        await _tagRepository.UpdateAsync(tag);
    }

    public async Task DeleteTagAsync(int id)
    {
        var tag = await _tagRepository.GetByIdAsync(id);
        if (tag == null) throw new Exception("Tag not found");

        await _tagRepository.DeleteAsync(id);
    }
}