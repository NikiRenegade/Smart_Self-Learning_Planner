using Microsoft.Maui.Storage;
using SmartLearningPlanner.MobileApp.Services;
using SmartLearningPlanner.MobileApp.Views;

namespace SmartLearningPlanner.MobileApp;

public partial class App : Application
{

	public App()
	{
		InitializeComponent();
	}
	private readonly ITokenService _tokenService;
	public App(ITokenService tokenService)
	{
		InitializeComponent();
		_tokenService = tokenService;

		MainPage = new ContentPage();

		Task.Run(async () =>
{
	bool isValid = false;

	try
	{
		isValid = await _tokenService.ValidateAccessTokenServerAsync();

		if (!isValid)
		{
			isValid = await _tokenService.ValidateRefreshTokenServerAsync();
		}
	}
	catch (Exception ex)
	{
		System.Diagnostics.Debug.WriteLine($"[Auth Init Error] {ex}");
	}

	MainThread.BeginInvokeOnMainThread(() =>
	{
		MainPage = isValid
			? new AppShell()
			: new LoginShell();
	});
});

	}
}

