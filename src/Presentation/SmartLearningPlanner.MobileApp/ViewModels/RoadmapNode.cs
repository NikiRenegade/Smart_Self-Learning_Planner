using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLearningPlanner.MobileApp.ViewModels
{
    public class RoadmapNode
    {
        public string Title { get; set; }

        public List<RoadmapNode> Children { get; set; } = new();

        public RectF Rect { get; set; } // Позиция и размер узла на canvas

        public bool IsRoot { get; set; }

        public bool IsCategory { get; set; }
    }
}
