using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketReceipt.UnitTests
{
    public class DiscountUnitTests
    {
        [Fact]
        public void Discount_PropertiesAreSetCorrectly_WhenInitialized()
        {
            // Arrange
            var product = new Product("Bread", ProductUnit.Each);
            var description = "10% off";
            var discountAmount = 0.5;

            // Act
            var discount = new Discount(product, description, discountAmount);

            // Assert
            discount.Product.ShouldBe(product);
            discount.Description.ShouldBe(description);
            discount.DiscountAmount.ShouldBe(discountAmount);
        }
    }
}
