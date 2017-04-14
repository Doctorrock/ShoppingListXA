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
        // IAppDatabase database;

        public ListViewModel()
        {
            Products = new ObservableCollection<ProductViewModel>();

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
                    
                    var productModel = new ProductModel
                    {
                        ID = ProductToAdd.Id,
                        Name = ProductToAdd.Text,
                        IsChecked = ProductToAdd.IsChecked
                    };
                    
                    ProductToAdd.Id = App.Database.SaveItem(productModel);
                    Products.Add(ProductToAdd);
                }

                GetBack.Execute(new object());
            });

            GetBack = new Command(() =>
            {
                App.Navigation.PopAsync();
            });

        }
        public ObservableCollection<ProductViewModel> Products { get; }

        private void DownloadProducts()
        {
            
            var dbProducts =  App.Database.GetItems();
            foreach(var dbProduct in dbProducts)
            {
                Products.Add(new ProductViewModel(dbProduct.ID)
                {
                    
                    IsChecked = dbProduct.IsChecked,
                    Text = dbProduct.Name,
                });
            }
        }

        public void DeleteProduct(ProductViewModel product)
        {
            Products.Remove(product);

            App.Database.DeleteItem(new ProductModel{ID = product.Id,IsChecked = product.IsChecked,Name = product.Text});
        }

        public ProductViewModel ProductToAdd { get; set; }
        public ICommand AddProduct { protected set; get; }
        public ICommand AddPageCommand { protected set; get; }
        public ICommand SaveProduct { protected set; get; }
        public ICommand GetBack { protected set; get; }
    }
}
