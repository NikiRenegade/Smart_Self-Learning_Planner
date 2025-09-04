using SmartLearningPlanner.MobileApp.Services.Auth.Interfaces;

namespace SmartLearningPlanner.MobileApp;

public partial class App : Application
{

	public App()
	{
		InitializeComponent();
	}
	private readonly IUserSessionService _userSessionService;
	public App(IUserSessionService userSessionService)
	{
		InitializeComponent();
		_userSessionService = userSessionService;

		MainPage = new ContentPage();

		Task.Run(async () =>
{
	bool isValid = false;

	try
	{
		isValid = await _userSessionService.ValidateAccessTokenServerAsync();
		isValid = false;

		if (!isValid)
		{
			isValid = await _userSessionService.ValidateRefreshTokenServerAsync();
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

