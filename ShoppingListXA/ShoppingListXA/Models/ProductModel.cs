using ShoppingListXA.Interfaces;

namespace ShoppingListXA.Models
{
    public class ProductModel : IProductModel
    {
        public int ID { get; set; }
        public bool IsChecked { get; set; }
        public string Name { get; set; }
    }
}
