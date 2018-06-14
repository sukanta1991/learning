using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace testApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Sample3 : ContentPage
	{
		public Sample3 ()
		{
			InitializeComponent ();
		}

        private async void btnAnimate_Clicked(object sender, EventArgs e)
        {
            await MainGrid.TranslateTo(200, 300, 1000, Easing.Linear);
            await MainGrid.RotateTo(90, 800, Easing.SinInOut);
            await MainGrid.FadeTo(0.5, 600, Easing.CubicOut);
            await MainGrid.LayoutTo(new Rectangle(-200, -300, 300, 100));
            await MainGrid.ScaleTo(0.6, 500, Easing.CubicIn);
        }

        private void tapGrid_Tapped(object sender, EventArgs e)
        {
            BackgroundColor = Color.Olive;
        }

        private async void btnNxtPage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Sample4());
        }
    }
}
