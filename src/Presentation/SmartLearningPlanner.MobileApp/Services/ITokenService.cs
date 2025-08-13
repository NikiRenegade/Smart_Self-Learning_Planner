using System;
using System.Text.Json;

namespace SmartLearningPlanner.MobileApp.Services;

public interface ITokenService
{
	string? GetAccessToken();
	void SetAccessToken(JsonElement jsonElement);
	void SetRefreshToken(JsonElement jsonElement);
	void RemoveAccessToken();
	bool IsAccessTokenValidLocally();
	Task<bool> ValidateAccessTokenServerAsync();
	Task<bool> ValidateRefreshTokenServerAsync();
}
