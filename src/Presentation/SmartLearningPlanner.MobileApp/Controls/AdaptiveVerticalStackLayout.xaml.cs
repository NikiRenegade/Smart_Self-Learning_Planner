
namespace SmartLearningPlanner.MobileApp.Controls;
public class AdaptiveVerticalStackLayout : VerticalStackLayout
{
    public AdaptiveVerticalStackLayout()
    {
        Padding = 20;
        Spacing = 20;
        HorizontalOptions = LayoutOptions.Center;
        VerticalOptions = LayoutOptions.CenterAndExpand;
        WidthRequest = 400;

        this.SizeChanged += OnSizeChanged;
    }

    void OnSizeChanged(object sender, EventArgs e)
    {
        double width = Application.Current.MainPage.Width;

        if (width < 600)
        {
            WidthRequest = 320;
            Spacing = 15;
        }
        else if (width >= 600 && width < 1200)
        {
            WidthRequest = 450;
            Spacing = 20;
        }
        else
        {
            WidthRequest = 1200;
            Spacing = 25;
        }
    }
}