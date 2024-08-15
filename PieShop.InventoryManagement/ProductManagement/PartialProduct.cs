using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieShop.InventoryManagement.ProductManagement
{
    public partial class Product
    {
        protected void UpdateLowStock()
        {
            if (AmountInStock <= StockThreshold)
            {
                IsBelowStockThreshold = true;
            }
            else
            {
                IsBelowStockThreshold = false;
            }
        }

        protected void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
