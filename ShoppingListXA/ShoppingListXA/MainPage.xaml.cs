using ShoppingListXA.ViewModels;
using Xamarin.Forms;

namespace ShoppingListXA
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            var listViewModel = new ListViewModel();
            this.BindingContext = listViewModel;
            this.listView.ItemsSource = listViewModel.Products;
        }

    }
}
