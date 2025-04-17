using CommunityToolkit.Mvvm.ComponentModel;

namespace SmartLearningPlanner.MobileApp.ViewModels
{
    public partial class RoadmapViewModel : ObservableObject
    {
        [ObservableProperty]
        private RoadmapNode _roadmapData;

        public RoadmapViewModel()
        {
            LoadRoadmapData();
        }

        private void LoadRoadmapData()
        {
            RoadmapData = CreateDetailedRoadmap();
        }

        public RoadmapNode CreateDetailedRoadmap()
        {
            return new RoadmapNode
            {
                Title = "React learning roadmap in 2024",
                IsRoot = true,
                Children = new List<RoadmapNode>
        {
            // 1. TypeScript Section
            new()
            {
                Title = "TypeScript",
                IsCategory = true,
                Children = new List<RoadmapNode>
                {
                    new()
                    {
                        Title = "JSON/props/components",
                        Children = new List<RoadmapNode>
                        {
                            new() { Title = "create-react-app" },
                            new() { Title = "npm/yarn" },
                            new() { Title = "useState" },
                            new() { Title = "useEffect" },
                            new() { Title = "useContext" },
                            new() { Title = "useReducer" },
                            new() { Title = "useCallback" },
                            new() { Title = "useMemo + memo" },
                            new() { Title = "useRef" },
                            new() { Title = "useTransition" },
                            new() { Title = "useDeferredValue" }
                        }
                    }
                }
            },
            
            // 2. Custom Hook Section
            new()
            {
                Title = "Custom hook",
                IsCategory = true,
                Children = new List<RoadmapNode>
                {
                    new() { Title = "@tanstack/react-query" },
                    new() { Title = "useSWR" },
                    new() { Title = "Redux Toolkit" },
                    new() { Title = "Zustand (lightweight)" },
                    new() { Title = "Fast Context" },
                    new()
                    {
                        Title = "Testing",
                        Children = new List<RoadmapNode>
                        {
                            new() { Title = "React Testing Library" },
                            new() { Title = "MSW (Mock Service Worker)" },
                            new() { Title = "Playwright" },
                            new() { Title = "Cypress" }
                        }
                    }
                }
            },
            
            // 3. Basics Section
            new()
            {
                Title = "Basics",
                IsCategory = true,
                Children = new List<RoadmapNode>
                {
                    new() { Title = "TypeScript" },
                    new() { Title = "React" },
                    new()
                    {
                        Title = "Next.js",
                        Children = new List<RoadmapNode>
                        {
                            new() { Title = "App Router" },
                            new() { Title = "File Conventions" },
                            new() { Title = "Server Components" },
                            new() { Title = "Client Components" },
                            new() { Title = "Data Fetching" },
                            new() { Title = "Middleware" }
                        }
                    },
                    new() { Title = "Tailwind CSS" },
                    new() { Title = "shadcn/ui" }
                }
            },
            
            // 4. Advanced Section
            new()
            {
                Title = "Advanced",
                IsCategory = true,
                Children = new List<RoadmapNode>
                {
                    new() { Title = "Performance Optimization" },
                    new() { Title = "SSR/SSG" },
                    new() { Title = "ISR" },
                    new() { Title = "Edge Functions" },
                    new() { Title = "Monorepos" }
                }
            }
        }
            };
        }
    }
}
