using System.Text;
using System.Text.Json;
using SmartLearningPlanner.MobileApp.Services.Auth.Interfaces;
namespace SmartLearningPlanner.MobileApp.Services.Auth.Strategies;

public class CredentialAuthStrategyService : IAuthStrategyService
{
	private string _email;
	private string _password;
	private readonly IUserSessionService _userSessionService;
	private readonly ApiClient _apiClient;
	public CredentialAuthStrategyService(IUserSessionService userSessionService, ApiClient apiClient)
	{
		_userSessionService = userSessionService;
		_apiClient = apiClient;
	}
	public void SetEmailAndPassword(string email, string password)
	{
		_email = email;
		_password = password;
	}

	public async Task<bool> LoginAsync()
	{
		var response = await _apiClient.PostAsync<JsonDocument>("auth/login", new { Email = _email, Password = _password });
		if (response == null)
			return false;
		_userSessionService.SetAccessToken(response.RootElement);
		_userSessionService.SetRefreshToken(response.RootElement);
		_userSessionService.SetUserProfile(response.RootElement);


		return true;
	}
}