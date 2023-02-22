using System;
using System.Collections.Generic;

namespace PencilApp
{
    public partial class ProductsInOrder
    {
        public long IdProductsInOrders { get; set; }
        public long IdOrders { get; set; }
        public long IdProducts { get; set; }

        public virtual Order IdOrdersNavigation { get; set; } = null!;
        public virtual Product IdProductsNavigation { get; set; } = null!;
    }
}
