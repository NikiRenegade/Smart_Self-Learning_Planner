using SmartLearningPlanner.MobileApp.ViewModels;

namespace SmartLearningPlanner.MobileApp.Views.Pages;

public partial class RoadmapDetailsPage : ContentPage
{
    private readonly RoadmapDetailViewModel _viewModel;

    public RoadmapDetailsPage(int roadmapId)
    {
        InitializeComponent();

      //  _viewModel = viewModel;
        // Set the ViewModel as the BindingContext
       // BindingContext = viewModel;
    }

    private async void LoadData(int roadmapId)
    {
        await _viewModel.GetData(roadmapId);
    }
}