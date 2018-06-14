using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using testApp.ViewModels;

namespace testApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SamplePage : ContentPage
	{
        private readonly List<string> _names = new List<string> {
            "suku","sukanta","test","gaurav","Devi","prajna","ramya","ankit","majar"
        };
		public SamplePage ()
		{
			InitializeComponent ();
            BindingContext = new SampleViewModel();
            MainList.ItemsSource = _names;
           
		}

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await progressShow.ProgressTo(0.9, 5000, Easing.Linear);
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SamplePage2());
        }

        private async void ButtonSave_Clicked(object sender, EventArgs e)
        {
           
                await DisplayAlert("test",
                                    "apps",
                                    "save",
                                    "cancel");
           
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            lblTool.Text = "Button clicked has text " + ((MenuItem)sender).Text;
        }

        private void MainSearchBar_SearchButtonPressed(object sender, EventArgs e)
        {
            string keyword = MainSearchBar.Text;
            
            if (keyword.Equals("") || keyword == null)
            {
                MainList.ItemsSource = _names;
               // lblTool.Text = "SUCCESS";
            }
            else
            {
               // lblTool.Text = "FAIL";
                IEnumerable<string> searchResult = _names.Where(name => name.ToLower().Contains(keyword.ToLower()));
                IEnumerable<string> searchResult2 = from name
                                                    in _names
                                                    where name.ToLower().Contains(keyword.ToLower())
                                                    select name;
                MainList.ItemsSource = searchResult;
            }
        }

        private void switchShow_Toggled(object sender, ToggledEventArgs e)
        {
            bool tog = e.Value;
            if (tog)
                switchStaus.Text = "TRUE";
            else
                switchStaus.Text = "False";
        }

        private void datePick_DateSelected(object sender, DateChangedEventArgs e)
        {
            DateTexta.Text = e.NewDate.ToString();
        }

        private void MainSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            SliderText.Text = MainSlider.Value.ToString();
        }
    }
}
