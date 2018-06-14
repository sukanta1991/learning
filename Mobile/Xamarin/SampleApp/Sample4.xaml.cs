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
	public partial class Sample4 : ContentPage
	{
        private readonly List<string> _names = new List<string> {
            "suku","test","sukanta","gaurav","Devi","prajna","ramya","ankit","majar"
        };
        public Sample4 ()
		{
			InitializeComponent ();
            lstNames.ItemsSource = _names;

        }
	}
}
