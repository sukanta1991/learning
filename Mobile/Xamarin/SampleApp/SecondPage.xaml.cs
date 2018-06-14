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
	public partial class SecondPage : ContentPage
	{
		public SecondPage (string para)
		{
			InitializeComponent ();
            lblName.Text = para + " came from HomePage.";
            //listNames.ItemsSource = new List<string> {
            //    "Sukanta","Saha","Suku",""
            //};
            listNames.ItemsSource = new List<Person>
            {
                new Person{Name ="sukanta" , Age=25},
                new Person{Name="Saha", Age=20},
                new Person{Name="Suku", Age=35}
            };
		}
        public SecondPage()
        {
            InitializeComponent();
            lblName.Text = "Directly landed to the page.";
            listNames.ItemsSource = new List<Person>
            {
                new Person{Name ="sukanta" , Age=25},
                new Person{Name="Saha", Age=20},
                new Person{Name="Suku", Age=35}
            };
        }

        private async void btnPageChange_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HomePage());
        }

    }
}
