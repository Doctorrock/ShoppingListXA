using ShoppingListXA.ViewModels;

using Xamarin.Forms;

namespace ShoppingListXA
{
    public partial class AddPage : ContentPage
    {

        public AddPage(ListViewModel list)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            list.ProductToAdd = new ProductViewModel();
            BindingContext = list;
        }
    }
}
