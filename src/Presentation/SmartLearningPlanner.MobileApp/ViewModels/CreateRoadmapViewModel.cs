using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SmartLearningPlanner.MobileApp.Models;
using SmartLearningPlanner.MobileApp.Services;
using System.Net.Http.Json;

namespace SmartLearningPlanner.MobileApp.ViewModels
{
    public partial class CreateRoadmapViewModel : ObservableObject
    {
        private readonly HttpClient _httpClient;
        private const string ApiUrl = "https://your-api-url.com/api/roadmaps";

        [ObservableProperty]
        private string _title = string.Empty;

        [ObservableProperty]
        private string? _shortDescription = null;

        [ObservableProperty]
        private string _notes = string.Empty;

        [ObservableProperty]
        private string _currentNodeTitle = string.Empty;

        [ObservableProperty]
        private List<RoadmapNode> _nodes = new();

        public CreateRoadmapViewModel()
        {
            _httpClient = new HttpClient();

            // Для дизайнера XAML
            if (DesignMode.IsDesignModeEnabled)
            {
                Title = "Sample Roadmap (Design Mode)";
                Nodes = new List<RoadmapNode>
            {
                new() { Title = "Design Node 1" },
                new() { Title = "Design Node 2" }
            };
            }
        }

        [RelayCommand]
        private void AddRootNodeCommand()
        {
            if (string.IsNullOrWhiteSpace(CurrentNodeTitle)) return;

            Nodes.Add(new RoadmapNode { Title = CurrentNodeTitle });
            CurrentNodeTitle = string.Empty;
        }

        [RelayCommand]
        private async Task CreateRoadmapCommand()
        {
            if (string.IsNullOrWhiteSpace(Title))
            {
                await Shell.Current.DisplayAlert("Error", "Title is required", "OK");
                return;
            }

            try
            {
                var request = new
                {
                    Title,
                    Nodes
                };

                var response = await _httpClient.PostAsJsonAsync(ApiUrl, request);

                if (response.IsSuccessStatusCode)
                {
                    await Shell.Current.DisplayAlert("Success", "Roadmap created", "OK");
                    await Shell.Current.GoToAsync("..");
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    await Shell.Current.DisplayAlert("Error", $"Failed: {error}", "OK");
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", $"Exception: {ex.Message}", "OK");
            }
        }
    }
}

