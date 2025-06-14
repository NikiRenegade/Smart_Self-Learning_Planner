using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SmartLearningPlanner.MobileApp.Services;
namespace SmartLearningPlanner.MobileApp.ViewModels;

public partial class RegisterViewModel : ObservableObject
{
	private readonly IRegisterService _registerService;


	[ObservableProperty]
	private string userName;

	[ObservableProperty]
	private string firstName;

	[ObservableProperty]
	private string lastName;

	[ObservableProperty]
	private string email;

	[ObservableProperty]
	private string password;

	public ICommand RegisterCommand { get; }

	public RegisterViewModel(IRegisterService registerService)
	{
		_registerService = registerService;
		RegisterCommand = new AsyncRelayCommand(RegisterAsync);
	}

	private async Task RegisterAsync()
	{
		var result = await _registerService.RegisterAsync(UserName, FirstName, LastName, Email, Password);
		if (result)
		{
			await Shell.Current.DisplayAlert("Успех", "Вы успешно зарегистрированы!", "OK");
			//await Shell.Current.GoToAsync(".."); 
		}
		else
		{
			await Shell.Current.DisplayAlert("Ошибка", "Не удалось зарегистрироваться.", "OK");
		}
	}
}
	
