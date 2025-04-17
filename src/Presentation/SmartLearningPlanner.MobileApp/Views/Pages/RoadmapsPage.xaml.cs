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
                Title = "������ TypeScript",
                ShortDescription = "�������� ����� TypeScript ��� ������ � React.",
                Notes = "������ ��� ����� �� ������� TypeScript � ��������� �������� � ������ � ������������.",
                Result = "���������� � �������� ���������� �� TypeScript.",
                SubRoadmaps = new List<RoadmapResponse>
                {
                    new RoadmapResponse
                    {
                        Id = 2,
                        Title = "���� ������ � TypeScript",
                        ShortDescription = "�������� ������� ����� ������ � TypeScript.",
                        Notes = "��������� �������� � �������, ��������, �������� ���������� � ���������.",
                        Result = "�������� ������� ����� ������."
                    },
                    new RoadmapResponse
                    {
                        Id = 3,
                        Title = "������ � ������������ ����",
                        ShortDescription = "�������� ������ � �������� � �������������� ����.",
                        Notes = "������ ��� ������������� � �������������� ������.",
                        Result = "������ �������� � ��������."
                    }
                },               
            },
            new RoadmapResponse
            {
                Id = 4,
                Title = "������ � React � Next.js",
                ShortDescription = "�������� ���������� �� React � �������������� Next.js.",
                Notes = "������� React � ��� �������������� � Next.js.",
                Result = "������ ��������� ���������� �� React � ��������� ����������� � Next.js.",
            }
        };

        RoadmapListView.ItemsSource = roadmaps;
    }
}