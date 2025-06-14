using System.Text;
using System.Text.Json;
using SmartLearningPlanner.MobileApp.Options;
namespace SmartLearningPlanner.MobileApp.Services;

public class CredentialAuthStrategyService : IAuthStrategyService
{
	private const string BaseUrl = "http://127.0.0.1:5188/api/users";
	private string _email;
	private string _password;
	private readonly HttpClient _httpClient;
	private readonly ApiOptions _apiOptions;
	public CredentialAuthStrategyService(HttpClient httpClient, ApiOptions apiOptions)
	{
		_httpClient = httpClient;
		_apiOptions = apiOptions;
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
		var response = await _httpClient.PostAsync($"{_apiOptions.BaseUrl}/users/login", content);
		return response.IsSuccessStatusCode;
	}
}
