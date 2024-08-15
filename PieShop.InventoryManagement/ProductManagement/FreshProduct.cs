using PieShop.InventoryManagement.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieShop.InventoryManagement.ProductManagement
{
    public class FreshProduct : Product
    {
        public DateTime ExpiryDateTime { get; set; }
        public string? StorageInstructions { get; set; } = "Store quickly in a fridge";
        public FreshProduct(int id, string name, string? description, UnitType unitType, Price price, int maxItemsInStock) : base(id, name, description, unitType, price, maxItemsInStock)
        {
        }
        public override void LongDescription()
        {
            Console.WriteLine($"\nID = {Id}, Name = {Name}, Unit = {UnitType}, Price = {Price}, Max Stock = {MaxItemsInStock}, Amount in ineventory = {AmountInStock}, Storage Instructions = {StorageInstructions}, Expiry Date = {ExpiryDateTime.ToString()}");
            if (IsBelowStockThreshold)
            {
                Log("STOCK IS LOW!!");
            }
        }
    }
}
