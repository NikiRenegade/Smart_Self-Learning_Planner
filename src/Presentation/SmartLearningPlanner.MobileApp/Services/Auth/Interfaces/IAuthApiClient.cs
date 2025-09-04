using System;
using System.Text.Json;

namespace SmartLearningPlanner.MobileApp.Services.Auth.Interfaces;

public interface IAuthApiClient
{
	Task<bool> ValidateAccessTokenAsync(string token);
	Task<JsonDocument?> RefreshTokenAsync(string refreshToken);
}
