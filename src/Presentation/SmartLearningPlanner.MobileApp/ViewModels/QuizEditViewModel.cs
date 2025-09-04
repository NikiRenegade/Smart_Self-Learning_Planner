using System.Collections.ObjectModel;
using System.Windows.Input;
using SmartLearningPlanner.MobileApp.Models;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using SmartLearningPlanner.MobileApp.Services.Quiz.Factories;
using SmartLearningPlanner.MobileApp.Services.Quiz;
using System.Threading.Tasks;
using SmartLearningPlanner.MobileApp.Services.Auth.Interfaces;
namespace SmartLearningPlanner.MobileApp.ViewModels;

public partial class QuizEditViewModel : ObservableObject
{
	private readonly IQuizService _quizService;
	private readonly IUserSessionService _userSessionService;

	[ObservableProperty]
	private Quiz quiz;

	private int quizId;

	public ObservableCollection<QuizQuestion> Questions { get; } = new();
	public ObservableCollection<QuizQuestionType> AvailableQuestionTypes { get; } = new();

	private QuizQuestionType _selectedQuestionType;
	public QuizQuestionType SelectedQuestionType
	{
		get => _selectedQuestionType;
		set => SetProperty(ref _selectedQuestionType, value);
	}

	public int QuizId
	{
		get => quizId;
		set
		{
			quizId = value;
		}
	}

	public ICommand AddQuestionCommand { get; }
	public ICommand AddOptionCommand { get; }
	public ICommand RemoveQuestionCommand { get; }
	public ICommand RemoveOptionCommand { get; }
	public ICommand SaveQuizCommand { get; }
	public ICommand RemoveQuizCommand { get; }

	public string Title { get; set; }
	public string Description { get; set; }

	private readonly QuestionFactoryRegistry _factoryRegistry;

	public QuizEditViewModel(QuestionFactoryRegistry factoryRegistry, IQuizService quizService, IUserSessionService userSessionService)
	{
		_factoryRegistry = factoryRegistry;
		_quizService = quizService;
		_userSessionService = userSessionService;
		Quiz = new Quiz { CreatedById = _userSessionService.GetUserProfile().Id };
		AddQuestionCommand = new Command(() =>
		{
			if (SelectedQuestionType == null) return;
			Quiz.QuizQuestions.Add(_factoryRegistry.CreateQuestion(SelectedQuestionType));
			OnPropertyChanged(nameof(Quiz.QuizQuestions));
		});

		AddOptionCommand = new Command<QuizQuestion>(q =>
		{
			q?.QuizQuestionAnswerOptions.Add(new QuizQuestionAnswerOption { AnswerText = string.Empty, QuizQuestion = q });
			OnPropertyChanged(nameof(Quiz.QuizQuestions));
		});

		RemoveQuestionCommand = new Command<QuizQuestion>(q =>
		{
			if (q != null) Quiz.QuizQuestions.Remove(q);
			OnPropertyChanged(nameof(Quiz.QuizQuestions));
		});
		RemoveQuizCommand = new Command(async () =>
		{
			if (Quiz == null) return;
			try
			{
				await _quizService.DeleteQuizAsync(Quiz.Id.Value);
				await Application.Current.MainPage.DisplayAlert("Успех", "Квиз удалён", "OK");

				await Shell.Current.GoToAsync("..");
			}
			catch (Exception ex)
			{
				await Application.Current.MainPage.DisplayAlert("Ошибка", ex.Message, "OK");
			}
		});

		RemoveOptionCommand = new Command<QuizQuestionAnswerOption>(opt =>
		{
			if (opt == null) return;
			var parent = Quiz.QuizQuestions.FirstOrDefault(q => q.QuizQuestionAnswerOptions.Contains(opt));
			parent?.QuizQuestionAnswerOptions.Remove(opt);
			OnPropertyChanged(nameof(Quiz.QuizQuestions));
		});

		SaveQuizCommand = new Command(async () =>
		{
			try
			{
				await _quizService.SaveQuizAsync(Quiz);
				await Application.Current.MainPage.DisplayAlert("Успех", "Квиз сохранен!", "OK");
				await Shell.Current.GoToAsync("..");
			}
			catch (Exception ex)
			{
				await Application.Current.MainPage.DisplayAlert("Ошибка", ex.Message, "OK");
			}
		});

	}

	public async Task LoadQuizAsync(int id)
	{
		var userId = _userSessionService.GetUserProfile()?.Id;
		if (id == 0)
		{
			Quiz = new Quiz();
			Quiz.CreatedById = userId;
		}
		else
		{
			var quiz = await _quizService.GetQuizByIdAsync(id);
			if (quiz.CreatedById == userId)
			{
				Quiz = quiz;
			}
			else
			{
				Quiz = quiz.Clone();
				Quiz.CreatedById = userId;
			}
		}
	}

	public async Task LoadQuestionTypesAsync()
	{
		try
		{
			AvailableQuestionTypes.Clear();
			var types = await _quizService.GetQuizQuestionTypesAsync();
			foreach (var quizQuestionType in await _quizService.GetQuizQuestionTypesAsync())
			{
				AvailableQuestionTypes.Add(quizQuestionType);
			}
			SelectedQuestionType = AvailableQuestionTypes.FirstOrDefault();
		}
		catch (Exception ex)
		{
			await Application.Current.MainPage.DisplayAlert("Ошибка", ex.Message, "OK");
		}
	}
}


