using ShoppingListXA.Models;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace ShoppingListXA.ViewModels
{
    public class ProductViewModel : BaseViewModel
    {
        private DateTime dateAdded;
        private string text;
        private bool isChecked;

        public int ID { get; set; }

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
            this.ID = id;
        }

        public string Text
        {
            set
            {
                if(text != value)
                {
                    text = value;
                    OnPropertyChanged();
                }
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
                if (isChecked != value)
                {
                    isChecked = value;
                    App.Database.SaveItem(new ProductModel
                    {
                        ID = this.ID,
                        IsChecked = isChecked,
                        Name = this.Text
                    });
                    OnPropertyChanged();
                }
            }

            get
            {
                return isChecked;
            }
        }

        public ICommand CheckProduct { protected set; get; }
    }
}
