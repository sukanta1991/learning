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
	public partial class Alerts : ContentPage
	{
		public Alerts ()
		{
			InitializeComponent ();
		}

        private async void changeColor_Clicked(object sender, EventArgs e)
        {
            string col = await DisplayActionSheet(
                        "Choose Background Color",
                        "cancel", "destruction",
                        "Navy",
                        "Olive",
                        "Maroon"
                );
            if (col == "Navy")
            {
                BackgroundColor = Color.Navy;
            }
            else
                BackgroundColor = Color.Green;
        }
    }
}
