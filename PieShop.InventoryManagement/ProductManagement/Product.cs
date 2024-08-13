using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PieShop.InventoryManagement.General;

namespace PieShop.InventoryManagement.ProductManagement
{
    public partial class Product
    {
        private int MaxItemsInStock = 0;
        private static int StockThreshold = 5;
        public int Id
        {
            get { return Id; }
            set
            {
                Id = value;
            }
        }
        public string? Name
        {
            get { return Name; }
            set
            {
                Name = value;
            }
        }
        public string? Description
        {
            get { return Description; }
            set
            {
                Description = value;
            }
        }
        public UnitType UnitType { get; set; }
        public Price Price { get; set; }
        public int AmountInStock { get; private set; }
        public bool IsBelowStockThreshold { get; private set; }

        public Product()
        {

        }
        public Product(int maxItemsInStock, int id, string name, string? description, UnitType unitType, Price price)
        {
            MaxItemsInStock = maxItemsInStock;
            Id = id;
            Name = name;
            Description = description;
            UnitType = unitType;
            Price = price;

            UpdateLowStock();
        }
        public Product(int id, string Name)
        {
            Id = id;
            this.Name = Name;
        }

        public void UseItem(int amount)
        {
            if (amount > AmountInStock)
            {
                Log($"Not enough amount in stock\n");
                ShortDecription();
            }
            else
            {
                Log($"Product used successfull\n");
                ShortDecription();
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
        }
        public void AddIntoStock()
        {
            AmountInStock++;
        }
        public void ShortDecription()
        {
            Log($"{Id}. {Name}");
        }
        public void LongDescription()
        {
            Log($"Product: {Name}\nID: {Id}\nDescription: {Description}\nAmount in stock: {AmountInStock}\n" +
                $"Maximum items this product can have: {MaxItemsInStock}\nPrice: {Price}");
            if (IsBelowStockThreshold)
            {
                Log("STOCK IS LOW!!");
            }
        }
        public void UpdateThreshold(int amount)
        {
            if(amount > 0)
            {
                StockThreshold = amount;
            }
        }
    }
}
