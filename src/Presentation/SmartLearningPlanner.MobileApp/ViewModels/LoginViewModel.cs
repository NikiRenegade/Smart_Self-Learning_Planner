using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using SmartLearningPlanner.MobileApp.Views;
using SmartLearningPlanner.MobileApp.Services;
namespace SmartLearningPlanner.MobileApp.ViewModels;

public partial class LoginViewModel : ObservableObject
{
	private readonly AuthContext _authContext;
	private readonly HttpClient _httpClient;
	private readonly IServiceProvider _serviceProvider;

	[ObservableProperty]
	private string email;

	[ObservableProperty]
	private string password;

	public ICommand NavigateToRegisterCommand { get; }
	public ICommand LoginCommand { get; }
	public ICommand VkLoginCommand { get; }
	public ICommand YandexLoginCommand { get; }

	public LoginViewModel(AuthContext authContext, HttpClient httpClient, IServiceProvider serviceProvider)
	{
		_authContext = authContext;
		_httpClient = httpClient;
		_serviceProvider = serviceProvider;
		NavigateToRegisterCommand = new RelayCommand(OnNavigateToRegister);
		LoginCommand = new AsyncRelayCommand(LoginWithCredentialsAsync);
		VkLoginCommand = new AsyncRelayCommand(LoginWithVkAsync);
		YandexLoginCommand = new AsyncRelayCommand(LoginWithYandexAsync);
	}
	private async void OnNavigateToRegister()
	{
		await Shell.Current.GoToAsync(nameof(RegisterPage));
	}
	private async Task LoginWithCredentialsAsync()
	{
		var strategy = _serviceProvider.GetRequiredService<CredentialAuthStrategyService>();
		strategy.SetEmailAndPassword(email, password);
		_authContext.SetStrategy(strategy);
		await PerformLogin();
	}

	private async Task LoginWithVkAsync()
	{
		var strategy = _serviceProvider.GetRequiredService<VkAuthStrategyService>();
		_authContext.SetStrategy(strategy);
		await PerformLogin();
	}

	private async Task LoginWithYandexAsync()
	{
		var strategy = _serviceProvider.GetRequiredService<YandexAuthStrategyService>();
		_authContext.SetStrategy(strategy);
		await PerformLogin();
	}
	private async Task PerformLogin()
	{
		var success = await _authContext.LoginAsync();
		if (success)
		{
			await Shell.Current.DisplayAlert("Успех", "Вы вошли в систему", "OK");
			//await Shell.Current.GoToAsync("..");
		}
		else
		{
			await Shell.Current.DisplayAlert("Ошибка", "Не удалось войти", "OK");
		}
	}


}
