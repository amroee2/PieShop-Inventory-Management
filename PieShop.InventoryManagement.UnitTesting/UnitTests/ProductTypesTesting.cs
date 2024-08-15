using PieShop.InventoryManagement.General;
using PieShop.InventoryManagement.ProductManagement;

namespace PieShop.InventoryManagement.UnitTesting.UnitTests
{
    public class ProductTypesTesting
    {
        [Fact]
        public void UnitTest_AddIntoStock()
        {
            //Arrange
            Product product = new RegularProduct(1, "Sugar", "yum", UnitType.PerKg, new Price(10, Currency.Dollar), 100);
            //Act
            product.AddIntoStock(100);
            //Assert
            Assert.Equal(100, product.AmountInStock);
        }
        [Fact]
        public void UnitTest_AddIntoStockMoreThanMax()
        {
            //Arrange
            Product product = new RegularProduct(1, "Sugar", "yum", UnitType.PerKg, new Price(10, Currency.Dollar), 100);
            //Act
            product.AddIntoStock(150);
            //Assert
            Assert.Equal(100, product.AmountInStock);
        }
        [Fact]
        public void UnitTest_UseItem()
        {
            //Arrange
            Product product = new RegularProduct(1, "Sugar", "yum", UnitType.PerKg, new Price(10, Currency.Dollar), 100);
            product.AddIntoStock(100);
            //Act
            product.UseProduct(10);
            //Assert
            Assert.Equal(90, product.AmountInStock);
        }
        [Fact]
        public void UnitTest_UseItemMoreThanAvailableAmount()
        {
            //Arrange
            Product product = new RegularProduct(1, "Sugar", "yum", UnitType.PerKg, new Price(10, Currency.Dollar), 100);
            product.AddIntoStock(100);
            //Act
            product.UseProduct(110);
            //Assert
            Assert.Equal(100, product.AmountInStock);
        }
        [Fact]
        public void UnitTest_UpdateThreshold()
        {
            Product.UpdateThreshold(15);
            Assert.Equal(15, Product.StockThreshold);
        }
        [Fact]
        public void UnitTest_UpdateThresholdBelowLimit()
        {
            Product.UpdateThreshold(-1);
            Assert.NotEqual(-1, Product.StockThreshold);
        }
        [Fact]
        public void UnitTest_UpdateLowStockBelowThreshold()
        {
            Product product = new RegularProduct(1, "Sugar", "yum", UnitType.PerKg, new Price(10, Currency.Dollar), 100);
            product.AddIntoStock(100);


            Product.UpdateThreshold(20);

            product.UseProduct(90);

            Assert.True(product.IsBelowStockThreshold);
        }
        [Fact]
        public void UnitTest_UpdateLowStockAboveThreshold()
        {
            Product product = new RegularProduct(1, "Sugar", "yum", UnitType.PerKg, new Price(10, Currency.Dollar), 100);

            product.AddIntoStock(100);

            Product.UpdateThreshold(20);

            product.UseProduct(70);

            Assert.False(product.IsBelowStockThreshold);
        }
    }
}