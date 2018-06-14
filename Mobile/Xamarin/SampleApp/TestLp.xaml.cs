using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace testApp
{
	
	public partial class TestLp : ContentPage
	{
		public TestLp ()
		{
			InitializeComponent ();
           Browser.Source = "http://www.google.com/";

            //var browser = new WebView();
            //var htmlSource = new HtmlWebViewSource();
            //htmlSource.Html = @"<html><body>
            //                    <h1>Xamarin.Forms</h1>
            //                  <p>Welcome to WebView.</p>
            //                  </body></html>";
            //Browser.Source = htmlSource;
            //var browser = new WebView();

            //browser.Source = "http://xamarin.com";

            //Content = browser;

        }
	}
}
