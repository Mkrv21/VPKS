using System;
using System.Collections.Generic;

namespace PencilApp
{
    public partial class Product
    {
        public Product()
        {
            ProductsInOrders = new HashSet<ProductsInOrder>();
        }

        public long IdProducts { get; set; }
        public string Name { get; set; } = null!;
        public long Quantity { get; set; }
        public long Cost { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<ProductsInOrder> ProductsInOrders { get; set; }
    }
}
