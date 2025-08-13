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
        return new UserDto { Id = user.Id, UserName = user.UserName, FirstName = user.FirstName, LastName = user.LastName, Email = user.Email };
    }

    public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
    {
        IEnumerable<ApplicationUser> users = await _userRepository.GetAllAsync();
        return users.Select(u => new UserDto
        { Id = u.Id, UserName = u.UserName, FirstName = u.FirstName, LastName = u.LastName, Email = u.Email });
    }

    public async Task UpdateUserAsync(UserDto userDto)
    {
        ApplicationUser user = await _userRepository.GetByIdAsync(userDto.Id);
        if (user == null) throw new Exception("User not found");
        user.UserName = userDto.UserName;
        user.FirstName = userDto.FirstName;
        user.LastName = userDto.LastName;
        user.Email = userDto.Email;
        await _userRepository.UpdateAsync(user);
    }

    public async Task DeleteUserAsync(string id)
    {
        ApplicationUser user = await _userRepository.GetByIdAsync(id);
        if (user == null) throw new Exception("User not found");
        await _userRepository.DeleteAsync(id);
    }

    public async Task<UserDto> GetUserByEmailAsync(string email)
    {
        ApplicationUser user = await _userRepository.GetByEmailAsync(email);
        return new UserDto { Id = user.Id, UserName = user.UserName, FirstName = user.FirstName, LastName = user.LastName, Email = user.Email }; ;
    }
}