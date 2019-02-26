using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SkiaSharpPreviewerDemo
{
	// START HACK:
	// A bug results in this attribute being required for local custom controls.
	// This is fixed in a later version of the previewer.
	[System.ComponentModel.DesignTimeVisible(true)]
	partial class MainPage { }
	// END HACK

	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}
	}
}
