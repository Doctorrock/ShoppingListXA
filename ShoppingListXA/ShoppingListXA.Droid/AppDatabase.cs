using System.Collections.Generic;
using SQLite;
using ShoppingListXA.Droid.Models;
using ShoppingListXA.Interfaces;
using System;
using ShoppingListXA.Droid;
using System.IO;
using System.Linq;
using Android.Database.Sqlite;

[assembly: Xamarin.Forms.Dependency(typeof(AppDatabase))]
namespace ShoppingListXA.Droid
{
   public class AppDatabase : IAppDatabase
    {
         SQLiteConnection database;

        private List<ProductModel> products;

        public AppDatabase()
        {
            const string dbPath = "ShoppingListSQLite.db3";
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            database = new SQLiteConnection(Path.Combine(path, dbPath));
            database.CreateTable<ProductModel>();
            products = new List<ProductModel>();
        }

        public void DeleteItem(IProductModel item)
        {
            var toRemove = products.FirstOrDefault(x => x.ID == item.ID);
            if (toRemove == null) return;

            products.Remove(toRemove);
            database.Delete(toRemove);
        }

        public IProductModel GetItem(int id)
        {
            throw new NotImplementedException();
        }

        public List<IProductModel> GetItems()
        {
            products = database.Table<ProductModel>().ToList();
            return products.Cast<IProductModel>().ToList();
        }

        public List<IProductModel> GetItemsNotDone()
        {
            throw new NotImplementedException();
        }

        public int SaveItem(IProductModel item)
        {
            
            if(item.ID != 0)
            {
                var product = products.FirstOrDefault(x => x.ID == item.ID);
                product.IsChecked = item.IsChecked;

                var result = database.Update(product);
                if (result != 1)
                {
                    throw new SQLiteDatabaseLockedException();
                }
                return product.ID;
            }
            else
            {
                var product = new ProductModel { Name = item.Name, IsChecked = item.IsChecked };
                var result = database.Insert(product);
                products.Add(product);
                if (result != 1)
                {
                    throw new SQLiteDatabaseLockedException();
                }

                return product.ID;
            }
        }
    }
}