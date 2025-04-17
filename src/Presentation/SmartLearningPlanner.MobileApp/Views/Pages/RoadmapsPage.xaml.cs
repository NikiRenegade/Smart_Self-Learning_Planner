using SmartLearningPlanner.MobileApp.Models;
using System.Net.Http.Json;

namespace SmartLearningPlanner.MobileApp.Views.Pages;

public partial class RoadmapsPage : ContentPage
{
    private readonly HttpClient _httpClient = new HttpClient();
    private const string ApiBaseUrl = "https://localhost:7160/api/roadmaps";

    public RoadmapsPage()
	{
		InitializeComponent();
        LoadRoadmaps();
    }

    /*private async void LoadRoadmaps()
    {
        try
        {
            var response = await _httpClient.GetAsync(ApiBaseUrl);
            if (response.IsSuccessStatusCode)
            {
                //  var roadmaps = await response.Content.ReadFromJsonAsync<List<Roadmap>>();
                //  RoadmapListView.ItemsSource = roadmaps;
            }
        }
        catch (Exception ex)
        {
         
        }
    }*/

    private async void OnRoadmapClicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        //  var roadmap = (Roadmap)button.BindingContext;
        //  await Navigation.PushAsync(new RoadmapDetailPage(roadmap.Id));
    }

    private async void OnCreateRoadmapClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CreateRoadmapPage());
    }

    private void LoadRoadmaps()
    {
        var roadmaps = new List<RoadmapResponse>
        {
            new RoadmapResponse
            {
                Id = 1,
                Title = "Основы TypeScript",
                ShortDescription = "Изучение основ TypeScript для работы с React.",
                Notes = "Пройти все уроки по основам TypeScript и научиться работать с типами и интерфейсами.",
                Result = "Готовность к созданию приложений на TypeScript.",
                SubRoadmaps = new List<RoadmapResponse>
                {
                    new RoadmapResponse
                    {
                        Id = 2,
                        Title = "Типы данных в TypeScript",
                        ShortDescription = "Изучение базовых типов данных в TypeScript.",
                        Notes = "Научиться работать с числами, строками, булевыми значениями и массивами.",
                        Result = "Освоение базовых типов данных."
                    },
                    new RoadmapResponse
                    {
                        Id = 3,
                        Title = "Модули и пространства имен",
                        ShortDescription = "Изучение работы с модулями и пространствами имен.",
                        Notes = "Понять как импортировать и экспортировать модули.",
                        Result = "Умение работать с модулями."
                    }
                },               
            },
            new RoadmapResponse
            {
                Id = 4,
                Title = "Работа с React и Next.js",
                ShortDescription = "Создание приложений на React с использованием Next.js.",
                Notes = "Изучить React и его взаимодействие с Next.js.",
                Result = "Умение создавать приложения на React с серверной рендерингом в Next.js.",
            }
        };

        RoadmapListView.ItemsSource = roadmaps;
    }
}