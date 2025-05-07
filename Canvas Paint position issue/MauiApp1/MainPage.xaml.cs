
namespace MauiApp1;

public partial class MainPage : ContentPage
{
	GraphicsView _graphicsView;
	PaintDrawable _drawable;

	public MainPage()
	{
		InitializeComponent();

		var rootLayout = new VerticalStackLayout() { BackgroundColor = Colors.Red };

		_graphicsView = new GraphicsView()
		{
			HeightRequest = 300,
			WidthRequest = 300
		};
		_drawable = new PaintDrawable();
		_graphicsView.Drawable = _drawable;
		rootLayout.Add(_graphicsView);
		Content = rootLayout;
	}
}

public class PaintDrawable : IDrawable
{

	public void Draw(ICanvas canvas, RectF dirtyRect)
	{
		IPattern pattern;

		// Create a 10x10 template for the pattern
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
		canvas.FillRectangle(0, 0, 250, 250);

	}
}