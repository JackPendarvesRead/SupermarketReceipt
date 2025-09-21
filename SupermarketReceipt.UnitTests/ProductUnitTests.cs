using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketReceipt.UnitTests
{
    public class ProductUnitTests
    {
        [Fact]
        public void Product_PropertiesAreSetCorrectly_WhenInitialized()
        {
            // Arrange
            var name = "Bread";
            var unit = ProductUnit.Each;
            // Act
            var product = new Product(name, unit);
            // Assert
            product.Name.ShouldBe(name);
            product.Unit.ShouldBe(unit);
        }

        [Fact(Skip = "Too tired to work out what to do with this")]
        public void EqualsTest()
        {
        }

        [Fact(Skip = "Too tired to work out what to do with this")]
        public void GetHashTest()
        {
        }
    }
}
