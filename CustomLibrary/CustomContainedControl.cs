using System.ComponentModel;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;

namespace CustomLibrary
{
	[DesignTimeVisible(true)]
	public class CustomContainedControl : Frame, ISkiaControl
	{
		public static readonly BindableProperty TextProperty = SkiaControl.TextProperty;

		public static readonly BindableProperty TextColorProperty = SkiaControl.TextColorProperty;

		public static readonly BindableProperty TextSizeProperty = SkiaControl.TextSizeProperty;

		public static readonly BindableProperty AutoSizeTextProperty = SkiaControl.AutoSizeTextProperty;

		private readonly SKCanvasView skiaControl;

		public CustomContainedControl()
		{
			skiaControl = new SKCanvasView();
			skiaControl.PaintSurface += OnPaintSurface;

			Content = skiaControl;

			void OnPaintSurface(object sender, SKPaintSurfaceEventArgs e)
			{
				SkiaControl.OnPaintSurface(this, e);
			}
		}

		public void InvalidateSurface()
		{
			skiaControl.InvalidateSurface();
		}

		public string Text
		{
			get => (string)GetValue(TextProperty);
			set => SetValue(TextProperty, value);
		}

		public Color TextColor
		{
			get => (Color)GetValue(TextColorProperty);
			set => SetValue(TextColorProperty, value);
		}

		public float TextSize
		{
			get => (float)GetValue(TextSizeProperty);
			set => SetValue(TextSizeProperty, value);
		}

		public bool AutoSizeText
		{
			get => (bool)GetValue(AutoSizeTextProperty);
			set => SetValue(AutoSizeTextProperty, value);
		}
	}
}
