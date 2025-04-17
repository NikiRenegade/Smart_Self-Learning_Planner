using SmartLearningPlanner.MobileApp.ViewModels;

namespace SmartLearningPlanner.MobileApp.Views.Pages;

public partial class RoadmapViewerPage : ContentPage
{
	public RoadmapViewerPage(RoadmapViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}