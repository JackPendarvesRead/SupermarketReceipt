using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketReceipt.UnitTests
{
    public class ShoppingCartTests
    {
        [Fact(Skip = "There currently is no robust way to access the private members to test the outcome of these tests")]
        public void AddItem_AddsOneItemToCart()
        {
            // Arrange
            var product = new Product("Apple", ProductUnit.Each);
            var cart = GetUnderTest();

            // Act
            cart.AddItem(product);

            // Assert
        }

        [Fact(Skip = "There currently is no robust way to access the private members to test the outcome of these tests")]
        public void AddItem_AddsOneItemToCartToExistingItem_WhenItemAlreadyAdded()
        {
            // Arrange
            var product = new Product("Apple", ProductUnit.Each);
            var cart = GetUnderTest();

            // Act
            cart.AddItem(product);
            cart.AddItem(product); // needs to be added twice as there is no other way to set this up as code is written

            // Assert
            var productQuantity = cart.GetItems().ShouldHaveSingleItem();
            productQuantity.Product.ShouldBe(product);
            productQuantity.Quantity.ShouldBe(2.0);
        }

        [Theory(Skip = "There currently is no robust way to access the private members to test the outcome of these tests")]
        [InlineData(1.0)]
        [InlineData(5.0)]
        [InlineData(11.111)]
        public void AddItemQuantity_AddsSpecifiedQuantity(double quantity)
        {
            // Arrange
            var product = new Product("Apple", ProductUnit.Each);
            var cart = GetUnderTest();

            // Act
            cart.AddItemQuantity(product, quantity);

            // Assert
            var productQuantity = cart.GetItems().ShouldHaveSingleItem();
            productQuantity.Product.ShouldBe(product);
            productQuantity.Quantity.ShouldBe(quantity);
        }

        [Theory(Skip = "There currently is no robust way to access the private members to test the outcome of these tests")]
        [InlineData(1.0)]
        [InlineData(5.0)]
        [InlineData(11.111)]
        public void AddItemQuantity_AddsSpecifiedQuantityToExistingItem_WhenItemAlreadyAdded(double quantity)
        {
            // Arrange
            var product = new Product("Apple", ProductUnit.Each);
            var cart = GetUnderTest();

            // Act
            cart.AddItemQuantity(product, quantity);
            cart.AddItemQuantity(product, 1); // needs to be added twice as there is no other way to set this up as code is written

            // Assert
            var productQuantity = cart.GetItems().ShouldHaveSingleItem();
            productQuantity.Product.ShouldBe(product);
            productQuantity.Quantity.ShouldBe(quantity + 1);
        }

        [Fact(Skip = "There currently is no robust way to access the private members to test the outcome of these tests")]
        public void HandleOffers_AppliesSpecialOffersCorrectly()
        {
            // Arrange
            var receipt = new Receipt();
            var offers = new Dictionary<Product, Offer>();
            var mockCatalog = new Mock<SupermarketCatalog>();
            var cart = GetUnderTest();

            // Act
            cart.HandleOffers(receipt, offers, mockCatalog.Object);

            // Assert
        }

        private static ShoppingCart GetUnderTest()
        {
            return new ShoppingCart();
        }
    }
}
