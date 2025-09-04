using System.Text.Json;
using System.Text;
using System.Net.Http.Headers;
using SmartLearningPlanner.MobileApp.Options;
using SmartLearningPlanner.MobileApp.Services.Auth.Interfaces;
namespace SmartLearningPlanner.MobileApp.Services;

public class ApiClient
{
	private readonly HttpClient _httpClient;
	private readonly ApiOptions _apiOptions;
	private readonly IUserSessionService _tokenService;

	public ApiClient(HttpClient httpClient, ApiOptions apiOptions, IUserSessionService tokenService)
	{
		_apiOptions = apiOptions;
		_httpClient = httpClient;
		_tokenService = tokenService;
	}

	private StringContent Serialize(object data) =>
			new(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");

	public async Task<T?> PostAsync<T>(string url, object body)
	{
		var response = await _httpClient.PostAsync(_apiOptions.BaseUrl + "/" + url, Serialize(body));
		if (!response.IsSuccessStatusCode)
			throw new Exception(await response.Content.ReadAsStringAsync());

		var json = await response.Content.ReadAsStringAsync();
		if (string.IsNullOrEmpty(json))
		{
			return default;
		}

		return JsonSerializer.Deserialize<T>(json);

	}

	public async Task<bool> PostAsync(string url, object body)
	{
		var response = await _httpClient.PostAsync(_apiOptions.BaseUrl + "/" + url, Serialize(body));
		return response.IsSuccessStatusCode;
	}

	public async Task<T?> GetAsync<T>(string url, bool requireAuth = false)
	{
		if (requireAuth)
		{
			var token = _tokenService.GetAccessToken();
			if (string.IsNullOrEmpty(token))
				throw new UnauthorizedAccessException("Нет access token");

			_httpClient.DefaultRequestHeaders.Authorization =
					new AuthenticationHeaderValue("Bearer", token);
		}
		var response = await _httpClient.GetAsync(_apiOptions.BaseUrl + "/" + url);
		if (!response.IsSuccessStatusCode)
			throw new Exception(await response.Content.ReadAsStringAsync());

		var json = await response.Content.ReadAsStringAsync();
		return JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions
		{
			PropertyNameCaseInsensitive = true
		}); ;
	}

	public async Task<bool> GetStatusAsync(string url, string? token = null)
	{
		if (!string.IsNullOrEmpty(token))
			_httpClient.DefaultRequestHeaders.Authorization =
					new AuthenticationHeaderValue("Bearer", token);

		var response = await _httpClient.GetAsync(url);
		return response.IsSuccessStatusCode;
	}

	public async Task<bool> DeleteAsync(string url, bool requireAuth = false)
	{
		if (requireAuth)
		{
			var token = _tokenService.GetAccessToken();
			if (string.IsNullOrEmpty(token))
				throw new UnauthorizedAccessException("Нет access token");

			_httpClient.DefaultRequestHeaders.Authorization =
					new AuthenticationHeaderValue("Bearer", token);
		}

		var response = await _httpClient.DeleteAsync(_apiOptions.BaseUrl + "/" + url);

		if (!response.IsSuccessStatusCode)
			throw new Exception(await response.Content.ReadAsStringAsync());

		return true;
	}
	public async Task<T?> PutAsync<T>(string url, object body)
	{
		var response = await _httpClient.PutAsync(_apiOptions.BaseUrl + "/" + url, Serialize(body));
		if (!response.IsSuccessStatusCode)
			throw new Exception(await response.Content.ReadAsStringAsync());

		var json = await response.Content.ReadAsStringAsync();
		if (string.IsNullOrEmpty(json))
		{
			return default;
		}

		return JsonSerializer.Deserialize<T>(json);
	}

}

