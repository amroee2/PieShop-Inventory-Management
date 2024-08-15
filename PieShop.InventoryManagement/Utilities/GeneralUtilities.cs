using PieShop.InventoryManagement.ProductManagement;

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
            Console.WriteLine("1- Update Low Stock Threshold\n2- Go Back");
            int op = Convert.ToInt32(Console.ReadLine());
            switch (op)
            {
                case 1:
                    Console.WriteLine($"Current threshold = {Product.StockThreshold}");
                    Console.Write("Enter amount: ");
                    int amount = Convert.ToInt32(Console.ReadLine());
                    Product.UpdateThreshold(amount);
                    break;
                case 2:
                    return;
            }
        }
        public static void SaveAllData()
        {
            ProductRepo.WriteFile();
        }
    }
}
