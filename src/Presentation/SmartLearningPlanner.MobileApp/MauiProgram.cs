using Microsoft.Extensions.Logging;
using SmartLearningPlanner.MobileApp.Services;
using SmartLearningPlanner.MobileApp.ViewModels;
using SmartLearningPlanner.MobileApp.Views;
using SmartLearningPlanner.MobileApp.Options;
using SmartLearningPlanner.MobileApp.Views.Pages;
namespace SmartLearningPlanner.MobileApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		      
        builder
			.UseMauiApp<App>()
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
		builder.Services.AddSingleton(new ApiOptions
		{
			BaseUrl = "http://127.0.0.1:5188/api"
		});

		#if DEBUG
		builder.Logging.AddDebug();
        #endif

        // Register HttpClient
        string BaseUrl = DeviceInfo.Platform == DevicePlatform.Android
                                    ? "http://10.0.2.2:5188/api/"
                                    : "http://localhost:5188/api/";
        builder.Services.AddHttpClient<IRoadmapService, RoadmapService>(client =>
        {
            client.BaseAddress = new Uri(BaseUrl);
        });

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


        