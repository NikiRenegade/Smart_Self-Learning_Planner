using SmartLearningPlanner.MobileApp.ViewModels;

namespace SmartLearningPlanner.MobileApp.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginViewModel loginViewModel)
	{
		InitializeComponent();
		BindingContext = loginViewModel;
	}
}