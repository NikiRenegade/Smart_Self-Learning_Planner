using System;
using SmartLearningPlanner.Application.DTOs;

namespace SmartLearningPlanner.Application.Interfaces;

public interface IAuthService
{
	Task<bool> RegisterUserAsync(RegisterUserDto registerUserDto);
	Task ChangePasswordAsync(ChangePasswordDto changePasswordDto);
	Task<bool> CheckPasswordAsync(string id, string password);
	Task ConfirmEmailAsync(string id, string token);
	Task<bool> LoginAsync(LoginDto loginDto);
	Task<bool> IsEmailConfirmedAsync(string email);
	Task<AccessTokenUserDto> GetAccessTokenUserDtoAsync(string email);
	Task<string> UpdateRefreshTokenAsync(string email);
	Task<RefreshTokenUserDto> GetRefreshTokenUserDtoAsync(string refreshToken);

}
