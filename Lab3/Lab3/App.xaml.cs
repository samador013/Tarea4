using Lab3.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Lab3
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();
            //NavigationPage navigation = new NavigationPage(new MainPage());

            //App.Current.MainPage = new MasterDetailPage
            //{
            //    Master = new HomeMenu(),
            //    Detail = navigation
            //};
            
            MainPage = new Lab3.View.Login();
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
