using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLearningPlanner.MobileApp.Models
{
    public class RoadmapResponse
    {
        public int Id { get; set; }

        /// <summary>
        /// Название Roadmap.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ShortDescription { get; set; }

        /// <summary>
        /// Конспект по текущей Roadmap.
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// Итоговый результат выполнения Roadmap.
        /// </summary>
        public string Result { get; set; }

        /// <summary>
        /// Вложенные Roadmap (если есть), представляющие шаги текущей Roadmap.
        /// </summary>
        public List<RoadmapResponse> SubRoadmaps { get; set; } = new();
    }
}
