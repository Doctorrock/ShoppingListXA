using Xamarin.Forms;
using ShoppingListXA.Interfaces;

namespace ShoppingListXA
{
    public partial class App : Application
    {
        public static INavigation Navigation = null;
        static IAppDatabase database;
        public static IAppDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = DependencyService.Get<IAppDatabase>();
                }
                return database;
            }
        }

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
