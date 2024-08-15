namespace PieShop.InventoryManagement.ProductManagement
{
    public abstract partial class Product
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
