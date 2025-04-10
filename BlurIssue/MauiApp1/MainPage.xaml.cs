namespace MauiApp1;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		//InitializeComponent();

		var rootScrollView = new ScrollView();
		var verticalStackLayout = new VerticalStackLayout()
		{
			Padding = new Thickness(30, 0),
			Spacing = 25,
			VerticalOptions = LayoutOptions.Center
		};

		var graphicsView = new GraphicsView()
		{
			HeightRequest = 300,
			WidthRequest = 400,
			Drawable = new GraphicsDrawable()
		};

		verticalStackLayout.Children.Add(graphicsView);
		rootScrollView.Content = verticalStackLayout;
		Content = rootScrollView;
	}
}

public class GraphicsDrawable : IDrawable
{
	public void Draw(ICanvas canvas, RectF dirtyRect)
	{
		IBlurrableCanvas blurrableCanvas = new ScalingCanvas(canvas);

		blurrableCanvas.SetBlur(10);

		//Drawing code goes here
		IPattern pattern;

		//Create a 10x10 template for the pattern
		using (PictureCanvas picture = new PictureCanvas(0, 0, 10, 10))
		{
			picture.StrokeColor = Colors.Silver;
			picture.DrawLine(0, 0, 10, 10);
			picture.DrawLine(0, 10, 10, 0);
			pattern = new PicturePattern(picture.Picture, 10, 10);
		}

		// Fill the rectangle with the 10x10 pattern
		PatternPaint patternPaint = new PatternPaint
		{
			Pattern = pattern
		};
		canvas.SetFillPaint(patternPaint, RectF.Zero);
		canvas.FillRectangle(10, 10, 250, 250);
	}
}

