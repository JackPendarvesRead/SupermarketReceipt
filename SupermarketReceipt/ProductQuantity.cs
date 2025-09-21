using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketReceipt
{
    public record ProductQuantity
    {
        public ProductQuantity(Product product, double quantity)
        {
            if (quantity <= 0)
            {
                throw new ArgumentException("Quantity must be greater than zero.", nameof(quantity));
            }

            Product = product ?? throw new ArgumentNullException(nameof(product));
            Quantity = quantity;
        }

        public Product Product { get; }
        
        public double Quantity { get; }
    }
}
