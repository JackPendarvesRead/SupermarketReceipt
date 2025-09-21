using System.Globalization;
using System.Text.RegularExpressions;

namespace SupermarketReceipt
{
    public class Teller
    {
        private readonly ISupermarketCatalog _catalog;
        private readonly IShoppingCart _cart;

        private readonly Dictionary<Product, Offer> _offers = new Dictionary<Product, Offer>();
        private static readonly CultureInfo Culture = CultureInfo.CreateSpecificCulture("en-GB");

        public Teller(
            ISupermarketCatalog catalog,
            IShoppingCart cart)
        {
            _catalog = catalog;
            _cart = cart;
        }

        public void AddSpecialOffer(SpecialOfferType offerType, Product product, double argument)
        {
            _offers[product] = new Offer(offerType, argument);
        }

        public Receipt ChecksOutArticlesFrom()
        {
            var receipt = new Receipt();
            var productQuantities = _cart.GetItems();
            foreach (var pq in productQuantities)
            {
                var product = pq.Product;
                var quantity = pq.Quantity;
                var unitPrice = _catalog.GetUnitPrice(product);
                receipt.AddItem(new ReceiptItem(product, quantity, unitPrice));
            }

            HandleOffers(receipt, productQuantities);

            return receipt;
        }

        private void HandleOffers(Receipt receipt, IEnumerable<ProductQuantity> productQuantities)
        {
            foreach (var productQuantity in productQuantities)
            {
                var quantity = productQuantity.Quantity;
                var product = productQuantity.Product;

                var quantityAsInt = (int)quantity;
                if (_offers.ContainsKey(product))
                {
                    var offer = _offers[product];
                    var unitPrice = _catalog.GetUnitPrice(product);
                    Discount discount = null;
                    
                    var x = 1;
                    if (offer.OfferType == SpecialOfferType.ThreeForTwo)
                    {
                        x = 3;
                    }
                    else if (offer.OfferType == SpecialOfferType.TwoForAmount)
                    {
                        x = 2;
                        if (quantityAsInt >= 2)
                        {
                            var total = offer.Argument * (quantityAsInt / x) + quantityAsInt % 2 * unitPrice;
                            var discountN = unitPrice * quantity - total;
                            discount = new Discount(product, "2 for " + PrintPrice(offer.Argument), -discountN);
                        }
                    }

                    if (offer.OfferType == SpecialOfferType.FiveForAmount)
                    { 
                        x = 5; 
                    }

                    var numberOfXs = quantityAsInt / x;
                    if (offer.OfferType == SpecialOfferType.ThreeForTwo && quantityAsInt > 2)
                    {
                        var discountAmount = quantity * unitPrice - (numberOfXs * 2 * unitPrice + quantityAsInt % 3 * unitPrice);
                        discount = new Discount(product, "3 for 2", -discountAmount);
                    }

                    if (offer.OfferType == SpecialOfferType.TenPercentDiscount) discount = new Discount(product, offer.Argument + "% off", -quantity * unitPrice * offer.Argument / 100.0);
                    if (offer.OfferType == SpecialOfferType.FiveForAmount && quantityAsInt >= 5)
                    {
                        var discountTotal = unitPrice * quantity - (offer.Argument * numberOfXs + quantityAsInt % 5 * unitPrice);
                        discount = new Discount(product, x + " for " + PrintPrice(offer.Argument), -discountTotal);
                    }

                    if (discount != null)
                    {
                        receipt.AddDiscount(discount);
                    }
                }
            }
        }

        private string PrintPrice(double price)
        {
            return price.ToString("N2", Culture);
        }
    }
}