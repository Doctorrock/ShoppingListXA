using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace ShoppingListXA
{
    public partial class App : Application
    {
        public static INavigation Navigation = null;
        public App()
        {
            NavigationPage page = new NavigationPage(new MainPage());
            App.Navigation = page.Navigation;
            MainPage = page;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
