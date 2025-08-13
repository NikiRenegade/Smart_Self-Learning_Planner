using System;
using System.Text;
using System.Text.Json;
using SmartLearningPlanner.MobileApp.Options;

namespace SmartLearningPlanner.MobileApp.Services;

public class TokenService : ITokenService
{
	private const string AccessTokenKey = "accessToken";
	private const string RefreshTokenKey = "refreshToken";
	private const string BaseUrl = "http://127.0.0.1:5188/api/auth";
	private readonly ApiOptions _apiOptions;

	private readonly HttpClient _httpClient;

	public TokenService(HttpClient httpClient, ApiOptions apiOptions)
	{
		_apiOptions = apiOptions;
		_httpClient = httpClient;
	}
	public string? GetAccessToken() => Preferences.Default.Get<string>(AccessTokenKey, null);
	public string? GetRefreshToken() => Preferences.Default.Get<string>(RefreshTokenKey, null);
	public void SetAccessToken(JsonElement jsonElement) => SetToken(jsonElement, AccessTokenKey);
	public void SetRefreshToken(JsonElement jsonElement) => SetToken(jsonElement, RefreshTokenKey);
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
			_httpClient.DefaultRequestHeaders.Authorization =
					new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

			var response = await _httpClient.GetAsync($"{_apiOptions.BaseUrl}/auth/validate-token");
			return response.IsSuccessStatusCode;
		}
		catch
		{
			return false;
		}
	}

	private bool SetToken(JsonElement jsonElement, string tokenKey)
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

		var content = new StringContent(
				JsonSerializer.Serialize(new { RefreshToken = refreshToken }),
				Encoding.UTF8,
				"application/json");

		var response = await _httpClient.PostAsync($"{_apiOptions.BaseUrl}/auth/refresh-token", content);
		if (!response.IsSuccessStatusCode)
			return false;

		var json = await response.Content.ReadAsStringAsync();
		var doc = JsonDocument.Parse(json);
		SetAccessToken(doc.RootElement);
		SetRefreshToken(doc.RootElement);
		return true;
	}
}
