using System;
using System.Collections.Generic;
using System.Linq;

namespace StoreApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("1. Add new store(s)");
            Console.WriteLine("2. Add products to a store");
            var input = Console.ReadLine();
            if (input == "1")
            {
                Console.WriteLine("How many?");
                var storeIdx = Console.ReadLine();
                var storeOut = Convert.ToInt32(storeIdx);

                var stores = new List<Store>();

                using (var context = new StoreContext())
                {
                    for (int i = 0; i < storeOut; i++)
                    {
                        var store = new Store();

                        Console.WriteLine("What is the store name?");
                        var name = Console.ReadLine();
                        store.Name = name;

                        Console.WriteLine("What is the store adress?");
                        var adress = Console.ReadLine();
                        store.Adress = adress;

                        Console.WriteLine("What is the store business Id?");
                        var businessId = Console.ReadLine();
                        store.BusinessId = businessId;

                        Console.WriteLine("What is the product name?");
                        var productName = Console.ReadLine();
                        store.ProductName = productName;

                        Console.WriteLine("What is the product price?");
                        var productPrice = Console.ReadLine();
                        double productPriceOut = Convert.ToDouble(productPrice);
                        store.ProductPrice = productPriceOut;

                        context.Add(store);
                        context.SaveChanges();

                        Console.WriteLine("saved!");
                        Console.WriteLine();
                    }
                }
            }
            else if (input == "2")
            {
                var stores = GetAllStores();

                Console.WriteLine("Enter the id of the store you want to add a product");
                var id = Console.ReadLine();
                var idout = Convert.ToInt32(id);
                var selectedStore = stores.Where(x => x.Id == idout);

                //zavrsiti
            }
        }

        public static List<Store> GetAllStores()
        {
            var stores = new List<Store>();

            var context = new StoreContext();

            stores = context.Stores.ToList<Store>();

            return stores;
        }
    }
}