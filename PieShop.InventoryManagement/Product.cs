using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieShop.InventoryManagement
{
    public class Product
    {
        private int maxItemsInStock = 0;

        public int Id
        {
            get { return Id; }
            set
            {
                Id = value;
            }
        }
        public int Name
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
        public int AmountInStock { get; private set; }
        public bool IsBelowStockThreshold { get; private set; }

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
            AmountInStock += amount;
        }
        private void UpdateLowStock()
        {
            if (AmountInStock <= 10)
            {
                this.IsBelowStockThreshold = true;
            }
            LongDescription();
        }

        private void Log(string message)
        {
            Console.WriteLine(message);
        }
        private void DecreaseStock(int items, string reason)
        {
            if(AmountInStock >= items)
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
        public void ShortDecription()
        {
            Log($"Product {Name} with ID {this.Id}");
        }
        public void LongDescription()
        {
            Log($"Product: {this.Name}\nID: {this.Id}\nDescription: {this.Description}\nAmount in stock: {AmountInStock}\n" +
                $"Maximum items this product can have: {maxItemsInStock}\n");
            if (IsBelowStockThreshold)
            {
                Log("STOCK IS LOW!!");
            }
        }
    }
}
