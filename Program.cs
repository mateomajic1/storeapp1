using System;
using System.Collections.Generic;
using System.Linq;

namespace MMTech
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("1. Add new stores to the database");
            Console.WriteLine("2. Add a product to a specific store");

            var input = Console.ReadLine();

            if (Convert.ToInt32(input) == 1)
            {
                Console.WriteLine("how many stores do you want to add?");
                input = Console.ReadLine();

                var stores = new List<Store>();

                using (var ctx = new StoreContext())
                {
                    for (int i = 0; i < Convert.ToInt32(input); i++)
                    {
                        var store = new Store();

                        Console.Write("Store Name: ");
                        store.Name = Console.ReadLine();

                        Console.Write("Store Adress: ");
                        store.Adress = Console.ReadLine();

                        Console.Write("Store BusinessId: ");
                        store.BusinessId = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Store product Name: ");
                        store.ProductName = Console.ReadLine();

                        Console.Write("Store product price: ");
                        store.ProductPrice = Convert.ToDouble(Console.ReadLine());

                        Console.WriteLine("Saving...");
                        ctx.Add(store);
                        ctx.SaveChanges();

                        Console.WriteLine($"{store.Name} has been saved to the database!");
                    }
                }
            }
            else
            {
                var stores = GetAllStores();

                Console.WriteLine("Enter the id of the store you want to add a product");
                var id = Console.ReadLine();
                var idout = Convert.ToInt32(id);
                var selectedStores = stores.Where(x => x.Id == idout).ToList();

                var store = selectedStores[0];

                Console.WriteLine("What is the product name?");
                store.ProductName = Console.ReadLine();
                Console.WriteLine("What is the product price?");
                var priceIn = Console.ReadLine();
                var priceOut = Convert.ToDouble(priceIn);

                store.ProductPrice = priceOut;

                Console.WriteLine(1);
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