using System;
using SmartLearningPlanner.Domain.Entities;

namespace SmartLearningPlanner.Domain.Interfaces.Repositories;

public interface IAuthRepository
{
	Task<string> RegisterAsync(ApplicationUser user, string password);
	Task<bool> CheckPasswordAsync(ApplicationUser user, string password);
	Task ChangePasswordAsync(ApplicationUser user, string currentPassword, string newPassword);
	Task ConfirmEmailAsync(string id, string token);

	Task<bool> IsEmailConfirmedAsync(ApplicationUser user);
	Task<bool> AuthenticateAsync(ApplicationUser user, string password);
	Task UpdateRefreshTokenAsync(ApplicationUser user, string refreshToken);
	Task<ApplicationUser> GetUserByRefreshTokenAsync(string refreshToken);
}
