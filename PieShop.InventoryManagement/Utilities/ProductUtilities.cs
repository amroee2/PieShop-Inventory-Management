using PieShop.InventoryManagement.General;
using PieShop.InventoryManagement.ProductManagement;
using System.ComponentModel.Design.Serialization;
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
                    case 3:
                        CloneProduct();
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

        private static void CloneProduct()
        {
            Console.WriteLine("Enter ID of the product");
            int id = Convert.ToInt32(Console.ReadLine());
            Product product = CheckIfProductExists(id);
            Product newProduct = (Product) product.Clone();
            Console.WriteLine("Enter the ID of the new product");
            id = Convert.ToInt32(Console.ReadLine());
            newProduct.Id = id;
            Products.Add(newProduct);
        }

        public static void ViewProductDetails()
        {
            Console.WriteLine("Product id:\n");
            int id = Convert.ToInt32(Console.ReadLine());
            Product selectedProduct = null;

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
                    selectedProduct.UseProduct(amount);
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
            Console.Write("Price:");
            int price = Convert.ToInt32(Console.ReadLine());
            Currency currency;
            while (true)
            {
                Console.Write("Enter the currency (Dollar, Euro, Pound): ");
                string input = Console.ReadLine();

                if (Enum.TryParse(input, true, out currency))
                {
                    break;
                }
            }
            UnitType unitType = UnitType.PerKg;
            Console.WriteLine("\nProduct Type?\n1- Normal Product\n2- FreshProduct\n3- Boxed Product");
            int productType = Convert.ToInt32(Console.ReadLine());
            Product product = null;
            switch (productType)
            {
                case 1:
                    unitType = getunitType(unitType);
                    product = new RegularProduct(id, name, description, unitType, new Price(price, currency), maxItems);
                    break;
                case 2:
                    product = new FreshProduct(id, name, description,unitType, new Price(price, currency), maxItems);
                    break;
                case 3:
                    Console.WriteLine("Amount per box?");
                    int amount = Convert.ToInt32(Console.ReadLine());
                    product = new BoxedProduct(id, name, description, new Price(price, currency), maxItems, amount);
                    break;
            }
            if (product != null)
            {
                product.LongDescription();
                Products.Add(product);
            }
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
        public static UnitType getunitType(UnitType unitType)
        {
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
            return unitType;
        }
    }
}
