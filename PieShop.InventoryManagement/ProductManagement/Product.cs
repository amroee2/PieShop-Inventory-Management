using PieShop.InventoryManagement.General;

namespace PieShop.InventoryManagement.ProductManagement
{
    public partial class Product
    {
        private int _id;
        private string? _name;
        private string? _description;

        private int MaxItemsInStock = 0;
        private static int StockThreshold = 5;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string? Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string? Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public UnitType UnitType { get; set; }
        public Price Price { get; set; }
        public int AmountInStock { get; private set; }
        public bool IsBelowStockThreshold { get; private set; }

        public Product()
        {
        }

        public Product(int id, string name, string? description, UnitType unitType, Price price, int maxItemsInStock)
        {
            MaxItemsInStock = maxItemsInStock;
            Id = id;
            Name = name;
            Description = description;
            UnitType = unitType;
            Price = price;

            UpdateLowStock();
        }

        public Product(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void UseItem(int amount)
        {
            if (amount > AmountInStock)
            {
                Log($"Not enough amount in stock\n");
                ShortDescription();
            }
            else
            {
                Log($"Product used successfully\n");
                ShortDescription();
                AmountInStock -= amount;
                UpdateLowStock();
            }
        }

        public void AddIntoStock(int amount)
        {
            int newStock = AmountInStock + amount;
            if (newStock > MaxItemsInStock)
            {
                AmountInStock = MaxItemsInStock;
                Log($"Stock overflow, only {newStock - AmountInStock} were taken");
            }
            else
            {
                AmountInStock += amount;
            }
            UpdateLowStock();
        }

        public void AddIntoStock()
        {
            AmountInStock++;
        }

        public void ShortDescription()
        {
            Log($"{Id}. {Name}");
        }
        public void LongDescription()
        {
            Console.WriteLine($"\nID = {Id}, Name = {Name}, Unit = {UnitType}, Price = {Price} {Price.Currency}, Max Stock = {MaxItemsInStock}, Amount in ineventory = {AmountInStock}");
            if (IsBelowStockThreshold)
            {
                Log("STOCK IS LOW!!");
            }
        }
        public void UpdateThreshold(int amount)
        {
            if (amount > 0)
            {
                StockThreshold = amount;
            }
        }
    }
}
