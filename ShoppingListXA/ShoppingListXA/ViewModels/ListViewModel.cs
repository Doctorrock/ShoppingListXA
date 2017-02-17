using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace ShoppingListXA.ViewModels
{
    class ListViewModel : BaseViewModel
    {
        ObservableCollection<ProductViewModel> products;

        public ListViewModel()
        {
            products = new ObservableCollection<ProductViewModel>();
            products.Add(new ProductViewModel());
            AddProduct = new Command(() =>
            {
                Products.Add(new ProductViewModel());
            });

        }
        public ObservableCollection<ProductViewModel> Products
        {
            get
            {
                return products;
            }
        }
        public ICommand AddProduct { protected set; get; }
    }
}
