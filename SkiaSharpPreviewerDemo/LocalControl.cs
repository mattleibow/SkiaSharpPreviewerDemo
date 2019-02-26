using System.ComponentModel;
using CustomLibrary;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;

namespace SkiaSharpPreviewerDemo
{
	[DesignTimeVisible(true)]
	public class LocalControl : SKCanvasView, ISkiaControl
	{
		public static readonly BindableProperty TextProperty = SkiaControl.TextProperty;

		public static readonly BindableProperty TextColorProperty = SkiaControl.TextColorProperty;

		public static readonly BindableProperty TextSizeProperty = SkiaControl.TextSizeProperty;

		public static readonly BindableProperty AutoSizeTextProperty = SkiaControl.AutoSizeTextProperty;

		protected override void OnPaintSurface(SKPaintSurfaceEventArgs e)
		{
			base.OnPaintSurface(e);

			SkiaControl.OnPaintSurface(this, e);
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
