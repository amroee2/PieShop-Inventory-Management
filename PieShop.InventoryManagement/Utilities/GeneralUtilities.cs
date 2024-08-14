using PieShop.InventoryManagement.General;
using PieShop.InventoryManagement.OrderManagement;
using PieShop.InventoryManagement.ProductManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieShop.InventoryManagement.Utilities
{
    public class GeneralUtilities
    {
        public static void ShowMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome!\n1: Inventory Management\n2: Order Management\n3: Settings\n" +
    "4: Save all data\n0: Close Application");
                int operation = Convert.ToInt32(Console.ReadLine());
                switch (operation)
                {
                    case 0:
                        Console.WriteLine("Program closed");
                        return;
                    case 1:
                        ProductUtilities.IneventoryManagementOperation();
                        break;
                    case 2:
                        OrderUtilities.OrderManagementOperation();
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
        public static void Settings()
        {

        }
        public static void SaveAllData()
        {

        }
    }
}
