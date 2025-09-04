using SmartLearningPlanner.MobileApp.ViewModels;

namespace SmartLearningPlanner.MobileApp.Views.Pages;

[QueryProperty(nameof(QuizId), "quizId")]
public partial class QuizEditPage : ContentPage
{
	public string QuizId { get; set; }

	private readonly QuizEditViewModel _viewModel;

	public QuizEditPage(QuizEditViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}

	protected override async void OnAppearing()
	{
		base.OnAppearing();
		await _viewModel.LoadQuestionTypesAsync();
		if (int.TryParse(QuizId, out var id))
		{
			await _viewModel.LoadQuizAsync(id);
			if (_viewModel.Quiz.Id != null)
			{
				ToolbarItems.Add(new ToolbarItem
				{
					Text = "Удалить квиз",
					Order = ToolbarItemOrder.Primary,
					Priority = 0,
					Command = _viewModel.RemoveQuizCommand
				});
			}



		}

	}
}