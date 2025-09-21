using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketReceipt.UnitTests
{
    public class TellerUnitTests
    {
        [Fact(Skip = ("Code needs refactoring, how can I check a private dictionary?"))]
        public void AddSpecialOffer_ShouldAddSpecialOfferToDictionary_WhenProvidedOfferDetails()
        {
            // Arrange
            var teller = new Teller(new FakeCatalog());

            // Act
            teller.AddSpecialOffer(SpecialOfferType.TenPercentDiscount, new Product("Milk", ProductUnit.Each), 10.0);

            // Assert
            Assert.True(false); // Placeholder assertion since we cannot access the private dictionary
        }

        [Theory]
        [InlineData(1.0, 2, 2.0, 1)]
        [InlineData(1.35, 3, 0.52, 6)]
        public void ChecksOutArticlesFrom_ShouldReturnReceiptWithCorrectItemsAndTotalPrice_WhenCartHasItemTwoItems(
            double product1Price,
            int product1Quantity,
            double product2Price,
            int product2Quantity)
        {
            // Arrange
            double product1TotalPrice = product1Price * product1Quantity;
            double product2TotalPrice = product2Price * product2Quantity;
            double totalPrice = product1TotalPrice + product2TotalPrice;

            var product1 = new Product("Bread", ProductUnit.Each);
            var product2 = new Product("Butter", ProductUnit.Each);

            var mockCatalog = new Mock<SupermarketCatalog>();
            mockCatalog.Setup(c => c.GetUnitPrice(product1)).Returns(product1Price);
            mockCatalog.Setup(c => c.GetUnitPrice(product2)).Returns(product2Price);

            var cart = new ShoppingCart();
            cart.AddItemQuantity(product1, product1Quantity);
            cart.AddItemQuantity(product2, product2Quantity);

            var expectedReceipts = new List<ReceiptItem>
            {
                new ReceiptItem(product1, product1Quantity, product1Price, product1TotalPrice),
                new ReceiptItem(product2, product2Quantity, product2Price, product2TotalPrice)
            };

            var teller = new Teller(mockCatalog.Object);

            // Act
            var receipt = teller.ChecksOutArticlesFrom(cart);
            
            // Assert
            receipt.GetTotalPrice().ShouldBe(totalPrice);
            var items = receipt.GetItems();
            items.ShouldBeEquivalentTo(expectedReceipts);
        }
    }
}
