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
	public partial class HomePage : ContentPage
	{
		public HomePage ()
		{
			InitializeComponent ();
		}

        private void btnName_Clicked(object sender, EventArgs e)
        {
            string name = txtName.Text;
            lblName.Text = "Hello " + name + " !!";
        }

        private async void btnSecond_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SecondPage(txtName.Text));
        }
    }
}
