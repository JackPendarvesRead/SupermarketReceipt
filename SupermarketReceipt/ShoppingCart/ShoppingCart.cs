namespace SupermarketReceipt
{
    public class ShoppingCart : IShoppingCart
    {
        private readonly Dictionary<Product, double> _productQuantities = new Dictionary<Product, double>();

        public IEnumerable<ProductQuantity> GetItems()
        {
            return _productQuantities.Select(x => new ProductQuantity(x.Key, x.Value));
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

        public void EmptyCart()
        {
            _productQuantities.Clear();
        }
    }
}