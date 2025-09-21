using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketReceipt
{
    public interface IReceipt
    {
        IEnumerable<ReceiptItem> GetItems();

        void AddItem(ReceiptItem item);

        IEnumerable<Discount> GetDiscounts();

        void AddDiscount(Discount discount);

        double GetTotalPrice();
    }
}
