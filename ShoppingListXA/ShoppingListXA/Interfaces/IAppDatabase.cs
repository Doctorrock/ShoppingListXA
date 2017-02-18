using System.Collections.Generic;

namespace ShoppingListXA.Interfaces
{
    public interface IAppDatabase
    {
        List<IProductModel> GetItems();

        List<IProductModel> GetItemsNotDone();

        IProductModel GetItem(int id);

        int SaveItem(IProductModel item);

        int DeleteItem(IProductModel item);
    }
}
