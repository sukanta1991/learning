using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace testApp
{
	public partial class App : Application
	{

		public App ()
		{
			InitializeComponent();

            //MainPage = new testApp.MainPage();
            // MainPage = new NavigationPage( new HomePage());
            //MainPage = new TabbedPage
            //{
            //    Children =
            //    {
            //        new HomePage(),
            //        new SecondPage("Hello !")
            //    }
            //};
            //MainPage = new CarouselPage
            //{
            //    Children =
            //    {
            //        new HomePage(),
            //        new SecondPage("Hello !")
            //    }
            //};
            //MainPage = new Menupage();
            //MainPage = new SecondPage();
            MainPage = new NavigationPage( new SamplePage());
            //MainPage = new TestLp();
            //MainPage = new MainPage();
            //MainPage = new SamplePage();
            //MainPage = new Alerts();
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
