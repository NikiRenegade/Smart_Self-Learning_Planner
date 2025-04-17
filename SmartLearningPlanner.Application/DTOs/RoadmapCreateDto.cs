using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLearningPlanner.Application.DTOs
{
    public class RoadmapCreateDto
    {
        /// <summary>
        /// Название Roadmap.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string? ShortDescription { get; set; }
    }
}
