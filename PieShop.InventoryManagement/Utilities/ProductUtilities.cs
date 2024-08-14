using PieShop.InventoryManagement.General;
using PieShop.InventoryManagement.ProductManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieShop.InventoryManagement.Utilities
{
    public class ProductUtilities
    {
        public static List<Product> Products = new List<Product>();
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
        public static void ViewProductDetails()
        {
            Console.WriteLine("Product id:\n");
            int id = Convert.ToInt32(Console.ReadLine());
            Product selectedProduct = new Product();

            foreach (Product product in Products)
            {
                if (product.Id == id)
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
        private static void AddNewProduct()
        {
            Console.Write("Id:");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Name:");
            string name = Console.ReadLine();

            Console.Write("Maximum items in stock:");
            int maxItems = Convert.ToInt32(Console.ReadLine());

            Console.Write("Description:");
            string? description = Console.ReadLine();

            UnitType unitType;
            while (true)
            {
                Console.Write("Enter the unit type (PerItem, PerBox, PerKg): ");
                string input = Console.ReadLine();

                if (Enum.TryParse(input, true, out unitType))
                {
                    Console.Write($"You selected: {unitType}");
                    break;
                }
                else
                {
                    Console.Write("Invalid unit type entered. Please try again.");
                }
            }

            Console.Write("\nPrice:");
            int price = Convert.ToInt32(Console.ReadLine());

            Currency currency;
            while (true)
            {
                Console.Write("Enter the currency (Dollar, Euro, Pound): ");
                string input = Console.ReadLine();

                if (Enum.TryParse(input, true, out currency))
                {
                    Console.Write($"You selected: {currency}");
                    break;
                }
                else
                {
                    Console.Write("Invalid currency entered. Please try again.");
                }
            }

            Product product = new Product(id, name, description, unitType, new Price(price, currency), maxItems);
            product.LongDescription();
            Products.Add(product);
        }

        private static void ViewAllProducts()
        {
            foreach (Product product in Products)
            {
                product.LongDescription();
            }
        }
        public static Product CheckIfProductExists(int id)
        {
            foreach (Product product in Products)
            {
                if (product.Id == id)
                {
                    return product;
                }
            }

            return null;
        }
    }
}
