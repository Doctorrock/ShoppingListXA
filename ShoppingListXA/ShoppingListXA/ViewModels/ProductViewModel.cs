using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace ShoppingListXA.ViewModels
{
    class ProductViewModel : BaseViewModel
    {
        private DateTime dateAdded;
        private string text;
        private bool isChecked; 

        public ProductViewModel()
        {
            this.text = "testowy produkt";
            this.CheckProduct = new Command(() =>
            {
                this.IsChecked = !this.IsChecked;
            });
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
