using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketReceipt.UnitTests
{
    public class OfferUnitTests
    {
        [Fact]
        public void Offer_PropertiesAreSetCorrectly_WhenInitialized()
        {
            // Arrange
            var product = new Product("Bread", ProductUnit.Each);
            var offerType = SpecialOfferType.TenPercentDiscount;
            var argument = 10.0;
            
            // Act
            var offer = new Offer(offerType, product, argument);
            
            // Assert
            offer.OfferType.ShouldBe(offerType);
            offer.Argument.ShouldBe(argument);
        }
    }
}
