namespace SupermarketReceipt
{
    public class Receipt : IReceipt
    {
        private readonly List<Discount> _discounts = new List<Discount>();
        private readonly List<ReceiptItem> _items = new List<ReceiptItem>();

        public IEnumerable<ReceiptItem> GetItems() 
            => _items;
        
        public void AddItem(ReceiptItem receiptITem)
            => _items.Add(receiptITem);

        public IEnumerable<Discount> GetDiscounts() 
            => _discounts; 

        public void AddDiscount(Discount discount)
            => _discounts.Add(discount);

        public double GetTotalPrice()
        {
            var total = 0.0;
            foreach (var item in _items) total += item.TotalPrice;
            foreach (var discount in _discounts) total += discount.DiscountAmount;
            return total;
        }
    }   
}