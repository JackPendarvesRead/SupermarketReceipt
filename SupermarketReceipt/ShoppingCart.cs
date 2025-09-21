using System.Globalization;

namespace SupermarketReceipt
{
    public class ShoppingCart
    {
        private readonly Dictionary<Product, double> _productQuantities = new Dictionary<Product, double>();

        public IEnumerable<(Product Product, double Quantity)> GetItems()
        {
            return _productQuantities.Select(x => (x.Key, x.Value));
        }

        public void AddItem(Product product, double quantity = 1.0)
        {
            if (_productQuantities.ContainsKey(product))
            {
                var newAmount = _productQuantities[product] + quantity;
                _productQuantities[product] = newAmount;
            }
            else
            {
                _productQuantities.Add(product, quantity);
            }
        }
    }
}