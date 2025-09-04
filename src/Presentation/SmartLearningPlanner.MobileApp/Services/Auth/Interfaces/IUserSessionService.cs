using System.Text.Json;
using SmartLearningPlanner.MobileApp.Models;

namespace SmartLearningPlanner.MobileApp.Services.Auth.Interfaces;

public interface IUserSessionService
{
	string? GetAccessToken();
	public string? GetRefreshToken();
	public UserProfileDto GetUserProfile();
	void SetAccessToken(JsonElement jsonElement);
	void SetRefreshToken(JsonElement jsonElement);
	void RemoveAccessToken();
	bool IsAccessTokenValidLocally();
	Task<bool> ValidateAccessTokenServerAsync();
	Task<bool> ValidateRefreshTokenServerAsync();
	void SetUserProfile(JsonElement jsonElement);

}
