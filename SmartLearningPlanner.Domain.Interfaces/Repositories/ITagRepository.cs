using SmartLearningPlanner.Domain.Entities;

namespace SmartLearningPlanner.Domain.Interfaces.Repositories;

public interface ITagRepository
{
    Task<Tag> GetByIdAsync(int id);
    Task<IEnumerable<Tag>> GetAllAsync();
    Task AddAsync(Tag tag);
    Task UpdateAsync(Tag tag);
    Task DeleteAsync(int id);
}