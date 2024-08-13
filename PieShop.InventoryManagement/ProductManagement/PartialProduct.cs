using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieShop.InventoryManagement.ProductManagement
{
    public partial class Product
    {
        private void UpdateLowStock()
        {
            if (AmountInStock <= StockThreshold)
            {
                IsBelowStockThreshold = true;
            }
            else
            {
                IsBelowStockThreshold = false;
            }
            LongDescription();
        }

        private void Log(string message)
        {
            Console.WriteLine(message);
        }
        private void DecreaseStock(int items, string reason)
        {
            if (AmountInStock >= items)
            {
                AmountInStock -= items;
            }
            else
            {
                AmountInStock = 0;
            }
            UpdateLowStock();
            Log(reason);
        }
    }
}
