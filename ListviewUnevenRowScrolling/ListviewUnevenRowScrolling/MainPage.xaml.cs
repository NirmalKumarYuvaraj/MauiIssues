using System.Collections.ObjectModel;

namespace ListviewUnevenRowScrolling;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
		Init();
	}

	ListView list;
	StackLayout stackLayout;

	ObservableCollection<Person1> Data;
	public static int Count = 0;


	void Init()
	{
		list = new ListView();

		var template = new DataTemplate(typeof(UnevenViewCell));
		list.ItemTemplate = template;

		Data = new ObservableCollection<Person1>();
		list.ItemsSource = Data;
		list.HasUnevenRows = true;

		for (int i = 0; i < 50; i++)
		{
			Data.Add(new Person1
			{
				FullName = "Andrew",
				Address = "404 Somewhere"
			});
		}



		stackLayout = new StackLayout();
		stackLayout.Children.Add(list);

		this.Content = stackLayout;
	}

}
class UnevenViewCell : ViewCell
{
	public UnevenViewCell()
	{

		var label = new Label();
		label.SetBinding(Label.TextProperty, "FullName");
		Height = MainPage.Count % 2 == 0 ? 50 : 100;
		View = label;
		View.BackgroundColor = MainPage.Count % 2 == 0 ? Colors.Pink : Colors.LightYellow;
		MainPage.Count++;
	}
}


class Person1
{
	public string FullName { get; set; }
	public string Address { get; set; }
}







