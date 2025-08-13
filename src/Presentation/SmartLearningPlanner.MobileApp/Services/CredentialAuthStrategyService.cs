using System.Text;
using System.Text.Json;
using Microsoft.Maui.Storage; // Для Preferences
using SmartLearningPlanner.MobileApp.Options;
namespace SmartLearningPlanner.MobileApp.Services;

public class CredentialAuthStrategyService : IAuthStrategyService
{
	private string _email;
	private string _password;
	private readonly HttpClient _httpClient;
	private readonly ApiOptions _apiOptions;
	private readonly ITokenService _tokenService;
	public CredentialAuthStrategyService(HttpClient httpClient, ApiOptions apiOptions, ITokenService tokenService)
	{
		_httpClient = httpClient;
		_apiOptions = apiOptions;
		_tokenService = tokenService;
	}
	public void SetEmailAndPassword(string email, string password)
	{
		_email = email;
		_password = password;
	}

	public async Task<bool> LoginAsync()
	{
		var json = JsonSerializer.Serialize(new { Email = _email, Password = _password });
		var content = new StringContent(json, Encoding.UTF8, "application/json");
		var response = await _httpClient.PostAsync($"{_apiOptions.BaseUrl}/auth/login", content);
		if (!response.IsSuccessStatusCode)
			return false;

		var responseBody = await response.Content.ReadAsStringAsync();
		using var doc = JsonDocument.Parse(responseBody);

		string? token = null;
		var tokenElement = doc.RootElement;
		_tokenService.SetAccessToken(doc.RootElement);
		_tokenService.SetRefreshToken(doc.RootElement);
		return true;
	}
}