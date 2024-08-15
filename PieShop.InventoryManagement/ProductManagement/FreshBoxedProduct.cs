using PieShop.InventoryManagement.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieShop.InventoryManagement.ProductManagement
{
    public class FreshBoxedProduct : BoxedProduct
    {
        public FreshBoxedProduct(int id, string name, string? description, UnitType unitType, Price price, int maxItemsInStock, int amountPerBox) : base(id, name, description, unitType, price, maxItemsInStock, amountPerBox)
        {
        }
    }
}
