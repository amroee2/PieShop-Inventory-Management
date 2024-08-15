using PieShop.InventoryManagement.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieShop.InventoryManagement.ProductManagement
{
    public class RegularProduct : Product
    {
        public RegularProduct(int id, string name, string? description, UnitType unitType, Price price, int maxItemsInStock) : base(id, name, description, unitType, price, maxItemsInStock)
        {
        }

        public override object Clone()
        {
            return new RegularProduct (0, this.Name, this.Description, this.UnitType, this.Price, this.MaxItemsInStock);
        }

    }
}
