using PieShop.InventoryManagement.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieShop.InventoryManagement.ProductManagement
{
    public class BoxedProduct : Product
    {
        private int amountPerBox;

        public int AmountPerBox
        {
            get { return amountPerBox; }
            set {
                amountPerBox = value; 
            }
        }


        public BoxedProduct(int id, string name, string? description, UnitType unitType, Price price, int maxItemsInStock, int amountPerBox) : base(id, name, description, UnitType.PerBox, price, maxItemsInStock)
        {
            AmountPerBox = amountPerBox;
        }

        public void UseBoxedProduct(int items)
        {
            int smallestMultiple = 0;
            int batchsize;
            while (true)
            {
                smallestMultiple++;
                if (smallestMultiple * AmountPerBox > items)
                {
                    batchsize = AmountPerBox * smallestMultiple;
                    break;
                }
            }
            UseItem(batchsize);
        }
    }
}
