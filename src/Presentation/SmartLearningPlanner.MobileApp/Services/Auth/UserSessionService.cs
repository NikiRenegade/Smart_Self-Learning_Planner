using System.Text.Json;
using SmartLearningPlanner.MobileApp.Models;
using SmartLearningPlanner.MobileApp.Services.Auth.Interfaces;


namespace SmartLearningPlanner.MobileApp.Services.Auth;

public class UserSessionService : IUserSessionService
{
	private const string AccessTokenKey = "accessToken";
	private const string RefreshTokenKey = "refreshToken";
	private const string UserProfileKey = "userProfile";
	private readonly IAuthApiClient _authApiClient;

	public UserSessionService(IAuthApiClient authApiClient)
	{
		_authApiClient = authApiClient;
	}
	public string? GetAccessToken() => Preferences.Default.Get<string>(AccessTokenKey, null);
	public string? GetRefreshToken() => Preferences.Default.Get<string>(RefreshTokenKey, null);
	public UserProfileDto? GetUserProfile()
	{
		var json = Preferences.Default.Get<string>(UserProfileKey, null);
		if (string.IsNullOrEmpty(json))
			return null;
		return JsonSerializer.Deserialize<UserProfileDto>(
			json,
			new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
		);
	}
	public void SetAccessToken(JsonElement jsonElement) => SetSessionData(jsonElement, AccessTokenKey);
	public void SetRefreshToken(JsonElement jsonElement) => SetSessionData(jsonElement, RefreshTokenKey);
	public void SetUserProfile(JsonElement jsonElement)
	{
		if (jsonElement.TryGetProperty(UserProfileKey, out var profileElement))
		{
			var userProfile = JsonSerializer.Deserialize<UserProfileDto>(profileElement.GetRawText(), new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true
			});
			if (userProfile != null)
			{
				var json = JsonSerializer.Serialize(userProfile);
				Preferences.Default.Set(UserProfileKey, json);
			}
		}
	}
	public void RemoveAccessToken() => Preferences.Default.Remove(AccessTokenKey);
	public void RemoveRefreshToken() => Preferences.Default.Remove(RefreshTokenKey);

	public bool IsAccessTokenValidLocally() => !string.IsNullOrEmpty(GetAccessToken());
	public bool IsRefreshTokenValidLocally() => !string.IsNullOrEmpty(GetRefreshToken());

	public async Task<bool> ValidateAccessTokenServerAsync()
	{
		var token = GetAccessToken();
		if (string.IsNullOrEmpty(token))
			return false;

		try
		{
			return !string.IsNullOrEmpty(token) && await _authApiClient.ValidateAccessTokenAsync(token);
		}
		catch
		{
			return false;
		}
	}

	private bool SetSessionData(JsonElement jsonElement, string tokenKey)
	{
		string? token = null;
		if (jsonElement.TryGetProperty(tokenKey, out var tokenElement))
		{
			if (tokenElement.ValueKind == JsonValueKind.String)
			{
				token = tokenElement.GetString();
			}
			else if (tokenElement.ValueKind == JsonValueKind.Object &&
							tokenElement.TryGetProperty("result", out var resultElement) &&
							resultElement.ValueKind == JsonValueKind.String)
			{
				token = resultElement.GetString();
			}
		}

		if (!string.IsNullOrEmpty(token))
		{
			Preferences.Default.Set(tokenKey, token);
			return true;
		}

		return false;
	}

	public async Task<bool> ValidateRefreshTokenServerAsync()
	{
		var refreshToken = GetRefreshToken();
		if (string.IsNullOrEmpty(refreshToken))
			return false;
		var response = await _authApiClient.RefreshTokenAsync(refreshToken);
		if (response == null)
			return false;
		SetAccessToken(response.RootElement);
		SetRefreshToken(response.RootElement);
		SetUserProfile(response.RootElement);
		return true;
	}
}
