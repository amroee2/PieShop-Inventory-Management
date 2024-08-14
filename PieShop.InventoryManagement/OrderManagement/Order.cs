using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieShop.InventoryManagement.OrderManagement
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderFulfilmentDate { get; private set; }
        public List<OrderItem> OrderItems { get; }
        public bool Fullfilled { get; set; } = false;

        public Order()
        {
            OrderItems = new List<OrderItem>();
            Id = new Random().Next(999999);
            int numberOfSeconds = new Random().Next(100);
            OrderFulfilmentDate = DateTime.Now.AddSeconds(numberOfSeconds);

        }
        public void ShowOrderDetails()
        {
            if (OrderItems.Count > 0)
            {
                foreach (var item in OrderItems)
                {
                    Console.WriteLine($"{item.Id} - {item.ProductId}. {item.ProductName} - {item.AmountOrdered}");
                }
            }
        }

    }
}
