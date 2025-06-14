using SmartLearningPlanner.MobileApp.Models.Responses;
using SmartLearningPlanner.MobileApp.ViewModels;

namespace SmartLearningPlanner.MobileApp.Views.Pages;

public partial class MyRoadmapsPage : ContentPage
{
    private readonly RoadmapListViewModel _viewModel;

    public MyRoadmapsPage(RoadmapListViewModel viewModel)
    {
        InitializeComponent();

        _viewModel = viewModel;
        // Set the ViewModel as the BindingContext
        BindingContext = viewModel;
    }

    private async void OnCreateRoadmapClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CreateRoadmapPage());
    }

    private async void OnRoadmapTapped(object sender, EventArgs e)
    {
        if (sender is Button button)
        {
            var roadmap = (RoadmapResponse)button.BindingContext;
            await Navigation.PushAsync(new RoadmapDetailsPage(roadmap.Id));
        }
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.GetData(); // 👈 здесь вызываем
    }
}