using System;
using PieShop.InventoryManagement;
using PieShop.InventoryManagement.Utilities;

namespace PieShop
{
    public class Driver
    {
        public static void Main(string[] args)
        {
            ProductRepo.ReadFile();
            GeneralUtilities.ShowMenu();
            ProductRepo.WriteFile();
        }

    }
}
