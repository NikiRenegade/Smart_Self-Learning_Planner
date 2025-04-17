using SmartLearningPlanner.MobileApp.Models.Responses;
using SmartLearningPlanner.MobileApp.Services;
using System.ComponentModel;

namespace SmartLearningPlanner.MobileApp.ViewModels
{
    public class RoadmapDetailViewModel : INotifyPropertyChanged
    {
        public readonly IRoadmapService _roadmapService;

        public RoadmapDetailResponse RoadmapDetail { get; private set; }


        public RoadmapDetailViewModel(IRoadmapService roadmapService)
        {
            _roadmapService = roadmapService;
            //GetData();
        }

        public async Task GetData(int roadmapId)
        {
            RoadmapDetail = await _roadmapService.GetRoadmapDetailsAsync(roadmapId);
            OnPropertyChanged(nameof(RoadmapDetail));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
