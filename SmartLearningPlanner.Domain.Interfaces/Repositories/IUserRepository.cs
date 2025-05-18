using SmartLearningPlanner.Domain.Entities;

namespace SmartLearningPlanner.Domain.Interfaces.Repositories;

public interface IUserRepository
{
    Task<ApplicationUser> GetByIdAsync(string id);
    Task<IEnumerable<ApplicationUser>> GetAllAsync();
    Task<string> AddAsync(ApplicationUser user, string password);
    Task UpdateAsync(ApplicationUser user);
    Task DeleteAsync(string id);
    Task<bool> CheckPasswordAsync(ApplicationUser user, string password);
    Task ChangePasswordAsync(ApplicationUser user, string currentPassword, string newPassword);
    Task ConfirmEmailAsync(string id, string token);
    Task<ApplicationUser> GetByEmailAsync(string email);
    Task<bool> IsEmailConfirmedAsync(ApplicationUser user);
    Task<bool> AuthenticateAsync(ApplicationUser user, string password);
}