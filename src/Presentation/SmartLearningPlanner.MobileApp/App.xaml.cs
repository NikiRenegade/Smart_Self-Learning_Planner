using SmartLearningPlanner.MobileApp.Views;

namespace SmartLearningPlanner.MobileApp;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}

