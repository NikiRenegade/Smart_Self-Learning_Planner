using SmartLearningPlanner.MobileApp.ViewModels;

namespace SmartLearningPlanner.MobileApp.Views.Pages;

public partial class QuizListPage : ContentPage
{
	private readonly QuizListViewModel _viewModel;
	public QuizListPage(QuizListViewModel viewModel)
	{

		InitializeComponent();
		BindingContext = _viewModel = viewModel;

	}
	protected override async void OnAppearing()
	{
		base.OnAppearing();
		// Здесь вызываем асинхронную загрузку данных
		await _viewModel.LoadQuizzesAsync();
	}
}