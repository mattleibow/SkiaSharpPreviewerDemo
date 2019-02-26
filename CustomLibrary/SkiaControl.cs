using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;

namespace CustomLibrary
{
	public interface ISkiaControl
	{
		void InvalidateSurface();
	}

	public static class SkiaControl
	{
		public static readonly BindableProperty TextProperty = BindableProperty.Create(
			"Text", typeof(string), typeof(ISkiaControl), null, propertyChanged: OnPropertyChanged);

		public static readonly BindableProperty TextColorProperty = BindableProperty.Create(
			"TextColor", typeof(Color), typeof(ISkiaControl), Color.Default, propertyChanged: OnPropertyChanged);

		public static readonly BindableProperty TextSizeProperty = BindableProperty.Create(
			"TextSize", typeof(float), typeof(ISkiaControl), 12.0f, propertyChanged: OnPropertyChanged);

		public static readonly BindableProperty AutoSizeTextProperty = BindableProperty.Create(
			"AutoSizeText", typeof(bool), typeof(ISkiaControl), true, propertyChanged: OnPropertyChanged);

		public static void OnPaintSurface(BindableObject bindable, SKPaintSurfaceEventArgs e)
		{
			var canvas = e.Surface.Canvas;

			canvas.Clear(SKColors.Transparent);

			var text = (string)bindable.GetValue(TextProperty);

			if (string.IsNullOrEmpty(text))
				return;

			var textColor = (Color)bindable.GetValue(TextColorProperty);
			var autoSizeText = (bool)bindable.GetValue(AutoSizeTextProperty);

			using (var paint = new SKPaint())
			{
				paint.IsAntialias = true;
				paint.Color = textColor == Color.Default ? SKColors.Black : textColor.ToSKColor();

				var width = (float)e.Info.Width;
				var height = (float)e.Info.Height;

				if (autoSizeText)
				{
					paint.TextSize = e.Info.Height;

					var rect = SKRect.Empty;
					paint.MeasureText(text, ref rect);

					if (rect.Width > width)
					{
						var ratio = rect.Height / rect.Width;
						rect.Size = new SKSize(width, width * ratio);
					}

					if (rect.Height > height)
					{
						var ratio = rect.Width / rect.Height;
						rect.Size = new SKSize(height * ratio, height);
					}

					paint.TextSize = rect.Height;
				}
				else
				{
					var viewWidth = (double)bindable.GetValue(VisualElement.WidthProperty);
					var textSize = (float)bindable.GetValue(TextSizeProperty);

					var scale = width / (float)viewWidth;
					paint.TextSize = textSize * scale;
				}

				var actualRect = SKRect.Empty;
				var textWidth = paint.MeasureText(text, ref actualRect);
				var x = (width - textWidth) / 2f;
				var y = (height + actualRect.Height) / 2f - actualRect.Bottom;

				canvas.DrawText(text, x, y, paint);
			}
		}

		private static void OnPropertyChanged(BindableObject bindable, object oldValue, object newValue)
		{
			if (bindable is ISkiaControl skiaControl)
				skiaControl.InvalidateSurface();
		}
	}
}
