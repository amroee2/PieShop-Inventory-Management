using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieShop.InventoryManagement.General
{
    public class Price
    {
        public double ItemPrice { get; set; }
        public Currency Currency { get; set; }

        public Price(int ItemPrice, Currency currency) {
            this.ItemPrice = ItemPrice;
            this.Currency = currency;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
