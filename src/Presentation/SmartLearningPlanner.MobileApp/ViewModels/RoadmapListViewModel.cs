using SmartLearningPlanner.MobileApp.Models.Responses;
using SmartLearningPlanner.MobileApp.Services;
using System.ComponentModel;

namespace SmartLearningPlanner.MobileApp.ViewModels
{
    public class RoadmapListViewModel : INotifyPropertyChanged
    {
        public readonly IRoadmapService _roadmapService;

        public IEnumerable<RoadmapResponse> Roadmaps { get; private set; }


        public RoadmapListViewModel(IRoadmapService roadmapService)
        {
            _roadmapService = roadmapService;
        }

        public async Task GetData()
        {
            Roadmaps = await _roadmapService.GetRoadmapsAsync();
            OnPropertyChanged(nameof(Roadmaps));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
