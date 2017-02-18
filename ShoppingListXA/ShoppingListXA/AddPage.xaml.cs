using ShoppingListXA.ViewModels;

using Xamarin.Forms;

namespace ShoppingListXA
{
    public partial class AddPage : ContentPage
    {
        public AddPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new ProductViewModel();
        }
    }
}
