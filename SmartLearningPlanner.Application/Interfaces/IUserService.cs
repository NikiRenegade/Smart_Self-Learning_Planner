using SmartLearningPlanner.Application.DTOs;

namespace SmartLearningPlanner.Application.Interfaces;

public interface IUserService
{
   Task<UserDto> GetUserByIdAsync(string id);
   Task<IEnumerable<UserDto>> GetAllUsersAsync();
   Task UpdateUserAsync(UserDto userDto);
   Task DeleteUserAsync(string id);
   Task<UserDto> GetUserByEmailAsync(string email);
}