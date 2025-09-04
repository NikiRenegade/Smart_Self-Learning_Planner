using Microsoft.Extensions.Logging;
using SmartLearningPlanner.MobileApp.Services;
using SmartLearningPlanner.MobileApp.Services.Auth;
using SmartLearningPlanner.MobileApp.Services.Auth.Interfaces;
using SmartLearningPlanner.MobileApp.Services.Auth.Strategies;
using SmartLearningPlanner.MobileApp.Services.Quiz.Factories;
using SmartLearningPlanner.MobileApp.ViewModels;
using SmartLearningPlanner.MobileApp.Views;
using SmartLearningPlanner.MobileApp.Options;
using SmartLearningPlanner.MobileApp.Views.Pages;
using SmartLearningPlanner.MobileApp.Services.Quiz;
using CommunityToolkit.Maui;

namespace SmartLearningPlanner.MobileApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();

		builder
	.UseMauiApp<App>()
	.UseMauiCommunityToolkit()
	.ConfigureFonts(fonts =>
	{
		fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
		fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
	});
		builder.Services.AddSingleton(sp =>
			 {
				 return new HttpClient();
			 });
		builder.Services.AddTransient<IRegisterService, RegisterService>();
		builder.Services.AddTransient<LoginViewModel>();
		builder.Services.AddTransient<LoginPage>();
		builder.Services.AddTransient<RegisterViewModel>();
		builder.Services.AddTransient<RegisterPage>();
		builder.Services.AddSingleton<AuthContext>();
		builder.Services.AddTransient<CredentialAuthStrategyService>();
		builder.Services.AddTransient<VkAuthStrategyService>();
		builder.Services.AddTransient<YandexAuthStrategyService>();
		builder.Services.AddSingleton<IUserSessionService, UserSessionService>();
		builder.Services.AddTransient<QuizEditViewModel>();
		builder.Services.AddTransient<QuizEditPage>();
		builder.Services.AddTransient<QuizListViewModel>();
		builder.Services.AddTransient<QuizListPage>();
		builder.Services.AddSingleton<IQuestionFactory, SingleChoiceQuestionFactory>();
		builder.Services.AddSingleton<IQuestionFactory, MultipleChoiceQuestionFactory>();
		builder.Services.AddSingleton<IQuestionFactory, TextAnswerQuestionFactory>();
		builder.Services.AddSingleton<QuestionFactoryRegistry>();
		builder.Services.AddTransient<ApiClient>();
		builder.Services.AddTransient<IQuizService, QuizService>();
		builder.Services.AddTransient<IAuthApiClient, AuthApiClient>();
		builder.Services.AddSingleton(new ApiOptions
		{
			BaseUrl = "http://127.0.0.1:5188/api"
		});


#if DEBUG
		builder.Logging.AddDebug();
#endif

		// Register HttpClient
		string BaseUrl = DeviceInfo.Platform == DevicePlatform.Android
																? "http://192.168.1.100:5188/api/"
																: "http://localhost:5188/api/";
		builder.Services.AddTransient<JwtAuthHandler>();
		builder.Services.AddHttpClient<IRoadmapService, RoadmapService>(client =>
		{
			client.BaseAddress = new Uri(BaseUrl);
			// Добавлять токен будет DelegatingHandler (см. ниже)
		})
.AddHttpMessageHandler<JwtAuthHandler>();

		// Register services
		builder.Services.AddSingleton<IRoadmapService, RoadmapService>();

		builder.Services.AddTransient<CreateRoadmapViewModel>();
		builder.Services.AddTransient<CreateRoadmapPage>();

		// Регистрация ViewModel и страницы
		builder.Services.AddSingleton<RoadmapListViewModel>();
		builder.Services.AddSingleton<MyRoadmapsPage>();

		//builder.Services.AddTransient<RoadmapDetailViewModel>();

		builder.Services.AddSingleton<RoadmapViewModel>();
		builder.Services.AddTransient<RoadmapViewerPage>();

		return builder.Build();
	}
}