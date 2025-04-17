using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLearningPlanner.MobileApp.Models.Responses
{
    public class RoadmapResponse
    {
        public int Id { get; set; }

        /// <summary>
        /// Название Roadmap.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Краткое описание
        /// </summary>
        public string ShortDescription { get; set; }

        /// <summary>
        /// Потомки
        /// </summary>
        public IEnumerable<RoadmapResponse> Children { get; set; }
    }
}
