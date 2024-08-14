using PieShop.InventoryManagement.General;
using PieShop.InventoryManagement.ProductManagement;
using PieShop.InventoryManagement.Utilities;
namespace PieShop.InventoryManagement
{
    public class ProductRepo
    {
        public static void ReadFile()
        {

            string fileName = "C:\\Users\\amro qadadha\\source\\repos\\PieShop.InventoryManagement\\PieShop.InventoryManagement\\Inventory.txt";
            try
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(';');
                        int id = int.Parse(parts[0]);
                        if (ProductUtilities.CheckIfProductExists(id) != null)
                        {
                            continue;
                        }
                        string name = parts[1];
                        string description = parts[2];
                        UnitType unitType;
                        Enum.TryParse(parts[3], true, out unitType);
                        int price = int.Parse(parts[4]);
                        Currency currency;
                        Enum.TryParse(parts[5], true, out currency);
                        int maximumInStock = int.Parse(parts[6]);
                        Product product = new Product(id, name, description, unitType, new Price(price, currency), maximumInStock);
                        ProductUtilities.Products.Add(product);
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"Error: The file '{fileName}' was not found.");
                Console.WriteLine(ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine($"Error: Access to the file '{fileName}' is denied.");
                Console.WriteLine(ex.Message);
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error: An IO error occurred while accessing the file '{fileName}'.");
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred.");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
