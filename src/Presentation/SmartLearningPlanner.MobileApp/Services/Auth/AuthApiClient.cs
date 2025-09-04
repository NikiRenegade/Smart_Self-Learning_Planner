using System;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using SmartLearningPlanner.MobileApp.Options;
using SmartLearningPlanner.MobileApp.Services.Auth.Interfaces;

namespace SmartLearningPlanner.MobileApp.Services.Auth;

public class AuthApiClient : IAuthApiClient
{
	private readonly HttpClient _httpClient;
	private readonly ApiOptions _apiOptions;

	public AuthApiClient(HttpClient httpClient, ApiOptions apiOptions)
	{
		_httpClient = httpClient;
		_apiOptions = apiOptions;
	}

	public async Task<bool> ValidateAccessTokenAsync(string token)
	{
		_httpClient.DefaultRequestHeaders.Authorization =
				new AuthenticationHeaderValue("Bearer", token);

		var response = await _httpClient.GetAsync(_apiOptions.BaseUrl + "/auth/validate-token");
		return response.IsSuccessStatusCode;
	}

	public async Task<JsonDocument?> RefreshTokenAsync(string refreshToken)
	{
		var response = await _httpClient.PostAsync(
				_apiOptions.BaseUrl + "/auth/refresh-token",
				new StringContent(JsonSerializer.Serialize(new { RefreshToken = refreshToken }),
													Encoding.UTF8, "application/json"));

		if (!response.IsSuccessStatusCode) return null;

		var json = await response.Content.ReadAsStringAsync();
		return JsonSerializer.Deserialize<JsonDocument>(json);
	}
}
