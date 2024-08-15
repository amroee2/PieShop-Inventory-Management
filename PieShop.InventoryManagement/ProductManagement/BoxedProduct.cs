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


        public BoxedProduct(int id, string name, string? description, Price price, int maxItemsInStock, int amountPerBox) : base(id, name, description, UnitType.PerBox, price, maxItemsInStock)
        {
            AmountPerBox = amountPerBox;
        }

        public override void UseProduct(int items)
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
            base.UseProduct(batchsize);
        }
        public override void LongDescription()
        {
            Console.WriteLine($"\nID = {Id}, Name = {Name}, Unit = {UnitType}, Price = {Price}, Max Stock = {MaxItemsInStock}, Amount in ineventory = {AmountInStock}, Amount Per Box = {AmountPerBox}");
            if (IsBelowStockThreshold)
            {
                Log("STOCK IS LOW!!");
            }
        }
        public override void AddIntoStock(int amount)
        {
            int newStock = AmountInStock + (amount * AmountPerBox);
            if (newStock > MaxItemsInStock)
            {
                AmountInStock = MaxItemsInStock;
                Log($"Stock overflow, only {newStock - AmountInStock} were taken");
            }
            else
            {
                AmountInStock += amount * AmountPerBox;
            }
            UpdateLowStock();
        }
        public override object Clone()
        {
            return new RegularProduct(0, this.Name, this.Description, this.UnitType, this.Price, this.MaxItemsInStock);
        }
    }
}
