
namespace MauiApp1
{
	public partial class MainPage : ContentPage
	{
		public List<Item> ItemCollection { get; set; }

		public MainPage()
		{
			InitializeComponent();
			ItemCollection = new List<Item>();
			ItemCollection.Add(new Item() { ItemName = "Item1" });
			//ItemCollection.Add(new Item() { ItemName = "Item2"});
			BindingContext = this;

		}

		public class Item
		{
			public string? ItemName { get; set; }
		}
	}
}
