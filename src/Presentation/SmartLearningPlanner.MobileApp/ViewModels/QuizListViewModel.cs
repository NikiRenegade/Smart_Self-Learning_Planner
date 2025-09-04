using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SmartLearningPlanner.MobileApp.Models.Responses;
using SmartLearningPlanner.MobileApp.Services.Quiz;
using SmartLearningPlanner.MobileApp.Services.Auth.Interfaces;
using System.Collections.ObjectModel;
using SmartLearningPlanner.MobileApp.Views.Pages;
using System.Windows.Input;
namespace SmartLearningPlanner.MobileApp.ViewModels;

public partial class QuizListViewModel : ObservableObject
{
	private readonly IQuizService _quizService;
	private readonly IUserSessionService _userSessionService;

	[ObservableProperty]
	private ObservableCollection<QuizSummaryResponseDto> myQuizzes = new();

	[ObservableProperty]
	private ObservableCollection<QuizSummaryResponseDto> otherQuizzes = new();

	public IAsyncRelayCommand LoadQuizzesCommand { get; }
	public ICommand OpenQuizCommand { get; }
	public ICommand CreateQuizCommand { get; }

	public QuizListViewModel(IQuizService quizService, IUserSessionService userSessionService)
	{
		_quizService = quizService;
		_userSessionService = userSessionService;

		OpenQuizCommand = new Command<QuizSummaryResponseDto>(OpenQuiz);
		CreateQuizCommand = new Command(CreateQuiz);
	}

	public async Task LoadQuizzesAsync()
	{
		var userId = _userSessionService.GetUserProfile().Id;

		MyQuizzes.Clear();
		OtherQuizzes.Clear();

		var quizzes = await _quizService.GetQuizSummariesAsync();

		foreach (var quiz in quizzes)
		{
			if (quiz.CreatedById == userId)
				MyQuizzes.Add(quiz);
			else
				OtherQuizzes.Add(quiz);
		}
	}

	private async void OpenQuiz(QuizSummaryResponseDto quizSummary)
	{
		await Shell.Current.GoToAsync($"{nameof(QuizEditPage)}?quizId={quizSummary.Id}");
	}
	private async void CreateQuiz()
	{
		await Shell.Current.GoToAsync($"{nameof(QuizEditPage)}?quizId=0");
	}
}
