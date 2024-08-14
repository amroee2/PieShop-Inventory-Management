using PieShop.InventoryManagement.OrderManagement;
using PieShop.InventoryManagement.ProductManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieShop.InventoryManagement.Utilities
{
    public class OrderUtilities
    {
        private static List<Order> Orders = new List<Order>();
        public static void OrderManagementOperation()
        {
            while (true)
            {
                Console.WriteLine("Order Management\n");

                Console.WriteLine("1: Open order overview\n2: Add new order\n0: Back to main menu");
                int op = Convert.ToInt32(Console.ReadLine());

                switch (op)
                {
                    case 0:
                        return;
                    case 1:
                        ShowPendingOrders();
                        break;
                    case 2:
                        AddNewOrder();
                        break;

                }
            }
        }
        public static void ShowPendingOrders()
        {
            List<Order> ordersCopy = new List<Order>(Orders);

            foreach (Order order in ordersCopy)
            {
                if (!order.Fullfilled && order.OrderFulfilmentDate < DateTime.Now)
                {
                    order.ShowOrderDetails();
                    UpdateStock(order);
                }
            }

            Orders.RemoveAll(o => o.Fullfilled);
        }

        public static void AddNewOrder()
        {
            Order order = new Order();
            while (true)
            {
                Console.WriteLine("1- Add new Item\n2- Finish Order");
                int op = Convert.ToInt32(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        Console.WriteLine("Order Item Id:");
                        int id = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Product Id:");
                        int productId = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Name:");
                        string name = Console.ReadLine();

                        Console.WriteLine("Amount: ");
                        int amount = Convert.ToInt32(Console.ReadLine());
                        order.OrderItems.Add(new OrderItem { Id = id, ProductName = name, ProductId = productId, AmountOrdered = amount });
                        break;
                    case 2:
                        order.ShowOrderDetails();
                        Orders.Add(order);
                        return;
                }
            }
        }
        public static void UpdateStock(Order order)
        {
            foreach (OrderItem orderItem in order.OrderItems)
            {
                Product? product = ProductUtilities.ProductID(orderItem.ProductId);
                if (product == null)
                {
                    Console.WriteLine($"Product {orderItem.ProductId}. {orderItem.ProductName} doesnt exist in the system");
                    continue;
                }
                product.AddIntoStock(orderItem.AmountOrdered);
            }
            order.Fullfilled = true;

            Console.WriteLine("Fulfilled orders");
        }
    }
}
