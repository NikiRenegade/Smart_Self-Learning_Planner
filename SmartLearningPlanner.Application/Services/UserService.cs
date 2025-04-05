using Microsoft.AspNetCore.Identity;
using SmartLearningPlanner.Application.DTOs;
using SmartLearningPlanner.Application.Interfaces;
using SmartLearningPlanner.Domain.Entities;
using SmartLearningPlanner.Domain.Interfaces.Repositories;

namespace SmartLearningPlanner.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<UserDto> GetUserByIdAsync(string id)
    {
        ApplicationUser user = await _userRepository.GetByIdAsync(id);
        return new UserDto {Id = user.Id, UserName = user.UserName, FirstName = user.FirstName, LastName = user.LastName, Email = user.Email};
    }

    public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
    {
        IEnumerable<ApplicationUser> users = await _userRepository.GetAllAsync();
        return users.Select(u => new UserDto
            { Id = u.Id, UserName = u.UserName, FirstName = u.FirstName, LastName = u.LastName, Email = u.Email });
    }

    public async Task CreateUserAsync(RegisterUserDto registerUserDto)
    {
        ApplicationUser user = new ApplicationUser {
            UserName = registerUserDto.UserName,
            FirstName = registerUserDto.FirstName,
            LastName = registerUserDto.LastName,
            Email = registerUserDto.Email};
        await _userRepository.AddAsync(user, registerUserDto.Password);
    }

    public async Task UpdateUserAsync(UserDto userDto)
    {
        ApplicationUser user = await _userRepository.GetByIdAsync(userDto.Id);
        if (user==null) throw new Exception("User not found"); 
        user.UserName = userDto.UserName;
        user.FirstName = userDto.FirstName;
        user.LastName = userDto.LastName;
        user.Email = userDto.Email;
        await _userRepository.UpdateAsync(user);
    }

    public async Task DeleteUserAsync(string id)
    {
        ApplicationUser user = await _userRepository.GetByIdAsync(id);
        if (user==null) throw new Exception("User not found");
        await _userRepository.DeleteAsync(id);
    }
    public async Task<bool> CheckPasswordAsync(string id, string password)
    {
        ApplicationUser user = await _userRepository.GetByIdAsync(id);
        if (user == null) throw new Exception("User not found");

        return await _userRepository.CheckPasswordAsync(user, password);
    }

    public async Task ChangePasswordAsync(string id, string currentPassword, string newPassword)
    {
        ApplicationUser user = await _userRepository.GetByIdAsync(id);
        if (user == null) throw new Exception("User not found");
        await _userRepository.ChangePasswordAsync(user, currentPassword, newPassword);
    }
}