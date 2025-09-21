using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketReceipt.UnitTests
{
    public class ReceiptUnitTests
    {
        [Fact]
        public void GetTotalPrice_ReturnsTheTotalPriceOfProducts_WhenItemsHaveBeenAdded()
        {
            // Arrange
            var product1 = new Product("Bread", ProductUnit.Each);
            var product2 = new Product("Bread", ProductUnit.Each);

            var receipt = GetUnderTest();

            // Act
            receipt.AddProduct(product1, 1.0, 5.0);
            receipt.AddProduct(product2, 2.0, 1.0);
            var result = receipt.GetTotalPrice(); // This is horrible but working with current code structure

            // Assert
            result.ShouldBe(7.0);
        }

        [Fact]
        public void AddProduct_AddsReceiptItemToList_WhenGivenProduct()
        {
            // Arrange
            var product = new Product("Bread", ProductUnit.Each);

            var receipt = GetUnderTest();

            // Act
            receipt.AddProduct(product, 1.0, 5.0);

            // Assert
            var items = receipt.GetItems(); // This is horrible but working with current code structure
            var item = items.ShouldHaveSingleItem();
            item.Product.ShouldBe(product);
            item.Quantity.ShouldBe(1.0);
            item.Price.ShouldBe(5.0);
            item.TotalPrice.ShouldBe(5.0);
        }

        [Fact]
        public void GetItems_GetsListOfReceiptItems()
        {
            // Arrange
            var product = new Product("Bread", ProductUnit.Each);

            var receipt = GetUnderTest();

            // Act
            receipt.AddProduct(product, 1.0, 5.0);

            // Assert
            var items = receipt.GetItems(); // This is horrible but working with current code structure
            var item = items.ShouldHaveSingleItem();
            item.Product.ShouldBe(product);
            item.Quantity.ShouldBe(1.0);
            item.Price.ShouldBe(5.0);
            item.TotalPrice.ShouldBe(5.0);
        }

        [Fact]
        public void AddDiscount_ShouldAddDiscountToList()
        {
            // Arrange
            var product = new Product("Bread", ProductUnit.Each);
            var discount = new Discount(product, "5% off", -0.25);

            var receipt = GetUnderTest();

            // Act
            receipt.AddDiscount(discount);
            var discounts = receipt.GetDiscounts(); // This is horrible but working with current code structure

            // Assert
            var addedDiscount = discounts.ShouldHaveSingleItem();
            addedDiscount.Product.ShouldBe(product);
            addedDiscount.Description.ShouldBe("5% off");
            addedDiscount.DiscountAmount.ShouldBe(-0.25);
        }

        [Fact]
        public void GetDiscounts_ShouldRetrieveDiscountsList()
        {
            // Arrange
            var product = new Product("Bread", ProductUnit.Each);
            var discount = new Discount(product, "5% off", -0.25);

            var receipt = GetUnderTest();

            // Act
            receipt.AddDiscount(discount);
            var discounts = receipt.GetDiscounts(); // This is horrible but working with current code structure

            // Assert
            var addedDiscount = discounts.ShouldHaveSingleItem();
            addedDiscount.Product.ShouldBe(product);
            addedDiscount.Description.ShouldBe("5% off");
            addedDiscount.DiscountAmount.ShouldBe(-0.25);
        }

        private static Receipt GetUnderTest() => new Receipt();
    }
}
