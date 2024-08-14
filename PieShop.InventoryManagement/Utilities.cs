using PieShop.InventoryManagement.General;
using PieShop.InventoryManagement.OrderManagement;
using PieShop.InventoryManagement.ProductManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieShop.InventoryManagement
{
    public class Utilities
    {
        private static List<Product> Products = new List<Product>();
        private static List<Order> Orders = new List<Order>();
        public static void ShowMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome!\n1: Inventory Management\n2: Order Management\n3: Settings\n" +
    "4: Save all data\n0: Close Application");
                int operation = Convert.ToInt32(Console.ReadLine());
                switch (operation)
                {
                    case 0:
                        Console.WriteLine("Program closed");
                        return;
                    case 1:
                        IneventoryManagementOperation();
                        break;
                    case 2:
                        OrderManagementOperation();
                        break;
                    case 3:
                        Settings();
                        break;
                    case 4:
                        SaveAllData();
                        break;
                }
            }
        }
        public static void IneventoryManagementOperation()
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("Inventory Management\n");
                foreach (Product product in Products)
                {
                    product.ShortDescription();
                }
                Console.WriteLine("1: View details of a product\n2: Add a new product\n" +
                    "3: Clone product\n4: View all Products details\n0: Back to main menu");
                int operation = Convert.ToInt32(Console.ReadLine());
                switch (operation)
                {
                    case 0:
                        return;
                    case 1:
                        ViewProductDetails();
                        break;
                    case 2:
                        AddNewProduct();
                        break;
                    case 4:
                        ViewAllProducts();
                        break;
                }
            }
        }
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
        public static void Settings()
        {

        }
        public static void SaveAllData()
        {

        }
        public static void AddNewProduct()
        {
            Console.WriteLine("Id:");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Name:");
            string name = Console.ReadLine();

            Console.WriteLine("Maximum items in stock:");
            int maxItems = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Description:");
            string? description = Console.ReadLine();

            UnitType unitType;
            while (true)
            {
                Console.Write("Enter the unit type (PerItem, PerBox, PerKg): ");
                string input = Console.ReadLine();

                if (Enum.TryParse(input, true, out unitType))
                {
                    Console.WriteLine($"You selected: {unitType}");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid unit type entered. Please try again.");
                }
            }

            Console.WriteLine("\nPrice:");
            int price = Convert.ToInt32(Console.ReadLine());

            Currency currency;
            while (true)
            {
                Console.Write("Enter the currency (Dollar, Euro, Pound): ");
                string input = Console.ReadLine();

                if (Enum.TryParse(input, true, out currency))
                {
                    Console.WriteLine($"You selected: {currency}");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid currency entered. Please try again.");
                }
            }

            Product product = new Product(id, name, description, unitType, new General.Price(price, currency), maxItems);
            product.LongDescription();
            Products.Add(product);
        }
        public static void ViewProductDetails()
        {
            Console.WriteLine("Product id:\n");
            int id = Convert.ToInt32(Console.ReadLine());
            Product selectedProduct = new Product();

            foreach (Product product in Products)
            {
                if(product.Id == id)
                {
                    selectedProduct = product;
                    selectedProduct.LongDescription();
                    break;
                }
            }
            Console.WriteLine("What do you want to do\n1- Use Product\n2- Go Back");
            int op = Convert.ToInt32(Console.ReadLine());
            switch (op)
            {
                case 2: return;
                case 1:
                    Console.WriteLine("Enter the amount");
                    int amount = Convert.ToInt32(Console.ReadLine());
                    selectedProduct.UseItem(amount);
                    break;
            }
        }
        public static void ViewAllProducts()
        {
            foreach(Product product in Products)
            {
                product.LongDescription();
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
            foreach(OrderItem orderItem in order.OrderItems)
            {
                Product? product = ProductID(orderItem.ProductId);
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
        public static Product ProductID(int id)
        {
            foreach(Product product in Products)
            {
                if(product.Id == id)
                {
                    return product;
                }
            }

            return null;
        }
    }
}
