using System.Collections.Generic;
using SQLite;
using ShoppingListXA.Droid.Models;
using ShoppingListXA.Interfaces;
using System;
using ShoppingListXA.Droid;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(AppDatabase))]
namespace ShoppingListXA.Droid
{
   public class AppDatabase : IAppDatabase
    {
         SQLiteConnection database;

        public AppDatabase()
        {
            string dbPath = "ShoppingListSQLite.db3";
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            database = new SQLiteConnection(Path.Combine(path, dbPath));
            database.CreateTable<ProductModel>();
        }

        public int DeleteItem(IProductModel item)
        {
            throw new NotImplementedException();
        }

        public IProductModel GetItem(int id)
        {
            throw new NotImplementedException();
        }

        public List<IProductModel> GetItems()
        {
            var products = database.Table<ProductModel>();
            var list = new List<IProductModel>();
            foreach(var product in products)
            {
                list.Add(product);
            }
            return list;
        }

        public List<IProductModel> GetItemsNotDone()
        {
            throw new NotImplementedException();
        }

        public int SaveItem(IProductModel item)
        {
            
            if(item.ID != 0)
            {
                var product = new ProductModel { ID = item.ID, Name = item.Name, IsChecked = item.IsChecked };
                return database.Update(product);
            }
            else
            {
                var product = new ProductModel { Name = item.Name, IsChecked = item.IsChecked };
                return database.Insert(product);
            }
        }
    }
}