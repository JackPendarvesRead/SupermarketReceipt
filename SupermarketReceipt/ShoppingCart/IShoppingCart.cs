namespace SupermarketReceipt
{
    public interface IShoppingCart
    {
        IEnumerable<ProductQuantity> GetItems();

        void AddItem(Product product, double quantity = 1.0);

        void EmptyCart();
    }
}
