using SmartLearningPlanner.Application.DTOs;

namespace SmartLearningPlanner.Application.Interfaces;

public interface ITagService
{
    Task<TagDto> GetTagByIdAsync(int id);
    Task<IEnumerable<TagDto>> GetAllTagsAsync();
    Task CreateTagAsync(TagDto tagDto);
    Task UpdateTagAsync(TagDto tagDto);
    Task DeleteTagAsync(int id);
}