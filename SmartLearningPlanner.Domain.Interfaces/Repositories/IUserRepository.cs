using SmartLearningPlanner.Domain.Entities;

namespace SmartLearningPlanner.Domain.Interfaces.Repositories;

public interface IUserRepository
{
    Task<ApplicationUser> GetByIdAsync(string id);
    Task<IEnumerable<ApplicationUser>> GetAllAsync();
    Task UpdateAsync(ApplicationUser user);
    Task DeleteAsync(string id);
    Task<ApplicationUser> GetByEmailAsync(string email);
    Task<String> GetUserIdByEmailAsync(string email);
}