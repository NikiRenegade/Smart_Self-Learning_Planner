using Microsoft.Extensions.Logging;
using SmartLearningPlanner.MobileApp.ViewModels;
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

#if DEBUG
		builder.Logging.AddDebug();
#endif

        builder.Services.AddTransient<CreateRoadmapViewModel>();
        builder.Services.AddTransient<CreateRoadmapPage>();

        // Регистрация ViewModel и страницы
        builder.Services.AddSingleton<RoadmapViewModel>();
        builder.Services.AddTransient<RoadmapViewerPage>();

        return builder.Build();
	}
}

