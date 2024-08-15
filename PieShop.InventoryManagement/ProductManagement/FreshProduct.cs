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
        public string? StorageInstructions { get; set; }
        public FreshProduct(int id, string name, string? description, UnitType unitType, Price price, int maxItemsInStock) : base(id, name, description, unitType, price, maxItemsInStock)
        {
        }
    }
}
