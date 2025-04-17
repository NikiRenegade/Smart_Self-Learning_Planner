namespace SmartLearningPlanner.MobileApp.Models
{
    public class CreateRoadmapRequest
    {
        public string Title { get; set; }
        public List<RoadmapNode> Nodes { get; set; } = new();

        public class RoadmapNode
        {
            public string Title { get; set; }
            public List<RoadmapNode> Children { get; set; } = new();
        }
    }
}
