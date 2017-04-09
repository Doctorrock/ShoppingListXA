using ShoppingListXA.Models;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace ShoppingListXA.ViewModels
{
    public class ProductViewModel : BaseViewModel
    {
        private string text;
        private bool isChecked;

        public int Id { get; set; }

        public ProductViewModel()
        {
            this.CheckProduct = new Command(() =>
            {
                this.IsChecked = !this.IsChecked;
            });
        }

        public ProductViewModel(string name):this()           
        {
            isChecked = true;
            this.text = name;

        }
        public ProductViewModel(int id):this()
        {
            this.Id = id;
        }

        public string Text
        {
            set
            {
                if (text == value) return;
                text = value;
                OnPropertyChanged();
            }

            get
            {
                return text;
            }
        }

        public bool IsChecked
        {
            set
            {
                if (isChecked == value) return;
                isChecked = value;
                App.Database.SaveItem(new ProductModel
                {
                    ID = this.Id,
                    IsChecked = isChecked,
                    Name = this.Text
                });
                OnPropertyChanged();
            }

            get
            {
                return isChecked;
            }
        }

        public ICommand CheckProduct { protected set; get; }
    }
}
