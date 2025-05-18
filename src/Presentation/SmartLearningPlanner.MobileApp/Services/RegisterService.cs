using System.Text;
using System.Text.Json;
using SmartLearningPlanner.MobileApp.Model;
using SmartLearningPlanner.MobileApp.Options;

namespace SmartLearningPlanner.MobileApp.Services;

public class RegisterService : IRegisterService
{
	private readonly HttpClient _httpClient;
	private readonly ApiOptions _apiOptions;
	public RegisterService(HttpClient httpClient, ApiOptions apiOptions)
	{
		_httpClient = httpClient;
		_apiOptions = apiOptions;
	}
	public async Task<bool> RegisterAsync(string userName, string firstName, string lastName, string email,string password)
	{
		RegisterUserDto registerUserDto = new RegisterUserDto {UserName = userName, FirstName= firstName, LastName = lastName,  Password = password, Email = email};
		var json = JsonSerializer.Serialize(registerUserDto);
		var content = new StringContent(json, Encoding.UTF8, "application/json");

		var response = await _httpClient.PostAsync($"{_apiOptions.BaseUrl}/users/register", content);
		return response.IsSuccessStatusCode;
	}
}
