namespace ShoppingListXA.Interfaces
{
    public interface IProductModel
    {
        int ID { get; set; }
        string Name { get; set; }
        bool IsChecked { get; set; }
    }
}
