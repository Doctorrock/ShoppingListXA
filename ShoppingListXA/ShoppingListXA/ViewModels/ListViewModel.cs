using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace ShoppingListXA.ViewModels
{
    public class ListViewModel : BaseViewModel
    {
        ObservableCollection<ProductViewModel> products;

        public ListViewModel()
        {
            products = new ObservableCollection<ProductViewModel>();

            AddProduct = new Command(() =>
            {
                Products.Add(new ProductViewModel("inny"));
            });

            
            this.AddPageCommand = new Command(() =>
            {
                 App.Navigation.PushAsync(new AddPage(this));
            });

            SaveProduct = new Command(() =>
            {
                if(ProductToAdd != null)
                {
                    products.Add(ProductToAdd);
                }

                GetBack.Execute(new object());
            });

            GetBack = new Command(() =>
            {
                App.Navigation.PopAsync();
            });

        }
        public ObservableCollection<ProductViewModel> Products
        {
            get
            {
                return products;
            }
        }

        public ProductViewModel ProductToAdd { get; set; }
        public ICommand AddProduct { protected set; get; }
        public ICommand AddPageCommand { protected set; get; }
        public ICommand SaveProduct { protected set; get; }
        public ICommand GetBack { protected set; get; }
    }
}
