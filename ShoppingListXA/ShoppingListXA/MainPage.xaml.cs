using System;
using ShoppingListXA.ViewModels;
using Xamarin.Forms;

namespace ShoppingListXA
{
    public partial class MainPage : ContentPage
    {
        private ListViewModel listViewModel;

        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            
            listViewModel = new ListViewModel();
            this.BindingContext = listViewModel;
            this.listView.ItemsSource = listViewModel.Products;
        }

        public void OnDelete(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            var product = (ProductViewModel)mi.CommandParameter;
            this.listViewModel.DeleteProduct(product);

        }

    }
}
