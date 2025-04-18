using SmartLearningPlanner.Application.DTOs;

namespace SmartLearningPlanner.Application.Interfaces;

public interface IUserService
{
   Task<UserDto> GetUserByIdAsync(string id);
   Task<IEnumerable<UserDto>> GetAllUsersAsync();
   Task CreateUserAsync(RegisterUserDto registerUserDto);
   Task UpdateUserAsync(UserDto userDto);
   Task DeleteUserAsync(string id);
   Task<bool> CheckUserPasswordAsync(string id, string password);
   Task ChangeUserPasswordAsync(string id, string currentPassword, string newPassword);
   Task ConfirmUserEmailAsync(string id, string token);
}