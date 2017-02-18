using ShoppingListXA.Interfaces;

namespace ShoppingListXA.Droid.Models
{
   public class ProductModel : IProductModel
    {
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public bool IsChecked { get; set; }

        //public ProductModel(IProductModel iprod) 
        //{
        //    if(iprod.ID != 0)
        //    {
        //        ID = iprod.ID;
        //    }
        //    Name = iprod.Name;
        //    IsChecked = iprod.IsChecked;
        //}
    }

    
}