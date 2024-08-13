using PieShop.InventoryManagement.OrderManagement;
using PieShop.InventoryManagement.ProductManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieShop.InventoryManagement
{
    public class Utilities
    {
        private static List<Product> Products = new List<Product>();
        private static List<Order> Orders = new List<Order>();
        public static void ShowMenu()
        {
            while (true)
            {
                Console.WriteLine("Welcome!\n1: Inventory Management\n2: Order Management\n3: Settings\n" +
    "4: Save all data\n0: Close Application");
                int operation = Convert.ToInt32(Console.ReadLine());
                switch (operation)
                {
                    case 0:
                        Console.WriteLine("Program closed");
                        return;
                    case 1:
                        IneventoryManagementOperation();
                        break;
                    case 2:
                        OrderManagementOperation();
                        break;
                    case 3:
                        Settings();
                        break;
                    case 4:
                        SaveAllData();
                        break;
                }
            }
        }
        public static void IneventoryManagementOperation()
        {
            Console.Clear();
            Console.WriteLine("Inventory Management\n");
            foreach (Product product in Products)
            {
                product.ShortDecription();
            }
            Console.WriteLine("1: View details of a product\n2: Add a new product\n" +
                "3: Clone product\n4: View Product\n0: Back to main menu");
            int operation = Convert.ToInt32(Console.ReadLine());
            switch (operation) { 
                case 0:
                    return;
                case 1:
                    
                    break;

            }
        }
        public static void OrderManagementOperation()
        {
        }
        public static void Settings()
        {

        }
        public static void SaveAllData()
        {

        }
        public static void AddNewProduct()
        {
        }
    }

}
