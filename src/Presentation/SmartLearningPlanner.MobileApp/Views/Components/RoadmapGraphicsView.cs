using SmartLearningPlanner.MobileApp.ViewModels;

namespace SmartLearningPlanner.MobileApp.Views.Components;

public class RoadmapGraphView : GraphicsView
{
    public static readonly BindableProperty RootNodeProperty =
        BindableProperty.Create(nameof(RootNode), typeof(RoadmapNode), typeof(RoadmapGraphView), null,
            propertyChanged: OnRootNodeChanged);

    public RoadmapNode RootNode
    {
        get => (RoadmapNode)GetValue(RootNodeProperty);
        set => SetValue(RootNodeProperty, value);
    }

    public RoadmapGraphView()
    {
        Drawable = new RoadmapDrawable();
        BackgroundColor = Colors.Transparent;
    }

    private static void OnRootNodeChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is RoadmapGraphView view && newValue is RoadmapNode node)
        {
            if (view.Drawable is RoadmapDrawable drawable)
            {
                drawable.RootNode = node;
                view.Invalidate();

                // Пересчет высоты
                view.HeightRequest = CalculateTotalHeight(node);
            }
        }
    }

    private static double CalculateTotalHeight(RoadmapNode node, int level = 0)
    {
        if (node == null) return 0;

        double height = NodeHeight + VerticalSpacing;

        if (node.Children.Any())
        {
            height += node.Children.Max(c => CalculateTotalHeight(c, level + 1));
        }

        return level == 0 ? height + 50 : height;
    }

    private const double NodeHeight = 40;
    private const double VerticalSpacing = 80;
}

public class RoadmapDrawable : IDrawable
{
    private const float NodeWidth = 200f;
    private const float NodeHeight = 40f;
    private const float HorizontalSpacing = 250f;
    private const float VerticalSpacing = 80f;
    private const float LineThickness = 2f;

    public RoadmapNode RootNode { get; set; }
    private Dictionary<RoadmapNode, RectF> _nodePositions = new();

    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        if (RootNode == null) return;

        // Рассчитываем позиции всех узлов
        CalculateNodePositions(RootNode, dirtyRect.Width / 2 - NodeWidth / 2, 50f);

        // Отрисовываем все соединения
        DrawConnections(canvas);

        // Отрисовываем все узлы
        DrawNodes(canvas);
    }

    private void CalculateNodePositions(RoadmapNode node, float x, float y)
    {
        node.Rect = new RectF(x, y, NodeWidth, NodeHeight);
        _nodePositions[node] = node.Rect;

        if (!node.Children.Any()) return;

        float childY = y + NodeHeight + VerticalSpacing;
        float totalWidth = node.Children.Count * HorizontalSpacing;
        float startX = x + NodeWidth / 2 - totalWidth / 2;

        for (int i = 0; i < node.Children.Count; i++)
        {
            CalculateNodePositions(node.Children[i], startX + i * HorizontalSpacing, childY);
        }
    }

    private void DrawConnections(ICanvas canvas)
    {
        canvas.StrokeColor = Colors.Gray;
        canvas.StrokeSize = LineThickness;

        foreach (var node in _nodePositions.Keys)
        {
            foreach (var child in node.Children)
            {
                if (_nodePositions.TryGetValue(child, out var childRect))
                {
                    // Линия от нижней части родителя к верхней части ребенка
                    canvas.DrawLine(
                        node.Rect.X + node.Rect.Width / 2, node.Rect.Bottom,
                        childRect.X + childRect.Width / 2, childRect.Top
                    );
                }
            }
        }
    }

    private void DrawNodes(ICanvas canvas)
    {
        foreach (var node in _nodePositions.Keys)
        {
            var rect = node.Rect;

            // Рисуем прямоугольник
            canvas.FillColor = node.IsRoot ? Color.FromArgb("#FF6B6B") :
                              node.IsCategory ? Color.FromArgb("#6B8EFF") : Color.FromArgb("#F0F0F0");
            canvas.FillRoundedRectangle(rect, 5);

            canvas.StrokeColor = Colors.Gray;
            canvas.StrokeSize = 1;
            canvas.DrawRoundedRectangle(rect, 5);

            // Текст внутри прямоугольника
            canvas.FontColor = node.IsRoot ? Colors.White : Colors.Black;
            canvas.FontSize = node.IsRoot ? 16 : 14;
            canvas.DrawString(node.Title, rect, HorizontalAlignment.Center, VerticalAlignment.Center);
        }
    }
}