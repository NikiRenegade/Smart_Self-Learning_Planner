using System.Text;
using System.Text.Json;
using SmartLearningPlanner.MobileApp.Models;
using SmartLearningPlanner.MobileApp.Services.Auth.Interfaces;

namespace SmartLearningPlanner.MobileApp.Services.Auth;

public class RegisterService : IRegisterService
{
	private readonly ApiClient _apiClient;
	public RegisterService(ApiClient apiClient)
	{
		_apiClient = apiClient;
	}
	public async Task<bool> RegisterAsync(string userName, string firstName, string lastName, string email, string password)
	{
		RegisterUserDto registerUserDto = new RegisterUserDto { UserName = userName, FirstName = firstName, LastName = lastName, Password = password, Email = email };
		return await _apiClient.PostAsync("auth/register", registerUserDto);
	}
}
