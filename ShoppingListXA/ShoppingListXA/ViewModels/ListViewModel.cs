using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using ShoppingListXA;
using System;
using ShoppingListXA.Models;

namespace ShoppingListXA.ViewModels
{
    public class ListViewModel : BaseViewModel
    {
        ObservableCollection<ProductViewModel> products;
       // IAppDatabase database;

        public ListViewModel()
        {
            products = new ObservableCollection<ProductViewModel>();

            DownloadProducts();
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
                    App.Database.SaveItem(new ProductModel
                    {
                        ID = ProductToAdd.ID,
                        Name = ProductToAdd.Text,
                        IsChecked = ProductToAdd.IsChecked
                    });
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

        private void DownloadProducts()
        {
            
            var dbProducts =  App.Database.GetItems();
            foreach(var dbProduct in dbProducts)
            {
                products.Add(new ProductViewModel(dbProduct.ID)
                {
                    
                    IsChecked = dbProduct.IsChecked,
                    Text = dbProduct.Name,
                });
            }
        }
        public ProductViewModel ProductToAdd { get; set; }
        public ICommand AddProduct { protected set; get; }
        public ICommand AddPageCommand { protected set; get; }
        public ICommand SaveProduct { protected set; get; }
        public ICommand GetBack { protected set; get; }
    }
}
