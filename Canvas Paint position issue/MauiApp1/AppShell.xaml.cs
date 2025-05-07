namespace MauiApp1;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute("MainPage", typeof(MainPage));
	}
}

public static class HandlerDisconnectBehavior
{
	public static readonly BindableProperty CascadeProperty =
		BindableProperty.CreateAttached("Cascade", typeof(bool), typeof(HandlerDisconnectBehavior), false,
			propertyChanged: CascadeChanged);

	public static readonly BindableProperty SuppressProperty =
		BindableProperty.CreateAttached("Suppress", typeof(bool), typeof(HandlerDisconnectBehavior), false);

	public static bool GetCascade(BindableObject view)
	{
		return (bool)view.GetValue(CascadeProperty);
	}

	public static void SetCascade(BindableObject view, bool value)
	{
		view.SetValue(CascadeProperty, value);
	}

	public static bool GetSuppress(BindableObject view)
	{
		return (bool)view.GetValue(SuppressProperty);
	}

	public static void SetSuppress(BindableObject view, bool value)
	{
		view.SetValue(SuppressProperty, value);
	}

	private static void CascadeChanged(BindableObject view, object oldValue, object newValue)
	{
		if (view is not VisualElement visualElement)
			throw new InvalidOperationException(
				"HandlerDisconnectBehavior.Cascade can only be attached to a VisualElement");

		var attachBehavior = (bool)newValue;
		if (attachBehavior)
			visualElement.Unloaded += OnVisualElementUnloaded;
		else
			visualElement.Unloaded -= OnVisualElementUnloaded;
	}

	private static void OnVisualElementUnloaded(object? sender, EventArgs e)
	{
		if (sender is not VisualElement senderElement)
			return;

		if (GetSuppress(senderElement))
			return;

		var visualTreeElement = (IVisualTreeElement)senderElement;

		Disconnect(visualTreeElement);

		return;

		void Disconnect(IVisualTreeElement element)
		{
			if (element is VisualElement visualElement)
			{
				if (GetSuppress(visualElement))
					return;

				foreach (IVisualTreeElement childElement in element.GetVisualChildren())
					Disconnect(childElement);

				visualElement.Handler?.DisconnectHandler();
			}
		}
	}
}