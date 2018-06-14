using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace testApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SamplePage2 : ContentPage
	{
		public SamplePage2 ()
		{
			InitializeComponent ();
            BindingContext = new SampleViewModel();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SamplePage());
        }

        private async void ThirdPage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Sample3());
        }
    }
}
