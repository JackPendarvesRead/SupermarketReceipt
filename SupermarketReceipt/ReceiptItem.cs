namespace SupermarketReceipt
{
    public class ReceiptItem
    {
        public ReceiptItem(Product product, double quantity, double price)
        {
            Product = product;
            Quantity = quantity;
            Price = price;
        }

        public Product Product { get; }

        public double Price { get; }

        public double Quantity { get; }

        public double TotalPrice => Price * Quantity;
    }
}
